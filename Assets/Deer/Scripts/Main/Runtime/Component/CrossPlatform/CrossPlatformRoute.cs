
public static class CrossPlatformRoute
{
    public static void openMapFromNative(object[] objects)
    {
        if (objects.Length >0 && objects[0] is string mapPath)
        {
            Logger.Debug("Native method called, opening map from path: " + mapPath);
        }
    }
}