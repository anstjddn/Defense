using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class infoSceneUI : SceneUI
{

    public TMP_Text HeartText;


    protected override void Awake()
    {
        base.Awake();
        texts["HeartText"].text = "20";
 
    }
}
