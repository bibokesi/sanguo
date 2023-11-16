using Main.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;


public class ProcedureMain : ProcedureBase
{
    public override bool UseNativeDialog => false;

    private int m_UIFormSerialId = 0;

    protected override void OnEnter(ProcedureOwner procedureOwner)
    {
        base.OnEnter(procedureOwner);

        // 打开界面
        ShowSceneForm(true);

        // 播放背景音乐
        GameEntry.Sound.PlayMusic((int)SceneEnum.Main);
    }

    protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
    {
        base.OnLeave(procedureOwner, isShutdown);

        ShowSceneForm(false);            
    }

    private void ShowSceneForm(bool isOpen)
    {
        if (isOpen)
        {
            if (!GameEntry.UI.HasUIForm(m_UIFormSerialId) && !GameEntry.UI.IsLoadingUIForm(m_UIFormSerialId))
            {
                m_UIFormSerialId = GameEntry.UI.OpenUIForm(ConstUI.GetUIFormInfo<UIMainForm>());
            }
        }
        else
        {
            if (GameEntry.UI.HasUIForm(m_UIFormSerialId) || GameEntry.UI.IsLoadingUIForm(m_UIFormSerialId))
            {
                GameEntry.UI.CloseUIForm(m_UIFormSerialId);
            }
        }
    }
}
