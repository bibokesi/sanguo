using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HotfixBusiness.UI
{
	public partial class UILoadingForm
	{
		private RectTransform m_Transform_Progress;
		private Image m_Image_ProgressValue;
		private TextMeshProUGUI m_Text_Tips;

		private void GetBindComponents(GameObject go)
		{
			ComponentAutoBindTool autoBindTool = go.GetComponent<ComponentAutoBindTool>();

			m_Transform_Progress = autoBindTool.GetBindComponent<RectTransform>(0);
			m_Image_ProgressValue = autoBindTool.GetBindComponent<Image>(1);
			m_Text_Tips = autoBindTool.GetBindComponent<TextMeshProUGUI>(2);
		}
	}
}
