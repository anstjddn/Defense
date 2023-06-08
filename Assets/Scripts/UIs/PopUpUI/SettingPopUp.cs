using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPopUp : PopUpUI
{
    protected override void Awake()
    {
        base.Awake();
        buttons["Contiue"].onClick.AddListener(() => { GameManager.UI.ClosePopUpUI(); }) ;
        buttons["Setting"].onClick.AddListener(() => { GameManager.UI.ShowPopUpUI("UI/ConfigPopUpUI"); });
    }
}
