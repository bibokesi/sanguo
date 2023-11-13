using UnityEngine;
using UnityEngine.UI;

namespace HotfixBusiness.UI
{
	public partial class UIFightForm
	{
		private UIButtonSuper m_Button_Text;

		private void GetBindComponents(GameObject go)
		{
			ComponentAutoBindTool autoBindTool = go.GetComponent<ComponentAutoBindTool>();

			m_Button_Text = autoBindTool.GetBindComponent<UIButtonSuper>(0);
		}
	}
}
