using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Networking;

public class ImageLoader : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public bool ApplyOnStart = true;
    public string uri = "https://example.com/path/to/your/image.png";

    private void Start()
    {
        if (ApplyOnStart)
        {
            ApplyUri();
        }
    }

    [Button]
    public void ApplyUri()
    {
        StartCoroutine(FetchAndApplyTexture(uri));
    }

    private IEnumerator FetchAndApplyTexture(string uri)
    {
        UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(uri);

        // Send the request and wait for it to complete
        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            // Get the downloaded texture
            Texture2D downloadedTexture = DownloadHandlerTexture.GetContent(webRequest);

            // Assign the texture to the material
            if (meshRenderer != null)
            {
                meshRenderer.material.mainTexture = downloadedTexture;
            }
            else
            {
                Debug.LogError("MeshRenderer is not assigned.");
            }
        }
        else
        {
            Debug.LogError($"Error downloading image: {webRequest.error}");
        }

        // Dispose of the web request
        webRequest.Dispose();
    }
}
