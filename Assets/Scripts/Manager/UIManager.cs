using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    private EventSystem eventSystem;

    private Canvas popUpCanvas;
    private Canvas windowCanavs;

    private Canvas InGameCanvas;
    private Stack<PopUpUI> popUpStack;
    private void Awake()
    {
        eventSystem = GameManager.Resource.Instantiate<EventSystem>("UI/EventSystem");
        eventSystem.transform.parent = transform;

        popUpCanvas = GameManager.Resource.Instantiate<Canvas>("UI/Canvas");
        popUpCanvas.gameObject.name = "PopUpCanvas";
        popUpCanvas.sortingOrder = 100;
        popUpStack = new Stack<PopUpUI>();

        windowCanavs = GameManager.Resource.Instantiate<Canvas>("UI/Canvas");
        windowCanavs.gameObject.name = "WindowCanavs";
        windowCanavs.sortingOrder = 10;

        //gameSceneCanvas.soringorder =1;

        InGameCanvas = GameManager.Resource.Instantiate<Canvas>("UI/Canvas");
        InGameCanvas.gameObject.name = "InGameCanvas";
        InGameCanvas.sortingOrder = 0;
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
    public void ShowWindowUI(windowUI windowui)
    {
        windowUI ui = GameManager.Pool.GetUI(windowui);
        ui.transform.SetParent(windowCanavs.transform, false);
    }
    public void ShowWindowUI(string path)
    {
        windowUI ui = GameManager.Resource.Load<windowUI>(path);
        ShowWindowUI(ui);
    }
    public void CloseWindowUI(windowUI windowui)
    {
        GameManager.Pool.ReleaseUI(windowui.gameObject);
    }
    public void SelectWindowUI(windowUI windowui)
    {
        windowui.transform.SetAsLastSibling();
        // canvas는 계층구조에서 가장 마지막에 있는게 가장 위에 표시된다.
        // 유니티말고 다른엔진은 windowUI는 리스트로 구현한다.
        // list에서 삭제하고 맨뒤에 추가하여 sortingoder로 하거나 연결형리스트 사용한다.
    }

    public T ShowInGameUi<T>(T ingameUI) where T : InGameUI
    {
        T ui = GameManager.Pool.GetUI(ingameUI);
        ui.transform.SetParent(InGameCanvas.transform.transform, false);

        return ui;
    }
    public T ShowInGameUi<T>(string path) where T : InGameUI
    {
        T ui = GameManager.Resource.Load<T>(path);
        return ShowInGameUi(ui);
    
    }

    public void CloseInGameUi<T>(T ingameUI) where T : InGameUI
    {
        GameManager.Pool.ReleaseUI(ingameUI.gameObject);
    }
}
