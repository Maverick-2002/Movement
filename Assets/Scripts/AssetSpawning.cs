using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class AssetSpawning : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        loadaddressables();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void loadaddressables()
    {
        Addressables.LoadAssetAsync<GameObject>("Player").Completed += OnPlayerLoaded;
    }
    private void OnPlayerLoaded(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<GameObject> obj)
    {
        Debug.Log(obj.Result.name);
        Instantiate (obj.Result);
    }
}
