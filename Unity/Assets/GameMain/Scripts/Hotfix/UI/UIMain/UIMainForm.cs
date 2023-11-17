using Fantasy;
using Main.Runtime;
using UnityEngine.UIElements;
using UnityGameFramework.Runtime;

public partial class UIMainForm : UIFixBaseForm
{
	protected override void OnInit(object userData) {
		base.OnInit(userData);
		GetBindComponents(gameObject);

		m_Button_Text.onClick.AddListener(Button_TextEvent);
	}

	private void Button_TextEvent()
    {
        Test().Coroutine();

        //if (GameEntry.Procedure.CurrentProcedure is ProcedureBase procedureBase)
        //{
        //    procedureBase.ProcedureOwner.SetData<VarString>("nextProcedure", Const.Procedure.ProcedureFight);
        //    procedureBase.ChangeStateByType(procedureBase.ProcedureOwner, typeof(ProcedureCheckAssets));
        //}
    }

    public async FTask Test()
    {
        G2C_EnterMapResponse response = (G2C_EnterMapResponse)await GameEntry.Fantasy.Gate.Session.Call(new C2G_EnterMapRequest()
        {
            PlayerId = PlayerManager.Instance.GetOwnerId()
        });
        if (response.ErrorCode != 0)
        {
            if (response.ErrorCode == 1)
            {
                GameEntry.UI.OpenTips("用户名重复");
            }
            return;
        }

        MoveInfo moveInfo = new MoveInfo
        {
            X = 0,
            Y = 0,
            Z = 0,
            RotA = 0,
            RotB = 0,
            RotC = 0,
            RotW = 0
        };

        GameEntry.Fantasy.Gate.Session.Send(new C2Map_MoveMessage
        {
            MoveInfo = moveInfo
        });
    }
}

