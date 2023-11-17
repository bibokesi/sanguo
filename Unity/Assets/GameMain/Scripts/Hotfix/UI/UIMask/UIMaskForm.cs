
using DG.Tweening;
using UnityEngine;

public partial class UIMaskForm : UIFixBaseForm
{
	protected override void OnInit(object userData) {
		base.OnInit(userData);
		GetBindComponents(gameObject);

		m_Img_Rot.transform.DOLocalRotate(new Vector3(0, 0, 360f), 0.5f, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
	}
}

