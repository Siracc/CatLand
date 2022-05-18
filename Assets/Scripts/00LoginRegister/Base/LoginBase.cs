using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;

public class LoginBase
{
    public bool LoginBase_Async { get; set; }

    public void LoginUsername(string _username, string _password)
    {
        PlayFabClientAPI.LoginWithPlayFab(new LoginWithPlayFabRequest
        {
            Username = _username,
            Password = _password,
        },
        result =>
        {
            LoginBase_Async = true;
        },
        error =>
        {
            LoginBase_Async = false;
            SceneManager.LoadScene(0);
            Debug.Log(error.ErrorMessage);
        });
    }
}