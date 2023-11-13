using UnityEngine;

namespace HotfixBusiness.Data
{
    public class DataLevelInfoManager:Singleton<DataLevelInfoManager>,IUserInfoManager
    {
        public void OnInit()
        {
            Logger.Debug("DataLevelInfoManager:OnInit");
        }

        public void OnLeave()
        {
            Logger.Debug("DataLevelInfoManager:OnLeave");
        }

        public void OnUpdate()
        {
        }
    }
}