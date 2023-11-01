using UnityEngine;
using UnityEngine.UI;

namespace HotfixBusiness.UI
{
	public partial class UIMainMenuForm
	{
		private UIButtonSuper m_Btn_GameMainExample;
		private UIButtonSuper m_Btn_GameMainGame;

		private void GetBindComponents(GameObject go)
		{
			ComponentAutoBindTool autoBindTool = go.GetComponent<ComponentAutoBindTool>();

			m_Btn_GameMainExample = autoBindTool.GetBindComponent<UIButtonSuper>(0);
			m_Btn_GameMainGame = autoBindTool.GetBindComponent<UIButtonSuper>(1);
		}
	}
}
