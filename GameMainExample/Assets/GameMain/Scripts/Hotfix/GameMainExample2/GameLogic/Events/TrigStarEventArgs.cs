using GameFramework;
using GameFramework.Event;

/// <summary>
/// �����ײ������ ���¼�
/// </summary>
public class TrigStarEventArgs : GameEventArgs
{
	public static readonly int EventId = typeof(TrigStarEventArgs).GetHashCode();

	public TrigStarEventArgs()
	{
		UserData = null;
	}


	public override int Id
	{
		get
		{
			return EventId;
		}
	}

	//��������
	public float StarNum
	{
		get;
		private set;
	}

	/// <summary>
	/// ��ȡ�û��Զ������ݡ�
	/// </summary>
	public object UserData
	{
		get;
		private set;
	}


	public static TrigStarEventArgs Create(float starNum, object userData)
	{
		TrigStarEventArgs eventArgs = ReferencePool.Acquire<TrigStarEventArgs>();
		eventArgs.UserData = userData;
		eventArgs.StarNum = starNum;
		return eventArgs;
	}

	public override void Clear()
	{
		UserData = null;
	}
}