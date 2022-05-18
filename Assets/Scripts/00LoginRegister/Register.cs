using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class Register : MonoBehaviour
{

    InputController _inputController;
    RegisterBase _registerBase;
    GetDefaultAvatar _getDefautAvatar;

    [SerializeField] InputField _usernameField, _emailField, _passwordField, _repeatPasswordField;
    [SerializeField] GameObject _asncPanel;
    [SerializeField] Text _asncText;
    [SerializeField] Button _registerButton;

    [Header("Default Avatar")]
    public string _imageSize = "250", _avatarURL;


    private void Awake()
    {
        _inputController = new InputController();
        _registerBase = new RegisterBase();
        _getDefautAvatar = new GetDefaultAvatar();
    }

    public void RegisterPanelControl()
    {
        _inputController.RegisterPanel(_usernameField, _emailField, _passwordField, _repeatPasswordField, _registerButton);
    }

    public void RegisterOnClick()
    {
        PlayFabClientAPI.RegisterPlayFabUser(new RegisterPlayFabUserRequest()
        {
            Username = _usernameField.text,
            Email = _emailField.text,
            Password = _passwordField.text,
            DisplayName = _usernameField.text

        },
        Result =>
        {
            Debug.Log("Kayýt Baþarýlý");
        },
        Error =>
        {
            Debug.Log("Kayýt Baþarýsýz");
        });
    }

    IEnumerator AsncRegister()
    {
        _asncPanel.SetActive(true);
        _registerBase.RegisterEmail(_usernameField.text, _emailField.text, _passwordField.text);
        yield return new WaitUntil(() => _registerBase.RegisterBase_Async);
        _asncText.text = "Avatar Setting";
        _getDefautAvatar.GetDefaultAvatarImage(_avatarURL, _imageSize);
        yield return new WaitUntil(() => _getDefautAvatar.GetDefaultAvatarImage_Async);
        _asncText.text = "Login";
    }         
}
