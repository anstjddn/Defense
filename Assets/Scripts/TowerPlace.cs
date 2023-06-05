using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.HID;
using UnityEngine.UIElements;

public class TowerPlace : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] Color normal;
    [SerializeField] Color OnMouse;
    [SerializeField] Color OnPlace;

    private Renderer render;
    private Transform prepoint;
    private void Awake()
    {
        prepoint = GetComponent<Transform>();
        render = GetComponent<Renderer>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("좌클릭");
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log("우클릭");
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        render.material.color = OnMouse;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        render.material.color = normal;
    }

    public void OnDrag(PointerEventData eventData)
    {
        render.material.color = OnMouse;
        transform.position += new Vector3(eventData.delta.x, 0, eventData.delta.y);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        render.material.color = normal;
    }
    public bool GroundCheck()
    {
        RaycastHit hit;

        return Physics.SphereCast(transform.position + Vector3.up * 1, 0.5f, Vector3.down, out hit, 0.6f);
    }


}

