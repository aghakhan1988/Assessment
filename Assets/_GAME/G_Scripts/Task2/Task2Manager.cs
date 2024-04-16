using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TigerForge;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;

public class Task2Manager : MonoBehaviour
{
    [Header("Cameras")]
    public GameObject StartCamera;
    public GameObject PlayCamera;
    [Header("UI Objects")]
    public RectTransform PauseButton;
    public RectTransform PausePanel;
    public List<RectTransform> Objectives;
    public RectTransform ScoresPanel;
    public List<int> ObjectiveStatus;
    public Slider Healthbar;
    public int Coins;
    public TextMeshProUGUI CoinsTxt;
    public GameObject Celebrations;
    //
    public int ObjectiveCount;
    public RectTransform FinihsedToaster;
    public RectTransform NextButton;
    void Start()
    {
        InitiateUI();
        EventManager.StartListening("Goal", FirstObjectiveFinished);
        EventManager.StartListening("Heart", SecondObjectiveFinished);
        EventManager.StartListening("GotHit", ThirdObjectiveFinished);
        EventManager.StartListening("Coin", FourthObjectiveFinished);
        //
        EventManager.StartListening("GotHit", ReduceHealth);
        EventManager.StartListening("Coin", CollectedCoin);
        EventManager.StartListening("Heart", CollectedHealth);
        EventManager.StartListening("Goal", GoalMade);
    }
    public void InitiateUI()
    {
        PauseButton.DORotate(new Vector3(0, 0, 0), 0.5f, RotateMode.Fast).SetEase(Ease.OutBounce).SetDelay(.5f).OnComplete(() => PlayCamera.gameObject.SetActive(true));
        Objectives[0].DORotate(new Vector3(0, 0, 0), 0.5f, RotateMode.Fast).SetEase(Ease.OutBounce).SetDelay(1.5f);
        Objectives[1].DORotate(new Vector3(0, 0, 0), 0.5f, RotateMode.Fast).SetEase(Ease.OutBounce).SetDelay(1.5f);
        Objectives[2].DORotate(new Vector3(0, 0, 0), 0.5f, RotateMode.Fast).SetEase(Ease.OutBounce).SetDelay(1.5f);
        Objectives[3].DORotate(new Vector3(0, 0, 0), 0.5f, RotateMode.Fast).SetEase(Ease.OutBounce).SetDelay(1.5f);
        ScoresPanel.DORotate(new Vector3(0, 0, 0), 0.5f, RotateMode.Fast).SetEase(Ease.OutBounce).SetDelay(1.5f);
    }
    public void FirstObjectiveFinished()
    {
        if (ObjectiveStatus[0] == 1)
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
    public void ThirdObjectiveFinished()
    {
        if (ObjectiveStatus[2] == 1)
        {
            ObjectiveStatus[2] = 0;
            Objectives[2].GetChild(0).GetComponent<Image>().color = Color.green;
            //PlaySound
            ObjectiveCount++;
            ObjectiveCounter();
        }
    }
    public void FourthObjectiveFinished()
    {
        if (ObjectiveStatus[3] == 1)
        {
            ObjectiveStatus[3] = 0;
            Objectives[3].GetChild(0).GetComponent<Image>().color = Color.green;
            //PlaySound
            ObjectiveCount++;
            ObjectiveCounter();
        }
    }
    public void ReduceHealth()
    {
        Healthbar.value -= 0.1f;
        if (Healthbar.value <= 0)
        {
            EventManager.EmitEvent("GameOver");
        }
    }
    public void CollectedHealth()
    {
        Healthbar.value += 0.1f;
    }
    public void CollectedCoin()
    {
        Coins++;
        CoinsTxt.text = Coins.ToString();
    }
    public void GoalMade()
    {
        Celebrations.gameObject.SetActive(true);
    }

    public void ObjectiveCounter()
    {
        if (ObjectiveCount == Objectives.Count)
        {
            FinihsedToaster.DOAnchorPosY(0, 0.25f, false).SetEase(Ease.OutBounce).SetDelay(1.0f);
            NextButton.DOAnchorPosY(200, 0.25f, false).SetEase(Ease.OutBounce).SetDelay(2.0f);
        }
    }
    public void NextScene()
    {
        SceneManager.LoadScene("1_MainMenu");
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
