using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TigerForge;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Task1Manager : MonoBehaviour
{
    [Header("Cameras")]
    public GameObject StartCamera;
    public GameObject PlayCamera;
    [Header("UI Objects")]
    public RectTransform PauseButton;
    public RectTransform PausePanel;
    public List<RectTransform> Objectives;
    public List<int> ObjectiveStatus;
    public int ObjectiveCount;
    public RectTransform FinihsedToaster;
    public RectTransform NextButton;
    void Start()
    {
        InitiateUI();
        EventManager.StartListening("KeysPressed", FirstObjectiveFinished);
        EventManager.StartListening("ObjectPicked", SecondObjectiveFinished);
    }
    public void InitiateUI()
    {
        PauseButton.DORotate(new Vector3(0, 0, 0), 0.5f, RotateMode.Fast).SetEase(Ease.OutBounce).SetDelay(.5f).OnComplete(()=> PlayCamera.gameObject.SetActive(true));
        Objectives[0].DORotate(new Vector3(0, 0, 0), 0.5f, RotateMode.Fast).SetEase(Ease.OutBounce).SetDelay(1.5f);
        Objectives[1].DORotate(new Vector3(0, 0, 0), 0.5f, RotateMode.Fast).SetEase(Ease.OutBounce).SetDelay(1.5f);
    }
    public void FirstObjectiveFinished()
    {
        if(ObjectiveStatus[0] == 1)
        {
            ObjectiveStatus[0] = 0;
            Objectives[0].GetChild(0).GetComponent<Image>().color = Color.green;
            //PlaySound
            ObjectiveCount++;
            ObjectiveCounter();
        }
    }
    public void SecondObjectiveFinished()
    {
        if (ObjectiveStatus[1] == 1)
        {
            ObjectiveStatus[1] = 0;
            Objectives[1].GetChild(0).GetComponent<Image>().color = Color.green;
            //PlaySound
            ObjectiveCount++;
            ObjectiveCounter();
        }
    }
    public void ObjectiveCounter()
    {
        if(ObjectiveCount == Objectives.Count)
        {
            FinihsedToaster.DOAnchorPosY(0, 0.25f, false).SetEase(Ease.OutBounce).SetDelay(1.0f);
            NextButton.DOAnchorPosY(200, 0.25f, false).SetEase(Ease.OutBounce).SetDelay(2.0f);
        }
    }
    public void NextScene()
    {
        SceneManager.LoadScene("2_Task 2");
    }
    public void PausePanelOpen()
    {
        PausePanel.DOAnchorPosY(0, 0.25f, false).OnComplete(() => PausePanel.DOScale(new Vector3(1, 1, 1), 0.25f));
    }
    public void PausePanelClose()
    {
        PausePanel.DOScale(new Vector3(0, 1, 1), 0.25f).OnComplete(() => PausePanel.DOAnchorPosY(3000, 0.25f, false));
    }
    public void ReturnHome()
    {
        SceneManager.LoadScene("1_MainMenu");
    }
}
