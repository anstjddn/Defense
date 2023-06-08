using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUI : BaseUI
{
    public Transform FollowTarget;
    public Vector2 FollowOffset;            // ������

    private void LateUpdate()       //ī�޶�ó�� ���߿� ���󰡰�
    { 
        if(FollowTarget != null)
        {
            transform.position = Camera.main.WorldToScreenPoint(FollowTarget.position) + (Vector3)FollowOffset;
                                    //���ӿ����� ��ũ�� ��ġ
                                    // ui�� ���ӿ����� ��ġ������ �޶� ��ȯ�ѹ�������Ѵ�.

        }
    }

    public void SetTarget(Transform target)
    {
        this.FollowTarget = target;
    }
    public void SetOffest(Vector2 offset)
    {
        this.FollowOffset = offset;
        if (FollowTarget != null)
        {
            transform.position = Camera.main.WorldToScreenPoint(FollowTarget.position) + (Vector3)FollowOffset;
        }
    }
}
