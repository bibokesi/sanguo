using System.Collections.Generic;


/// <summary>
/// 游戏常量类
/// </summary>
public static partial class Const
{
    public class ProcedureInfo
    {
        public string ProcedureName { get; }

        public bool NeedCheckAsset { get; }

        public bool NeedChangeScene { get; }

        public string GroupName { get; }

        public string SceneName { get; }

        public ProcedureInfo(string procedureName, bool needCheck, bool needChangeScene, string groupName, string sceneName)
        {
            ProcedureName = procedureName;
            NeedCheckAsset = needCheck;
            NeedChangeScene = needChangeScene;
            GroupName = groupName;
            SceneName = sceneName;            
        }
    }

    public static class Procedure
    {
        public const string ProcedureExcessive = "ProcedureExcessive";
        public const string ProcedureLogin = "ProcedureLogin";
        public const string ProcedureMain = "ProcedureMain";
        public const string ProcedureFight = "ProcedureFight";

        private static Dictionary<string, ProcedureInfo> ProcedureInfos = new Dictionary<string, ProcedureInfo>()
        {
            {ProcedureLogin,new ProcedureInfo(ProcedureLogin,true,false,"BaseAssets","Login")},
            {ProcedureMain,new ProcedureInfo(ProcedureMain,true,true,"BaseAssets","Main")},
            {ProcedureFight,new ProcedureInfo(ProcedureFight,true,true,"BaseAssets","Fight")},
        };

        public static bool NeedChangeScene(string procedureName)
        {
            if (ProcedureInfos.ContainsKey(procedureName))
            {
                var  info = ProcedureInfos[procedureName];
                return info.NeedChangeScene;
            }
            return false;
        }

        public static bool NeedCheckAsset(string procedureName)
        {
            if (ProcedureInfos.ContainsKey(procedureName))
            {
                var  info = ProcedureInfos[procedureName];
                return info.NeedCheckAsset;
            }
            return false;
        }

        public static string FindAssetGroup(string procedureName)
        {
            if (ProcedureInfos.ContainsKey(procedureName))
            {
                var  info = ProcedureInfos[procedureName];
                return info.GroupName;
            }
            return string.Empty;
        }

        public static string FindSceneName(string procedureName)
        {
            if (ProcedureInfos.ContainsKey(procedureName))
            {
                var info = ProcedureInfos[procedureName];
                return info.SceneName;
            }
            return string.Empty;
        }
    }
}
