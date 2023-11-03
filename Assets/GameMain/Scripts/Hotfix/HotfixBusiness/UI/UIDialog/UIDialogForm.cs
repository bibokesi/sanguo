using HotfixFramework;
using Main.Runtime;

namespace HotfixBusiness.UI
{
	public partial class UIDialogForm : UIFixBaseForm
	{
		private DialogParams m_DialogParams;
		protected override void OnInit(object userData) {
			 base.OnInit(userData);
			 GetBindComponents(gameObject);

/*--------------------Auto generate start button listener.Do not modify!--------------------*/
			 m_Btn_bg.onClick.AddListener(Btn_bgEvent);
			 m_Btn_Sure.onClick.AddListener(Btn_SureEvent);
			 m_Btn_Cancel.onClick.AddListener(Btn_CancelEvent);
			 m_Btn_Other.onClick.AddListener(Btn_OtherEvent);
/*--------------------Auto generate end button listener.Do not modify!----------------------*/
		}

		protected override void OnOpen(object userData)
		{
			base.OnOpen(userData);
			m_DialogParams = (DialogParams)userData;
			if (m_DialogParams == null)
			{
				Close();
				return;
			}
			m_TxtM_Tilte.text = m_DialogParams.Title;
			m_TxtM_Content.text = m_DialogParams.Message;
			m_TxtM_Sure.text = m_DialogParams.ConfirmText;
			m_TxtM_Cancel.text = m_DialogParams.CancelText;
			m_TxtM_Other.text = m_DialogParams.OtherText;
			m_Btn_Sure.gameObject.SetActive(m_DialogParams.Mode >= 1);
			m_Btn_Cancel.gameObject.SetActive(m_DialogParams.Mode >= 2);
			m_Btn_Other.gameObject.SetActive(m_DialogParams.Mode >= 3);
		}

		private void Btn_bgEvent()
		{
			m_DialogParams.OnClickBackground?.Invoke(m_DialogParams.UserData);
			Close();
		}

		private void Btn_SureEvent()
		{
			m_DialogParams.OnClickConfirm?.Invoke(m_DialogParams.UserData);
			Close();
		}

		private void Btn_CancelEvent()
		{
			m_DialogParams.OnClickCancel?.Invoke(m_DialogParams.UserData);
			Close();
		}

		private void Btn_OtherEvent()
		{
			m_DialogParams.OnClickOther?.Invoke(m_DialogParams.UserData);
			Close();
		}
/*--------------------Auto generate footer.Do not add anything below the footer!------------*/
	}
}
