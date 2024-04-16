using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Loading Screen")]
    public TextMeshProUGUI GameName;
    public float LoadingTime;
    public Slider Loadingbar;
    public static bool LoadingPanelTrigger;
    public List<RectTransform> MenuButtons;
    public CanvasGroup LoadingPanel;
    public RectTransform ExitPanel;
    public RectTransform SettingsPanel;
    void Start()
    {
        LoadingPanelTrigger = true;
        LoadingScene();
    }

    public void LoadingScene()
    {
        if (LoadingPanelTrigger == true)
        {
            DOTween.To(() => GameName.alpha, x => GameName.alpha = x, 1, 3);
            GameName.rectTransform.DOAnchorPosY(0, 3, false);
            DOTween.To(() => Loadingbar.value, x => Loadingbar.value = x, 1, 5).OnComplete(() => DisplayMenu());
        }
        else if(LoadingPanelTrigger == false)
        {
            DisplayMenu();
        }
    }
    public void DisplayMenu()
    {
        float MyDelay = 1.5f;
        LoadingPanelTrigger = false;
        for(int i = 0; i < MenuButtons.Count; i++)
        {
            MenuButtons[i].DORotate(new Vector3(0, 0, 0), 0.5f, RotateMode.Fast).SetEase(Ease.OutBounce).SetDelay(MyDelay);
            MyDelay += 0.25f;
        }
        LoadingPanel.DOFade(0, 0.5f);
    }
    public void LoadTask1Scene()
    {
        SceneManager.LoadScene("2_Task 1");
    }
    public void LoadTask2Scene()
    {
        SceneManager.LoadScene("2_Task 2");
    }
    public void LoadTask3Scene()
    {
        SceneManager.LoadScene("2_Task 3");
    }
    public void SettingsOpen()
    {
        SettingsPanel.DOAnchorPosY(0, 0.25f, false).OnComplete(() => SettingsPanel.DOScale(new Vector3(1, 1, 1), 0.25f));
    }
    public void SettingsClose()
    {
        SettingsPanel.DOScale(new Vector3(0, 1, 1), 0.25f).OnComplete(() => SettingsPanel.DOAnchorPosY(3000, 0.25f, false));
    }
    public void ExitGameOpen()
    {
        ExitPanel.DOAnchorPosY(0, 0.25f, false).OnComplete(() =>
        ExitPanel.DOScale(new Vector3(1,1,1),0.25f)
        );
    }
    public void ExitAccept()
    {
        Application.Quit();
    }
    public void ExitReject()
    {
        ExitPanel.DOScale(new Vector3(0, 1, 1), 0.25f).OnComplete(() => ExitPanel.DOAnchorPosY(3000, 0.25f, false));
    }
}
