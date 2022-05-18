using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterOrLogin : MonoBehaviour
{
    [SerializeField] GameObject _registerPanel, _loginPanel;


    public void RegisterLogin()
    {
        switch (_registerPanel.activeInHierarchy)
        {
            case true:
                _loginPanel.SetActive(true);
                _registerPanel.SetActive(false);
                break;
            default:
                _loginPanel.SetActive(false);
                _registerPanel.SetActive(true);
                break;
        }
    }
}
