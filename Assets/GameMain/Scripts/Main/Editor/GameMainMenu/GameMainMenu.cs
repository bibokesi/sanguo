using UnityEditor;

public static class GameMainMenu
{
    [MenuItem("GameMainTools/Settings/GameMain Global Settings", priority = 100)]
    public static void OpenGameMainSettings() => SettingsService.OpenProjectSettings("GameMain/GameMainGlobalSettings");
    [MenuItem("GameMainTools/Settings/GameMain HybridCLR Settings", priority = 110)]
    public static void OpenGameMainHybridSettings() => SettingsService.OpenProjectSettings("GameMain/GameMainHybridSettings");
    [MenuItem("GameMainTools/Settings/Path Settings", priority = 120)]
    public static void OpenGameMainPathSettings() => SettingsService.OpenProjectSettings("GameMain/GameMainPathSetting");
    [MenuItem("GameMainTools/Settings/Auto Bind Global Setting", priority = 200)]
    public static void OpenAutoBindGlobalSettings() => SettingsService.OpenProjectSettings("GameMain/AutoBindGlobalSetting");
    [MenuItem("GameMainTools/Settings/Console Window Filter Toolbar", priority = 300)]
    public static void OpenConsoleWindowFilterToolbar() => SettingsService.OpenProjectSettings("GameMain/ConsoleWindowFilterToolbar");
}