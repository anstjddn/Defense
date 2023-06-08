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
        ui.transform.SetParent(popUpCanvas.transform,false);    //true �ϸ� �����ڽ����� ���� ������� ��ġ�� ���� �̵��� �ϴµ�
                                                                // false�� �ϸ� ���ο����ϼ��ִ�.
                                                                //Ʈ������.setparent�� parent�� ������ظ��� ���̾���
        popUpStack.Push(ui);
        Time.timeScale = 0;     //�ð����߰�
        //�ֵ������� ��ν�Ƽ�� ��ŸŸ���� ������Ǵµ�?
        // �ִϸ������� �����ϵ�Ÿ���� �����ð�
        //�Ǿ� ui�� �������� ����

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
        // canvas�� ������������ ���� �������� �ִ°� ���� ���� ǥ�õȴ�.
        // ����Ƽ���� �ٸ������� windowUI�� ����Ʈ�� �����Ѵ�.
        // list���� �����ϰ� �ǵڿ� �߰��Ͽ� sortingoder�� �ϰų� ����������Ʈ ����Ѵ�.
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
