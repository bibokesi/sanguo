using Fantasy.Helper;
#pragma warning disable CS8603

namespace Fantasy.Hotfix;


public static class AssemblyHelper
{
    public static void Initialize()
    {
        LoadHotfix();
    }

    public static void LoadHotfix()
    {
        AssemblyManager.Load(AssemblyName.Hotfix, typeof(AssemblyHelper).Assembly);
    }
}