using UnityEditor;

public static class CustomSettings
{
    [MenuItem("Others/CustomSettings/Framework Settings", priority = 100)]
    public static void OpenFrameworkSettings() => SettingsService.OpenProjectSettings("GameMain/FrameworkSettings");

    [MenuItem("Others/CustomSettings/HybridCLR Settings", priority = 110)]
    public static void OpenHybridCLRSettings() => SettingsService.OpenProjectSettings("GameMain/HybridCLRSettings");

    [MenuItem("Others/CustomSettings/CustomPath Settings", priority = 120)]
    public static void OpenCustomPathSettings() => SettingsService.OpenProjectSettings("GameMain/CustomPathSetting");

    [MenuItem("Others/CustomSettings/AutoBind Setting", priority = 130)]
    public static void OpenAutoBindSettings() => SettingsService.OpenProjectSettings("GameMain/AutoBindSetting");

    //[MenuItem("Others/CustomSettings/ConsoleWindowFilter Toolbar", priority = 200)]
    //public static void OpenConsoleWindowFilterToolbar() => SettingsService.OpenProjectSettings("GameMain/ConsoleWindowFilterToolbar");
}