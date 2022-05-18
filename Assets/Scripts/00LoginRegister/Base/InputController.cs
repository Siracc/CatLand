using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;


public class InputController 
{

    public void RegisterPanel(InputField _username, InputField _email, InputField _password, InputField _repeatPassword, Button _registerButton)
    {
        if (_email.text.IndexOf("@") < 0 || _email.text.IndexOf(".") < 0 || _password.text != _repeatPassword.text || _password.text.Length < 6 || _username.text.Length < 7)
        {
            _registerButton.interactable = false;
        }
        else
        {
            _registerButton.interactable = true;
        }

        _username.text = Regex.Replace(_username.text, "[^\\w\\._]", "");
        _username.text = Regex.Replace(_username.text, "[ç, ý, ü, ð, ö, þ, Ý, Ð, Ü, Ö, Þ, Ç,.]", "");
        _password.text = Regex.Replace(_password.text, "[ç, ý, ü, ð, ö, þ, Ý, Ð, Ü, Ö, Þ, Ç]", "");
        _repeatPassword.text = Regex.Replace(_repeatPassword.text, "[ç, ý, ü, ð, ö, þ, Ý, Ð, Ü, Ö, Þ, Ç]", "");
    }


    public void LoginPanel(InputField _username, InputField _password, Button _loginButton)
    {
        if (_username.text.IndexOf("@") < 0 || _username.text.IndexOf(".") < 0 || _password.text.Length < 6)
        {
            _loginButton.interactable = false;
        }
        else
        {
            _loginButton.interactable = true;
        }

        _password.text = Regex.Replace(_password.text, "[ç, ý, ü, ð, ö, þ, Ý, Ð, Ü, Ö, Þ, Ç]", "");
    }
}
