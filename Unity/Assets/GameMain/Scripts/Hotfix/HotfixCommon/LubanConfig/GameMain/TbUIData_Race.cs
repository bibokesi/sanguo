//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;
using System.Collections.Generic;


namespace cfg.GameMain
{
   
public partial class TbUIData_Race
{
    private readonly Dictionary<int, GameMain.UIData_Race> _dataMap;
    private readonly List<GameMain.UIData_Race> _dataList;
    
    public TbUIData_Race(ByteBuf _buf)
    {
        _dataMap = new Dictionary<int, GameMain.UIData_Race>();
        _dataList = new List<GameMain.UIData_Race>();
        
        for(int n = _buf.ReadSize() ; n > 0 ; --n)
        {
            GameMain.UIData_Race _v;
            _v = GameMain.UIData_Race.DeserializeUIData_Race(_buf);
            _dataList.Add(_v);
            _dataMap.Add(_v.Id, _v);
        }
        PostInit();
    }

    public Dictionary<int, GameMain.UIData_Race> DataMap => _dataMap;
    public List<GameMain.UIData_Race> DataList => _dataList;

    public GameMain.UIData_Race GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public GameMain.UIData_Race Get(int key) => _dataMap[key];
    public GameMain.UIData_Race this[int key] => _dataMap[key];

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