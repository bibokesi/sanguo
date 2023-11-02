using GameFramework;
using GameMainExample1.UI;
using HotfixBusiness.Entity;
using Main.Runtime.Procedure;
using UnityEngine;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace GameMainExample1.Procedure
{
    public class ProcedureGameMainMain : ProcedureBase
    {
        private int m_UIFormSerialId;
        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            m_UIFormSerialId = GameEntry.UI.OpenUIForm(AGameMainConstantUI.GetUIFormInfo<UIGameMainGamePlayForm>(),this);

            //ChangeState<ProcedureBattle>(procedureOwner);
            string groupName = Constant.Procedure.FindAssetGroup(GameEntry.Procedure.CurrentProcedure.GetType().FullName);
            CharacterPlayerData characterData = new CharacterPlayerData(GameEntry.Entity.GenEntityId(),1, groupName,"Character/Character");
            characterData.Position = new Vector3(142,2,68);
            characterData.IsOwner = true;
            GameEntry.Entity.ShowEntity(typeof(CharacterPlayer),"Character",1,characterData);
        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);
            if (m_UIFormSerialId!=0 && GameEntry.UI.HasUIForm(m_UIFormSerialId))
            {
                GameEntry.UI.CloseUIForm((int)m_UIFormSerialId);
            }
        }
    }
}