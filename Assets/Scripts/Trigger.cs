using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;

public class Trigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Portal"))
        {
            Addressables.LoadAssetAsync<GameObject>("Room").Completed += OnRoomLoaded;
        }
        else if (other.gameObject.CompareTag("SceneTrigger"))
        {
           Addressables.LoadSceneAsync("Level1").Completed += OnLevelLoaded;
        }
    }
    private void OnLevelLoaded(AsyncOperationHandle<UnityEngine.ResourceManagement.ResourceProviders.SceneInstance> obj2)
    {

    }

    private void OnRoomLoaded(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<GameObject> obj3)
    {
        Debug.Log(obj3.Result.name);
        GameObject player = Instantiate(obj3.Result);
        player.transform.position = new Vector3(-11.522f, -14.22f, 11.58f);
    }
}
