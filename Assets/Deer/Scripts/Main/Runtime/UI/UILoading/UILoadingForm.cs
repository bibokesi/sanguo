using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace Main.Runtime.UI 
{
    public partial class UILoadingForm : UIBaseForm
    {
		protected override void OnInit(object userData) {
			 base.OnInit(userData);
			 GetBindComponents(gameObject);

/*--------------------Auto generate start button listener.Do not modify!--------------------*/
/*--------------------Auto generate end button listener.Do not modify!----------------------*/
		}
        private void Awake()
        {
            OnInit(this);
        }

        public void RefreshProgress(float curProgress,float totalProgress,string tips = "") 
        {
            m_Img_ProgressValue.fillAmount = curProgress / totalProgress;
            m_TxtM_Tips.text = tips;
        }
/*--------------------Auto generate footer.Do not add anything below the footer!------------*/
	}
}
