using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class UpdateAvatar : MonoBehaviour
{
    [SerializeField] Text _avatarAtama;

    private void Start()
    {
        _avatarAtama.enabled = false;
    }
    public void UpdateAvatarOnClick()
    {
        PlayFabClientAPI.UpdateAvatarUrl(new UpdateAvatarUrlRequest()
        {
            ImageUrl = _avatarAtama.text
        },
        Success =>
        {
            SceneManager.LoadScene(1);
            Debug.Log("Avatar Güncellendi");
        },
        Error =>
        {
            Debug.Log("Avatar Güncellenirken hata oluþtu");
        });
    }



    public void Avatar1OnClick()
    {
        _avatarAtama.text = "https://www.gravatar.com/userimage/221184268/bc71db4b6df8353ec10794dcf99607b8?size=120";
    }

    public void Avatar2OnClick()
    {
        _avatarAtama.text = "https://www.gravatar.com/userimage/221184268/e60ecd19f7571197ea46d5138f23bdf5?size=120";
    }
}
