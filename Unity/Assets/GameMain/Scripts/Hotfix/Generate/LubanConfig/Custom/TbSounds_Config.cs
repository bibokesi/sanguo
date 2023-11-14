//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;
using System.Collections.Generic;


namespace cfg.Custom
{
   
public partial class TbSounds_Config
{
    private readonly Dictionary<int, Custom.Sounds_Config> _dataMap;
    private readonly List<Custom.Sounds_Config> _dataList;
    
    public TbSounds_Config(ByteBuf _buf)
    {
        _dataMap = new Dictionary<int, Custom.Sounds_Config>();
        _dataList = new List<Custom.Sounds_Config>();
        
        for(int n = _buf.ReadSize() ; n > 0 ; --n)
        {
            Custom.Sounds_Config _v;
            _v = Custom.Sounds_Config.DeserializeSounds_Config(_buf);
            _dataList.Add(_v);
            _dataMap.Add(_v.Id, _v);
        }
        PostInit();
    }

    public Dictionary<int, Custom.Sounds_Config> DataMap => _dataMap;
    public List<Custom.Sounds_Config> DataList => _dataList;

    public Custom.Sounds_Config GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Custom.Sounds_Config Get(int key) => _dataMap[key];
    public Custom.Sounds_Config this[int key] => _dataMap[key];

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