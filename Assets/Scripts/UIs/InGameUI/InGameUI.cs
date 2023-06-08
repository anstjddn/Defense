using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUI : BaseUI
{
    public Transform FollowTarget;
    public Vector2 FollowOffset;            // 조정값

    private void LateUpdate()       //카메라처럼 나중에 따라가게
    { 
        if(FollowTarget != null)
        {
            transform.position = Camera.main.WorldToScreenPoint(FollowTarget.position) + (Vector3)FollowOffset;
                                    //게임월드의 스크린 위치
                                    // ui랑 게임월드의 위치단위가 달라서 변환한번해줘야한다.

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
