using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePanel : MonoBehaviour
{
    [SerializeField] GameObject _changePanel;

    public void SwitchPanelOpenOnClick()
    {
        _changePanel.SetActive(true);
    }

    public void SwitchPanelCloseOnClick()
    {
        _changePanel.SetActive(false);
    }
}
