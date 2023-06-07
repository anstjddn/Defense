using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    private EventSystem eventSystem;

    private Canvas popUpCanvas;

    private Stack<PopUpUI> popUpStack;
    private void Awake()
    {
        eventSystem = GameManager.Resource.Instantiate<EventSystem>("UI/EventSystem");
        eventSystem.transform.parent = transform;

        popUpCanvas = GameManager.Resource.Instantiate<Canvas>("UI/Canvas");
        popUpCanvas.gameObject.name = "PopUpCanvas";
        popUpCanvas.sortingOrder = 100;
        popUpStack = new Stack<PopUpUI>();
    }

    public PopUpUI ShowPopUpUI(PopUpUI popUpUI)
    {
        if (popUpStack.Count > 0)
        {
            PopUpUI prevUI = popUpStack.Peek();
            prevUI.gameObject.SetActive(false);


        }

        PopUpUI ui = GameManager.Pool.GetUI(popUpUI);
        ui.transform.SetParent(popUpCanvas.transform,false);    //true 하면 하위자식으로 들어갈때 상대적인 위치에 따른 이동을 하는데
                                                                // false를 하면 따로움직일수있다.
                                                                //트랜스폼.setparent랑 parent랑 월드기준말고 차이없음
        popUpStack.Push(ui);
        Time.timeScale = 0;     //시간멈추게
        //애드포스랑 밸로시티는 델타타입은 안적어도되는듯?
        // 애니메이터의 언스케일드타입은 실제시간
        //판업 ui는 스택으로 구현

        return ui;
    }

    public PopUpUI ShowPopUpUI(string path)
    {
        PopUpUI ui = GameManager.Resource.Load<PopUpUI>(path);
        ShowPopUpUI(ui);
        return ui;
    }
    public void ClosePopUpUI()
    {
        PopUpUI ui = popUpStack.Pop();
        GameManager.Pool.ReleaseUI(ui.gameObject);

        if (popUpStack.Count > 0)
        {
            PopUpUI curUI = popUpStack.Peek();
            curUI.gameObject.SetActive(true);
        }
        if(popUpStack.Count == 0)
        {
            Time.timeScale = 1f;
        }
    }
}
