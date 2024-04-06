using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab.ClientModels;
using TMPro;
using PlayFab;

public class AuthenticatePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }
    public void OnError(PlayFabError error)
    {
        Debug.Log($"Error {error.ErrorMessage} -- {error.HttpCode}");
    }
}
