//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;
using System.Collections.Generic;


namespace cfg.Deer
{
   
public partial class TbUIData_GameMode
{
    private readonly Dictionary<int, Deer.UIData_GameMode> _dataMap;
    private readonly List<Deer.UIData_GameMode> _dataList;
    
    public TbUIData_GameMode(ByteBuf _buf)
    {
        _dataMap = new Dictionary<int, Deer.UIData_GameMode>();
        _dataList = new List<Deer.UIData_GameMode>();
        
        for(int n = _buf.ReadSize() ; n > 0 ; --n)
        {
            Deer.UIData_GameMode _v;
            _v = Deer.UIData_GameMode.DeserializeUIData_GameMode(_buf);
            _dataList.Add(_v);
            _dataMap.Add(_v.Id, _v);
        }
        PostInit();
    }

    public Dictionary<int, Deer.UIData_GameMode> DataMap => _dataMap;
    public List<Deer.UIData_GameMode> DataList => _dataList;

    public Deer.UIData_GameMode GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Deer.UIData_GameMode Get(int key) => _dataMap[key];
    public Deer.UIData_GameMode this[int key] => _dataMap[key];

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