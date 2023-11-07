using System.Collections.Generic;


/// <summary>
/// 游戏常量类
/// </summary>
public static partial class Constant
{
    public class ProcedureInfo
    {
        public string ProcedureName { get; }

        public bool IsCheckAsset { get; }

        public bool IsJumpScene { get; }

        public string GroupName { get; }

        public string SceneName { get; }

        public ProcedureInfo(string procedureName, bool isCheck, bool isJumpScene, string groupName, string sceneName)
        {
            ProcedureName = procedureName;
            IsCheckAsset = isCheck;
            IsJumpScene = isJumpScene;
            GroupName = groupName;
            SceneName = sceneName;            
        }
    }

    /// <summary>
    /// 游戏流程
    /// </summary>
    public static class Procedure
    {
        public const string ProcedureReset = "HotfixBusiness.Procedure.ProcedureReset";
        public const string ProcedureLogin = "HotfixBusiness.Procedure.ProcedureLogin";
        public const string ProcedureMain = "HotfixBusiness.Procedure.ProcedureMain";
        public const string ProcedureFight = "HotfixBusiness.Procedure.ProcedureFight";

        private static Dictionary<string, ProcedureInfo> ProcedureInfos = new Dictionary<string, ProcedureInfo>()
        {
            {ProcedureLogin,new ProcedureInfo(ProcedureLogin,true,true,"BaseAssets","Login")},
            {ProcedureMain,new ProcedureInfo(ProcedureMain,true,true,"BaseAssets","Main")},
            {ProcedureFight,new ProcedureInfo(ProcedureFight,true,true,"BaseAssets","Fight")},
        };

        public static bool IsJumpScene(string procedureName)
        {
            if (ProcedureInfos.ContainsKey(procedureName))
            {
                var  info = ProcedureInfos[procedureName];
                return info.IsJumpScene;
            }
            return false;
        }

        public static bool IsCheckAsset(string procedureName)
        {
            if (ProcedureInfos.ContainsKey(procedureName))
            {
                var  info = ProcedureInfos[procedureName];
                return info.IsCheckAsset;
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
