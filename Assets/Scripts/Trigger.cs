using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Trigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Portal"))
        {
            //Addressables.LoadAssetAsync<GameObject>("Room").Completed += OnRoomLoaded;
            Debug.Log("work");
        }
        else if (other.gameObject.CompareTag("SceneTrigger"))
        {
           // Addressables.LoadSceneAsync("Level1").Completed += OnLevelLoaded;
        }
    }
    private void OnLevelLoaded(AsyncOperationHandle<UnityEngine.ResourceManagement.ResourceProviders.SceneInstance> obj2)
    {

    }

    private void OnRoomLoaded(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<GameObject> obj3)
    {
        Debug.Log(obj3.Result.name);
        GameObject player = Instantiate(obj3.Result);
        player.transform.position = new Vector3(1.7294f, 3.296516f, -0.6211069f);
    }
}
