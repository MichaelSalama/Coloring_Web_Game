using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class AssetBundleManager : MonoBehaviour
{
    public IntVariable sketchNumber;
    public List<string> assetBundleNames;
    

    // Use this for initialization
    void Start()
    {
        
    }

    IEnumerator InstantiateObject()
    {
        string uri = "file:///" + Application.dataPath + "/AssetBundles/" + assetBundleNames[sketchNumber.value]+".txt";
        UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(uri, 0);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        else
        {
            AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);


            var ob = bundle.LoadAsset<GameObject>(assetBundleNames[sketchNumber.value]+".prefab");
            Instantiate(ob);
        }
      
    }
}
