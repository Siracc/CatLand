using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDashboard : MonoBehaviour
{
    [SerializeField]  Text _displayName, _playerDisplayName, _email, _createdDate, _playerID;
    [SerializeField] RawImage _avatar;
    string _tempUrl;

     GetAccoundInfoController _getAccoundInfoController = new GetAccoundInfoController();

    private void Awake()
    {
        _getAccoundInfoController.AccountInfo();
    }

    private void Start()
    {
        StartCoroutine(AsyncDashboard());

    }

    private IEnumerator AsyncDashboard()
    {
 
        yield return new WaitUntil(() => _getAccoundInfoController.GetAccoundInfoController_Async);
        PlayersInfos();       
        StartCoroutine(_getAccoundInfoController.DownloadAvatar(_tempUrl, _avatar));
        yield return new WaitUntil(() => _getAccoundInfoController.GetDownloadAvatarTexture_Async);
        
    }

    private void PlayersInfos()
    {
        _displayName.text = _getAccoundInfoController.DisplayName;
        _playerDisplayName.text = _getAccoundInfoController.DisplayName;
        _email.text = _getAccoundInfoController.Email;
        _createdDate.text = _getAccoundInfoController.CreatedDate.ToShortDateString();
        _playerID.text = _getAccoundInfoController.PlayerID;
        _tempUrl = _getAccoundInfoController.AvatarURL;
       
    }
}
