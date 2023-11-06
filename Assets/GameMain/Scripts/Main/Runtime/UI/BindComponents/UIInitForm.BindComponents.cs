using UnityEngine;
using UnityEngine.UI;

namespace Main.Runtime.UI
{
	public partial class UIInitForm
	{
		private RectTransform m_Transform_UILaunchView;
		private RectTransform m_Transform_UILoadingForm;
		private RectTransform m_Transform_UIDialogForm;

		private void GetBindComponents(GameObject go)
		{
			ComponentAutoBindTool autoBindTool = go.GetComponent<ComponentAutoBindTool>();

			m_Transform_UILaunchView = autoBindTool.GetBindComponent<RectTransform>(0);
			m_Transform_UILoadingForm = autoBindTool.GetBindComponent<RectTransform>(1);
			m_Transform_UIDialogForm = autoBindTool.GetBindComponent<RectTransform>(2);
		}
	}
}
