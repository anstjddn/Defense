using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingSceneUI : SceneUI
{
    protected override void Awake()
    {
        base.Awake();
        buttons["infoButton"].onClick.AddListener(() => OpeninfoWindowUI());
        buttons["settingButton"].onClick.AddListener(() =>  OpenPausePopUp());
    }
    public void OpeninfoWindowUI()
    {
        GameManager.UI.ShowWindowUI("UI/infoWindow");
    }

    public void OpenPausePopUp()
    {
        GameManager.UI.ShowPopUpUI("UI/SettingPopUpUI");

    }
 
}
