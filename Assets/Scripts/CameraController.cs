using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] float zoomspeed;
    [SerializeField] float movespeed;

    [SerializeField] float padding;
    Vector2 moveDir;
    private float ZoomScroll;

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    private void LateUpdate()
    {
        Move();
        Zoom();
    }

    private void Move()
    {
        transform.Translate(Vector3.forward*moveDir.y *movespeed*Time.deltaTime, Space.World);
        transform.Translate(Vector3.right * moveDir.x * movespeed * Time.deltaTime, Space.World);
    }
    private void OnPointer(InputValue value)
    {
        Vector2 mousepos = value.Get<Vector2>();

        if (mousepos.x <= padding)
            moveDir.x = -1;
        else if (mousepos.x >= Screen.width - padding)
            moveDir.x = 1;
        else moveDir.x = 0;

        if (mousepos.y <= padding)
            moveDir.y = -1;
        else if (mousepos.y >= Screen.height - padding)
            moveDir.y = 1;
        else moveDir.y = 0;
    }

    private void Zoom()
    {
        transform.Translate(Vector3.forward*ZoomScroll* zoomspeed * Time.deltaTime, Space.Self);
    }

    private void OnZoom(InputValue value)
    {
        ZoomScroll  = value.Get<Vector2>().y;
      
    }
}
