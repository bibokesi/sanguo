using Main.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

public class ProcedureFight : ProcedureBase
{
    public override bool UseNativeDialog => false;

    private int m_UIFormSerialId = 0;

    protected override void OnEnter(ProcedureOwner procedureOwner)
    {
        base.OnEnter(procedureOwner);

        // 打开界面
        ShowSceneForm(true);

        // 播放背景音乐
        GameEntry.Sound.PlayMusic((int)SceneEnum.Fight);

        ShowEntity();
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
                m_UIFormSerialId = GameEntry.UI.OpenUIForm(ConstUI.GetUIFormInfo<UIFightForm>());
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

    void ShowEntity()
    {
        PlayerEntityData playerEntityData = new PlayerEntityData(GameEntry.Entity.GenEntityId(), 1, Const.EntityGroup.PlayerEntity, "Blade_girl");
        playerEntityData.Position = new UnityEngine.Vector3(142, 2, 68);
        playerEntityData.IsOwner = true;
        GameEntry.Entity.ShowEntity(typeof(PlayerEntity), Const.EntityGroup.PlayerEntity, 1, playerEntityData);
    }
}
