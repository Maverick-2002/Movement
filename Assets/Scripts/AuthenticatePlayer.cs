using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab.ClientModels;
using TMPro;
using PlayFab;
using UnityEditor;

public class AuthenticatePlayer : MonoBehaviour
{
    public PlayerProgress progress;
    public TMP_InputField emailid, password;
    public GameObject MenuPanel,login,NameChange,Welcome;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GUI_FetchData()
    {
        GetUserDataRequest request = new GetUserDataRequest()
        {
            Keys = new List<string>(){"Progress"}
        };

        PlayFabClientAPI.GetUserData(request, OnUserData, OnUserDataUpdateFailed);
    }
    private void OnUserData(GetUserDataResult result)
    {
        Debug.Log($"User Data Recieved");
        if(result.Data != null)
        {
            foreach(string key in result.Data.Keys)
            {
                Debug.Log($"User data Received {key} - {result.Data[key].Value}");
                if (key.Equals("Progress"))
                {
                    progress = JsonUtility.FromJson<PlayerProgress>(result.Data[key].Value);
                }
            }
        }
    }
    public void GUI_DataUpdate(TMP_InputField characterName)
    {
        PlayerProgress playerProgress = new PlayerProgress();
        playerProgress.DummyData();
        string progressData = JsonUtility.ToJson(playerProgress);
        UpdateUserDataRequest request = new UpdateUserDataRequest()
        {
            Data = new Dictionary<string, string>() { { "Character Name ",characterName.text },{"Progress", progressData } }
        };
        PlayFabClientAPI.UpdateUserData(request,OnUserDataUpdated, OnUserDataUpdateFailed);

    }
    public void GUI_Login(TMP_InputField displayname)
    {
        LoginWithCustomIDRequest request = new LoginWithCustomIDRequest()
        {
            CreateAccount = true,
            CustomId = displayname.text,
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnError);
    }
    public void OnLoginSuccess(LoginResult result)
    {
        Debug.Log($"Success {result.PlayFabId}");
        Welcome.SetActive(false);
        NameChange.SetActive(true);
    }
    public void OnError(PlayFabError error)
    {
        Debug.Log($"Error {error.ErrorMessage} -- {error.HttpCode}");
    }
    public void OnUserDataUpdateFailed(PlayFabError error)
    {
        Debug.Log("Data Update Error");
    }
    public void OnUserDataUpdated(UpdateUserDataResult result)
    {
        Debug.Log("Data Update Success");
    }
    
}
