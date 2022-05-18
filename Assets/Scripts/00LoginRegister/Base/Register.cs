using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;

public class Register : MonoBehaviour
{

    InputController _inputController;
    RegisterBase _registerBase;
    GetDefaultAvatarImage _getDefaultAvatarImage;

    [SerializeField] InputField _usernameField, _emailField, _passwordField, _repeatPasswordField;
    [SerializeField] GameObject _asencPanel;
    [SerializeField] Text _asencText;
    [SerializeField] Button _registerButton;

    [Header("Default Avatar")]
    public string  _avatarURL;


    private void Awake()
    {
        _inputController = new InputController();
        _registerBase = new RegisterBase();
        _getDefaultAvatarImage = new GetDefaultAvatarImage();
    }

    public void RegisterInput()
    {
        _inputController.RegisterPanel(_usernameField, _emailField, _passwordField, _repeatPasswordField, _registerButton);
    }

    public void RegisterOnClick()
    {
        StartCoroutine(AsyncRegister());
    }

    IEnumerator AsyncRegister()
    {
        _asencPanel.SetActive(true);
        _registerBase.RegisterEmail(_usernameField.text, _emailField.text, _passwordField.text);
        yield return new WaitUntil(() => _registerBase.RegisterBase_Async);
        _asencText.text = "Avatar Setting";
        _getDefaultAvatarImage.GetDefaultAvatar(_avatarURL);
        yield return new WaitUntil(() => _getDefaultAvatarImage._isAvatarUploaded);
        SceneManager.LoadScene(1);
    }         
}
