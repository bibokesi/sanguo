
using HotfixBusiness.Entity;
using HotfixFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HotfixBusiness.UI
{
	public partial class UIDemoEntityForm : UIFixBaseForm
	{
		protected override void OnInit(object userData) {
			 base.OnInit(userData);
			 GetBindComponents(gameObject);

            /*--------------------Auto generate start button listener.Do not modify!--------------------*/
            /*--------------------Auto generate end button listener.Do not modify!----------------------*/

            ShowEntity();
		}


		void ShowEntity()
        {
            UIEntityData tmpData = new UIEntityData(GameEntry.Entity.GenEntityId(), 1, "UIModel", "Ball_Machine");
            tmpData.Position = new Vector3(1000, 0, 5);
            tmpData.Scale = new Vector3(3, 3, 3);
            GameEntry.Entity.ShowEntity(typeof(UIEntity), "UIModel", 1, tmpData);
            int id = tmpData.Id;
        }

/*--------------------Auto generate footer.Do not add anything below the footer!------------*/
	}
}
