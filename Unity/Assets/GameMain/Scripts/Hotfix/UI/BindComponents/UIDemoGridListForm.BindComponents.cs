using SuperScrollView;
using UnityEngine;
using UnityEngine.UI;

namespace Hotfix.UI
{
	public partial class UIDemoGridListForm
	{
		private UIButtonSuper m_Button_Back;
		private LoopGridView m_LoopGridView_ListView;

		private void GetBindComponents(GameObject go)
		{
			ComponentAutoBindTool autoBindTool = go.GetComponent<ComponentAutoBindTool>();

			m_Button_Back = autoBindTool.GetBindComponent<UIButtonSuper>(0);
			m_LoopGridView_ListView = autoBindTool.GetBindComponent<LoopGridView>(1);
		}
	}
}
