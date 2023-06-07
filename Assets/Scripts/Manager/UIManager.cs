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
}
