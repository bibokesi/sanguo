/// <summary>
/// 配置表信息
/// </summary>
public class ConfigInfo
{
    /// <summary>
    /// 配置文件名
    /// </summary>
    public string Name
    {
        get;
        set;
    }

    /// <summary>
    /// 配置文件名不带后缀
    /// </summary>
    public string NameWithoutExtension
    {
        get;
        set;
    }

    /// <summary>
    /// 配置文件名后缀
    /// </summary>
    public string Extension
    {
        get;
        set;
    }

    /// <summary>
    /// 路径
    /// </summary>
    public string Path
    {
        get;
        set;
    }

    /// <summary>
    /// 文件大小
    /// </summary>
    public string Size
    {
        get;
        set;
    }

    /// <summary>
    /// 文件MD5
    /// </summary>
    public string HashCode
    {
        get;
        set;
    }

    /// <summary>
    /// 重试次数
    /// </summary>
    public int RetryCount
    {
        get;
        set;
    }

    /// <summary>
    /// 是否为只读文件
    /// </summary>
    public bool IsLoadReadOnly = true;
}