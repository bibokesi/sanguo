using UnityEditor;

public static class CustomSettings
{
    [MenuItem("CustomTools/CustomSettings/Framework Settings", priority = 100)]
    public static void OpenFrameworkSettings() => SettingsService.OpenProjectSettings("GameMain/FrameworkSettings");

    [MenuItem("CustomTools/CustomSettings/HybridCLR Settings", priority = 110)]
    public static void OpenHybridCLRSettings() => SettingsService.OpenProjectSettings("GameMain/HybridCLRSettings");

    [MenuItem("CustomTools/CustomSettings/CustomPath Settings", priority = 120)]
    public static void OpenCustomPathSettings() => SettingsService.OpenProjectSettings("GameMain/CustomPathSetting");

    [MenuItem("CustomTools/CustomSettings/AutoBind Setting", priority = 130)]
    public static void OpenAutoBindSettings() => SettingsService.OpenProjectSettings("GameMain/AutoBindSetting");

    //[MenuItem("CustomTools/CustomSettings/ConsoleWindowFilter Toolbar", priority = 200)]
    //public static void OpenConsoleWindowFilterToolbar() => SettingsService.OpenProjectSettings("GameMain/ConsoleWindowFilterToolbar");
}