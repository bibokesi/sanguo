using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HotfixBusiness.Data
{
    public class DataLoginInfoManager : Singleton<DataLoginInfoManager>,IUserInfoManager
    {
        private DataLoginInfoManager() { }
        public void OnInit()
        {
            Logger.Debug("DataLoginInfoManager:OnInit");
        }

        public void OnLeave()
        {
            Logger.Debug("DataLoginInfoManager:OnLeave");
        }

        public void OnUpdate()
        {
            
        }
    }
}