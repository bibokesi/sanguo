using GameFramework;
using HotfixBusiness.Data;
using HotfixBusiness.UI;
using Main.Runtime.Procedure;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace HotfixBusiness.Procedure
{
    public class ProcedureFight : ProcedureBase
    {
        public override bool UseNativeDialog => false;

        private int m_FightFormId = 0;

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            // 打开战斗界面
            ShowFightForm(true);

            // 播放背景音乐
            GameEntry.Sound.PlayMusic((int)SceneEnum.Fight);
        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);

            ShowFightForm(false);            
        }

        private void ShowFightForm(bool isOpen)
        {
            if (isOpen)
            {
                if (!GameEntry.UI.HasUIForm(m_FightFormId) && !GameEntry.UI.IsLoadingUIForm(m_FightFormId))
                {
                    m_FightFormId = GameEntry.UI.OpenUIForm(ConstantUI.GetUIFormInfo<UIFightForm>());
                }
            }
            else
            {
                if (GameEntry.UI.HasUIForm(m_FightFormId) || GameEntry.UI.IsLoadingUIForm(m_FightFormId))
                { 
                    GameEntry.UI.CloseUIForm(m_FightFormId);
                }
            }
        }
    }
}