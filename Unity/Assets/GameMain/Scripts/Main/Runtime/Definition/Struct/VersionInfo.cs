using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Main.Runtime
{
    public class VersionInfo
    {
        public bool ForceUpdateGame;

        public string LatestGameVersion;

        public int InternalGameVersion;

        public int InternalResourceVersion;

        public string GameUpdateUrl;

        public int VersionListLength;

        public int VersionListHashCode;

        public int VersionListZipLength;

        public int VersionListZipHashCode;
    }
}