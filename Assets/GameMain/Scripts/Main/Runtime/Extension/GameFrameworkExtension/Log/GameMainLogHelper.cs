using GameFramework;

/// <summary>
/// 日志输出工具
/// </summary>
public class GameMainLogHelper : GameFrameworkLog.ILogHelper
{
	public void Log(GameFrameworkLogLevel level, object message)
	{
		switch (level)
		{
			case GameFrameworkLogLevel.Debug:
				Logger.Debug(message.ToString(),true);
				break;
			case GameFrameworkLogLevel.Info:
				Logger.Info(message.ToString(),true);
				break;
			case GameFrameworkLogLevel.Warning:
				Logger.Warning(message.ToString(),true);
				break;
			case GameFrameworkLogLevel.Error:
				Logger.Error(message.ToString(),true);
				break;
			case GameFrameworkLogLevel.Fatal:
				Logger.Fatal(message.ToString(),true);
				break;
			default:
				throw new GameFrameworkException(message.ToString());
		}
	}
}