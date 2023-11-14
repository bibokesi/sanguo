using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 自定义Coroutine 的 等待时间 区别于 WaitForSeconds
/// WaitForSeconds 受 Time.scaleTime 影响
/// WaitForSecondsRealtime 不受 Time.scaleTime 影响
/// </summary>
public class WaitForSecondsRealtime : CustomYieldInstruction
{

	private float waitTime;

	public override bool keepWaiting
	{
		get
		{
			return Time.realtimeSinceStartup < waitTime;
		}
	}

	public WaitForSecondsRealtime(float time)
	{
		waitTime = Time.realtimeSinceStartup + time;
	}
}