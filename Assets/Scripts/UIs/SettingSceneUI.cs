using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingSceneUI : SceneUI
{
    protected override void Awake()
    {
        base.Awake();
        buttons["infoButton"].onClick.AddListener(() => Debug.Log("info"));
    }

 
}
