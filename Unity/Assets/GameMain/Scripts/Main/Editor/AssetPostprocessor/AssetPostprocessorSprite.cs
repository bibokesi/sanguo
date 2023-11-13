using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;

public class AssetPostprocessorSprite : AssetPostprocessor
{
    void OnPreprocessTexture()
    {
        //自动设置类型;
        TextureImporter textureImporter = (TextureImporter)assetImporter;
        string dirName = Path.GetDirectoryName(assetPath);
        string atlasName = Path.GetFileNameWithoutExtension(assetPath);
        string folderStr = Path.GetFileName(dirName);
        if (assetPath.Contains("Assets/GameMain/BaseAssets/UI/Texture"))
        {
            textureImporter.textureType = TextureImporterType.Default;
            textureImporter.mipmapEnabled = false;
            textureImporter.alphaIsTransparency = true;
        }
        else if (assetPath.Contains("Assets/GameMain/BaseAssets/UI/Sprite"))
        {
            textureImporter.textureType = TextureImporterType.Sprite;
            textureImporter.maxTextureSize = 512;
            textureImporter.mipmapEnabled = false;
            textureImporter.alphaIsTransparency = true;
        }
    }
}