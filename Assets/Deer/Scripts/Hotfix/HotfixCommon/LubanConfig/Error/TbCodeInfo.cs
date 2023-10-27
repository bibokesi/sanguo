//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;
using System.Collections.Generic;


namespace cfg.Error
{
   
public partial class TbCodeInfo
{
    private readonly Dictionary<Error.EErrorCode, Error.CodeInfo> _dataMap;
    private readonly List<Error.CodeInfo> _dataList;
    
    public TbCodeInfo(ByteBuf _buf)
    {
        _dataMap = new Dictionary<Error.EErrorCode, Error.CodeInfo>();
        _dataList = new List<Error.CodeInfo>();
        
        for(int n = _buf.ReadSize() ; n > 0 ; --n)
        {
            Error.CodeInfo _v;
            _v = Error.CodeInfo.DeserializeCodeInfo(_buf);
            _dataList.Add(_v);
            _dataMap.Add(_v.Code, _v);
        }
        PostInit();
    }

    public Dictionary<Error.EErrorCode, Error.CodeInfo> DataMap => _dataMap;
    public List<Error.CodeInfo> DataList => _dataList;

    public Error.CodeInfo GetOrDefault(Error.EErrorCode key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Error.CodeInfo Get(Error.EErrorCode key) => _dataMap[key];
    public Error.CodeInfo this[Error.EErrorCode key] => _dataMap[key];

    public void Resolve(Dictionary<string, object> _tables)
    {
        foreach(var v in _dataList)
        {
            v.Resolve(_tables);
        }
        PostResolve();
    }

    public void TranslateText(System.Func<string, string, string> translator)
    {
        foreach(var v in _dataList)
        {
            v.TranslateText(translator);
        }
    }
    
    partial void PostInit();
    partial void PostResolve();
}

}