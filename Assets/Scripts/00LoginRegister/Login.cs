using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    InputController _inputController;
    LoginBase _loginBase;

    [SerializeField] InputField _usernameField, _passwordField;
    [SerializeField] Text _asyncText;
    [SerializeField] Button _loginButton;
    [SerializeField] GameObject _asyncPanel;

    private void Awake()
    {
        _inputController = new InputController();
        _loginBase = new LoginBase();
    }

    public void LoginOnClick()
    {
        StartCoroutine(AsyncLogin());      
    }

    public void LoginInput()
    {
        _inputController.LoginPanel(_usernameField, _passwordField, _loginButton);
    }

    IEnumerator AsyncLogin()
    {
        _asyncPanel.SetActive(true);
        _asyncText.text = "Login";
        _loginBase.LoginUsername(_usernameField.text, _passwordField.text);
        yield return new WaitUntil(() => _loginBase.LoginBase_Async);
        SceneManager.LoadScene(1);

    }
}
