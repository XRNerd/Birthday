using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class BirthdayData : MonoBehaviour
{
    [FoldoutGroup("Data")] public string name;

    [FoldoutGroup("Data")] public string[] imageUris;
    [FoldoutGroup("Data")] public bool loadOnStart = false;

    [FoldoutGroup("Dependancies")] public SuperTextMesh superTextMesh;
    [FoldoutGroup("Dependancies")] public List<ImageLoader> imageLoaders;



    private void OnValidate()
    {
        string[] oldImageUris = imageUris;
        imageUris = new string[imageLoaders.Count];

        for (int i = 0; i < imageLoaders.Count; i++)
        {
            if (i < oldImageUris.Length)
            {
                imageUris[i] = oldImageUris[i];
            }
            else
            {
                imageUris[i] = "https://example.com/path/to/your/image.png";
            }
        }
    }

    private void Start()
    {
        if (loadOnStart)
        {
            SetData();
        }
    }

    [Button]
    void SetData()
    {
        superTextMesh.text = "<c=rainbow><w>Happy Birthday " + name;
        foreach (ImageLoader imageLoader in imageLoaders)
        {
            imageLoader.uri = imageUris[imageLoaders.IndexOf(imageLoader)];
            imageLoader.ApplyUri();
        }
    }

}
