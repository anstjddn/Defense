using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class windowUI : BaseUI, IDragHandler, IPointerDownHandler
{

    protected override void Awake()
    {
        base.Awake();
        buttons["CloseButton"].onClick.AddListener(() => { GameManager.UI.CloseWindowUI(this); });
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position += (Vector3)eventData.delta;
            //µ¨Å¸-º¯È­·®
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        GameManager.UI.SelectWindowUI(this);
    }
}
