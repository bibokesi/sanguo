using UnityEditor;

namespace Fantasy.Core.Editor
{
    public class FantasySettings
    {
        [MenuItem("CustomTools/Fantasy/Fantasy Settings")]
        public static void OpenFantasySettings()
        {
            SettingsService.OpenProjectSettings("Project/Fantasy Settings");
        }
    }
}