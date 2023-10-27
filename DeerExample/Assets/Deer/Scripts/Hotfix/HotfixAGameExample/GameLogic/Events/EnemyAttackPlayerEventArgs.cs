using GameFramework;
using GameFramework.Event;

/// <summary>
/// ���˹�������� ���¼�
/// </summary>
public sealed class EnemyAttackPlayerEventArgs : GameEventArgs
{
	public static readonly int EventId = typeof(EnemyAttackPlayerEventArgs).GetHashCode();

	public EnemyAttackPlayerEventArgs()
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

	/// <summary>
	/// ��ȡ�û��Զ������ݡ�
	/// </summary>
	public object UserData
	{
		get;
		private set;
	}

	public float Damage
	{
		get;
		private set;
	}

	public static EnemyAttackPlayerEventArgs Create(float damage, object userData)
	{
		EnemyAttackPlayerEventArgs enemyAttackPlayerEventArgs = ReferencePool.Acquire<EnemyAttackPlayerEventArgs>();
		enemyAttackPlayerEventArgs.Damage = damage;
		enemyAttackPlayerEventArgs.UserData = userData;
		return enemyAttackPlayerEventArgs;
	}

	public override void Clear()
	{
		UserData = null;
	}
}
