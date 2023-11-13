﻿using HotfixFramework;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace HotfixBusiness.UI
{
	public partial class UITipsForm : UIFixBaseForm
	{
		protected override void OnInit(object userData) {
			 base.OnInit(userData);
			 GetBindComponents(gameObject);

/*--------------------Auto generate start button listener.Do not modify!--------------------*/
/*--------------------Auto generate end button listener.Do not modify!----------------------*/
		}

		protected override void OnOpen(object userData)
		{
			base.OnOpen(userData);
			MessengerInfo info = (MessengerInfo)userData;
			if (info == null)
			{
				Close();
				return;
			}
			m_Img_bg.transform.localPosition = Vector3.zero;
			string tips = info.param1.ToString();
			Color color = (Color)info.param2;
			bool isOpenBg = (bool)info.param3;
			m_TxtM_Content.text = tips;
			m_TxtM_Content.color = color;
			m_Img_bg.enabled = isOpenBg;
			m_Img_bg.transform.DOMoveY(3, 1f).OnComplete(Close);
		}
		/*--------------------Auto generate footer.Do not add anything below the footer!------------*/
	}
}