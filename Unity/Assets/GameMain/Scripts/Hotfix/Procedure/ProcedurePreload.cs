using Main.Runtime;
using System.Collections.Generic;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
using UnityGameFramework.Runtime;


public class ProcedurePreload : ProcedureBase
{
    private ProcedureOwner m_procedureOwner = null;
    private HashSet<string> m_LoadConfigFlag = new HashSet<string>();

    protected override void OnEnter(ProcedureOwner procedureOwner)
    {
        base.OnEnter(procedureOwner);

        Logger.Debug("ProcedurePreload OnEnter");

        m_procedureOwner = procedureOwner;

        PreloadConfig();
    }
    protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
        if (IsPreloadFinish())
        {
            if (GameEntry.Procedure.CurrentProcedure is ProcedureBase procedureBase)
            {
                procedureBase.ProcedureOwner.SetData<VarString>("nextProcedure", Const.Procedure.ProcedureLogin);
                procedureBase.ChangeStateByType(procedureBase.ProcedureOwner, typeof(ProcedureCheckAssets));
            }
        }
    }
    protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
    {
        base.OnLeave(procedureOwner, isShutdown);
    }
    private bool IsPreloadFinish()
    {
        if (m_LoadConfigFlag.Count == 0)
        {
            return true;
        }

        return false;
    }
    #region Config
    private void PreloadConfig()
    {
        m_LoadConfigFlag.Clear();
        m_LoadConfigFlag.Add("Config");
        GameEntry.Config.LoadAllUserConfig(OnLoadConfigComplete);
    }
    private void OnLoadConfigComplete(bool result, string resultMessage)
    {
        if (result)
        {
            m_LoadConfigFlag.Remove("Config");
            PreloadAfterLoadingConfig();
        }
        else
        {
            Logger.ColorInfo(ColorType.cadetblue, resultMessage);
        }
    }
    #endregion
    /// <summary>
    /// 加载完 config 之后，重新加载游戏配置
    /// </summary>
    private void PreloadAfterLoadingConfig()
    {
        PreloadView();
    }

    private void PreloadView()
    {


    }
}
