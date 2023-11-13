using System;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace Main.Runtime.Procedure
{
    public abstract class ProcedureBase : GameFramework.Procedure.ProcedureBase
    {
        public virtual bool UseNativeDialog
        {
            get { return false; }
        }
        
        protected ProcedureOwner m_ProcedureOwner;
        public virtual ProcedureOwner ProcedureOwner => m_ProcedureOwner;

        public void ChangeStateByType(ProcedureOwner fsm, Type stateType) 
        {
            ChangeState(fsm, stateType);
        }

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            m_ProcedureOwner = procedureOwner;
        }

        protected void UnloadAllResources()
        {
            UnloadAllScene();
            GameEntryMain.Entity.HideAllLoadedEntities();
            GameEntryMain.Entity.HideAllLoadingEntities();
            GameEntryMain.Sound.StopAllLoadingSounds();
            GameEntryMain.Sound.StopAllLoadedSounds();
            GameEntryMain.ObjectPool.ReleaseAllUnused();
            GameEntryMain.Resource.ForceUnloadUnusedAssets(true);
        }

        protected void UnloadAllScene() 
        {
            string[] loadedSceneAssetNames = GameEntryMain.Scene.GetLoadedSceneAssetNames();
            string[] unloadScenes = GameEntryMain.Scene.GetUnloadingSceneAssetNames();
            foreach (string sceneAssetName in loadedSceneAssetNames)
            {
                bool isFind = false;
                foreach (var unloadScene in unloadScenes)
                {
                    if (sceneAssetName == unloadScene)
                    {
                        isFind = true;
                    }
                }
                if (!isFind)
                {
                    GameEntryMain.Scene.UnloadScene(sceneAssetName);
                }
            }
        }
    }
}