using HotfixFramework.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HotfixBusiness.UI
{
	public struct classsssss
	{
		public string name;
		public int count;
	}

	public partial class UIBagForm : UIFixBaseForm
	{
		private int var111;
		protected override void OnInit(object userData) {
			 base.OnInit(userData);
			 GetBindComponents(gameObject);

/*--------------------Auto generate start button listener.Do not modify!--------------------*/
			 m_Btn_Test.onClick.AddListener(Btn_TestEvent);
			 m_Btn_Test1.onClick.AddListener(Btn_Test1Event);
/*--------------------Auto generate end button listener.Do not modify!----------------------*/
			m_Btn_Test.onClick.AddListener(Test1);
		}
		private void Test1()
		{
			
		}
		private void Btn_TestEvent(){}

		private void Test2()
		{
			
		}
		private void Btn_Test1Event(){}
/*--------------------Auto generate footer.Do not add anything below the footer!------------*/
	}
}
