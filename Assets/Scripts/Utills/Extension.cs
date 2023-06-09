using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class Extension 
{
   public static bool IsContain(this LayerMask layerMask,int layer)
    {
        return((1<<layer)& layerMask) !=0;   // 1을 레이어 숫자만큼 쉬프트 한다는 뜻임
    }
}
