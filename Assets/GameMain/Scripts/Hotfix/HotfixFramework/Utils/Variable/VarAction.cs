using System;
using GameFramework;

public class VarAction : Variable<Action>
{
	/// <summary>
	/// 初始化 System.Action 变量类的新实例。
	/// </summary>
	public VarAction()
	{
	}

	/// <summary>
	/// 从 System.Action 到 System.Action 变量类的隐式转换。
	/// </summary>
	/// <param name="value">值。</param>
	public static implicit operator VarAction(Action value)
	{
		VarAction varValue = ReferencePool.Acquire<VarAction>();
		varValue.Value = value;
		return varValue;
	}

	/// <summary>
	/// 从 System.Action 变量类到 System.Action 的隐式转换。
	/// </summary>
	/// <param name="value">值。</param>
	public static implicit operator Action(VarAction value)
	{
		return value.Value;
	}
}