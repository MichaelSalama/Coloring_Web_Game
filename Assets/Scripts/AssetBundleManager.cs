using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Raskulls.Event;
public class AssetBundleManager : MonoBehaviour
{
    public IntVariable sketchNumber;
    public GameEvent onCompleteRequest;
    public GameEvent onFailedRequest;
    public ObjectVariable sketchPrefab;
    public List<string> assetBundleNames;

    Coroutine myCoroutine;
    AssetBundle bundle;
    // Use this for initialization
    void Start()
    {
        sketchPrefab.ReSetObject();
        myCoroutine = null;
    }

    IEnumerator GetAssetBundleObject()
    {
        
        string uri = Application.dataPath + "/AssetBundles/" + assetBundleNames[sketchNumber.value].ToLower()+".txt";
        UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(uri, 0);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
            onFailedRequest.Raise();
        }
        else
        {

            bundle = DownloadHandlerAssetBundle.GetContent(request);
            sketchPrefab.value = bundle.LoadAsset<GameObject>(assetBundleNames[sketchNumber.value]+".prefab");
            onCompleteRequest.Raise();
        }
      
    }

    public void GetAssetBundle()
    {
        if (myCoroutine != null)
        {
            StopCoroutine(myCoroutine);
            bundle.Unload(true);
        }
        myCoroutine = StartCoroutine(GetAssetBundleObject());
    }
}
