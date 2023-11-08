using cfg.GameMain;
using GameFramework;
using GameFramework.Event;
using HotfixFramework;
using Main.Runtime.Procedure;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace HotfixBusiness.Procedure
{
    public class ProcedureChangeScene : ProcedureBase
    {
        private int m_UIFormSerialId;

        private bool m_LoadSceneComplete;
        private bool m_LoadSceneSuccess;
        private string m_NextProcedure;

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            m_NextProcedure = procedureOwner.GetData<VarString>("nextProcedure");
            m_LoadSceneComplete = false;
            m_LoadSceneSuccess = false;

            OnStartLoadScene();
            GameEntry.Event.Subscribe(LoadSceneSuccessEventArgs.EventId, OnHandleLoadSceneSuccess);
            GameEntry.Event.Subscribe(LoadSceneFailureEventArgs.EventId, OnHandleLoadSceneFailure);
            GameEntry.Event.Subscribe(LoadSceneUpdateEventArgs.EventId, OnHandleLoadSceneUpdate);
            GameEntry.Event.Subscribe(LoadSceneDependencyAssetEventArgs.EventId, OnHandleLoadSceneDependencyAsset);
            GameEntry.Event.Subscribe(LoadSceneCompleteEventArgs.EventId, OnHandleLoadCompleteSuccess);

            m_UIFormSerialId = GameEntry.UI.OpenUIForm(ConstUI.UIFormId.UILoadingForm, this);
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
            if (m_LoadSceneSuccess && m_LoadSceneComplete)
            {
                ChangeState(procedureOwner, GameEntry.GetProcedureByName(m_NextProcedure).GetType());
            }
        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);

            GameEntry.Event.Unsubscribe(LoadSceneSuccessEventArgs.EventId, OnHandleLoadSceneSuccess);
            GameEntry.Event.Unsubscribe(LoadSceneFailureEventArgs.EventId, OnHandleLoadSceneFailure);
            GameEntry.Event.Unsubscribe(LoadSceneUpdateEventArgs.EventId, OnHandleLoadSceneUpdate);
            GameEntry.Event.Unsubscribe(LoadSceneDependencyAssetEventArgs.EventId, OnHandleLoadSceneDependencyAsset);
            GameEntry.Event.Unsubscribe(LoadSceneCompleteEventArgs.EventId, OnHandleLoadCompleteSuccess);

            if (m_UIFormSerialId != 0 && GameEntry.UI.HasUIForm((int)m_UIFormSerialId))
            {
                GameEntry.UI.CloseUIForm((int)m_UIFormSerialId);
            }

            GameEntry.UI.CloseAllLoadedUIForms();
        }

        void OnStartLoadScene()
        {
            UnloadAllResources();
            bool needChangeScene = Constant.Procedure.NeedChangeScene(m_NextProcedure);
            if (needChangeScene)
            {
                string sceneName = Constant.Procedure.FindSceneName(m_NextProcedure);
                string scenePath = AssetUtility.Scene.GetSceneAsset(sceneName);
                GameEntry.Scene.LoadScene(scenePath, Constant.AssetPriority.SceneAsset);
            }
        }

        void UnloadAllScene()
        {
            string[] loadedSceneAssetNames = GameEntry.Scene.GetLoadedSceneAssetNames();
            foreach (string sceneAssetName in loadedSceneAssetNames)
            {
                GameEntry.Scene.UnloadScene(sceneAssetName);
            }
        }

        private void OnHandleLoadSceneSuccess(object sender, GameEventArgs e)
        {
            m_LoadSceneSuccess = true;
        }

        private void OnHandleLoadSceneFailure(object sender, GameEventArgs e)
        {
            LoadSceneFailureEventArgs ne = (LoadSceneFailureEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }

            //Log.Error("Load scene '{0}' failure, error message '{1}'.", ne.SceneAssetName, ne.ErrorMessage);
        }

        private void OnHandleLoadSceneUpdate(object sender, GameEventArgs e)
        {
            LoadSceneUpdateEventArgs ne = (LoadSceneUpdateEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }

            //Log.Info("Load scene '{0}' update, progress '{1}'.", ne.SceneAssetName, ne.Progress.ToString("P2"));
        }
        private void OnHandleLoadSceneDependencyAsset(object sender, GameEventArgs e)
        {
            LoadSceneDependencyAssetEventArgs ne = (LoadSceneDependencyAssetEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }

            //Log.Info("Load scene '{0}' dependency asset '{1}', count '{2}/{3}'.", ne.SceneAssetName, ne.DependencyAssetName, ne.LoadedCount.ToString(), ne.TotalCount.ToString());
        }

        private void OnHandleLoadCompleteSuccess(object sender, GameEventArgs e)
        {
            m_LoadSceneComplete = true;
        }
    }
}