using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class GetDefaultAvatar 
{
    public bool GetDefaultAvatarImage_Async { get; set; }

    public void GetDefaultAvatarImage(string _currentAvatarURL, string _imagesize)
    {
        _currentAvatarURL = _currentAvatarURL + _imagesize;

        PlayFabClientAPI.UpdateAvatarUrl(new UpdateAvatarUrlRequest() 
        { 
            ImageUrl = _currentAvatarURL 
        }, 
        Result => 
        {
            GetDefaultAvatarImage_Async = true;
        }, 
        Error => 
        { 
            Debug.Log(Error.ErrorMessage); 
            GetDefaultAvatarImage_Async = false; 
        });
    }
}
