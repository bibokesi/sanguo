using UnityEngine;

public class Star : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
	{
		if (other != null && other.gameObject.layer == LayerMask.NameToLayer("Player"))
		{
			//�������������ʱ, ����TrigStarEventArgs��Ϣ
			GameEntry.Event.Fire(this, TrigStarEventArgs.Create(1, null));

			gameObject.SetActive(false);
		}
	}
}
