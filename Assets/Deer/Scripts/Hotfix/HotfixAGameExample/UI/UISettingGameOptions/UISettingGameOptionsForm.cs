using HotfixFramework.Runtime;
using System.Collections.Generic;

namespace HotfixBusiness.UI
{
	public partial class UISettingGameOptionsForm : UIFixBaseForm
	{
		List<string> m_Languages = new List<string>()
		{
			"简体中文",
			"繁体中文",
			"English",
			"俄语",
			"英语"
		};

		protected override void OnInit(object userData) {
			 base.OnInit(userData);
			 GetBindComponents(gameObject);

/*--------------------Auto generate start button listener.Do not modify!--------------------*/
			m_Btn_Back.onClick.AddListener(Btn_BackEvent);
/*--------------------Auto generate end button listener.Do not modify!----------------------*/
		}

		protected override void OnOpen(object userData)
		{
			base.OnOpen(userData);

			for (int i = 0; i < m_Languages.Count; i++)
			{
				m_HSelector_LanguageSelector.CreateNewItem(m_Languages[i]);
			}
		}

		private void Btn_BackEvent()
		{
			Close();
		}
/*--------------------Auto generate footer.Do not add anything below the footer!------------*/
	}
}
