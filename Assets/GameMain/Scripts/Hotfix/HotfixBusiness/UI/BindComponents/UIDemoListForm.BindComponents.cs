using SuperScrollView;
using UnityEngine;
using UnityEngine.UI;

namespace HotfixBusiness.UI
{
	public partial class UIDemoListForm
	{
		private UIButtonSuper m_Button_Back;
		private LoopListView2 m_LoopListView2_ListView;

		private void GetBindComponents(GameObject go)
		{
			ComponentAutoBindTool autoBindTool = go.GetComponent<ComponentAutoBindTool>();

			m_Button_Back = autoBindTool.GetBindComponent<UIButtonSuper>(0);
			m_LoopListView2_ListView = autoBindTool.GetBindComponent<LoopListView2>(1);
		}
	}
}
