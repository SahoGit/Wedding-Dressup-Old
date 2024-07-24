using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeddingShootView : MonoBehaviour
{
    #region Variables, Constants & Initializers
    public GameObject loadingBG;
    public GameObject GamePlay;

    public GameObject loadingImage;
    private int bgCounter = 0;
    public Image weddingBg;
    public Sprite[] weddingSprites;
    public Sprite MultiplayerBg;
    public GameObject buttons;
    public RectTransform buttonsEndPoint;
    public GameObject bgButton, cameraButton;
    public GameObject frame;
    public GameObject character, characterStanding, characterPosition;
    public GameObject levelEndParticles;
    public GameObject finishPartical1;
    public GameObject finishPartical2;
    public GameObject finishPartical3;
    public GameObject finishPartical4;
    public GameObject finishPartical5;

    public GameObject PlayerScore;

    public GameObject AiCharacter;
    public GameObject WaitingForOpp;
    public Text WaitingText;

    public GameObject Judges;
    #endregion

    #region Lifecycle Methods

    // Use this for initialization
    void Start()
    {
        SoundManager.instance.PlayGPSound(1);
        loadingBG.SetActive(true);
        GamePlay.SetActive(false);
        Invoke("afterLoading", 4.0f);
    }

    void afterLoading()
    {
        loadingBG.SetActive(false);
        GamePlay.SetActive(true);
        Invoke("SetViewContents", 0.1f);
        if (PlayerPrefs.GetInt("playerMode") == 1)
        {
            weddingBg.sprite = MultiplayerBg;
            bgButton.GetComponent<Button>().interactable = false;
            cameraButton.GetComponent<Button>().interactable = false;
            AiCharacter.SetActive(false);
            WaitingForOpp.SetActive(true);
            bgButton.SetActive(false);
            cameraButton.SetActive(false);
            StartCoroutine(Countdown(3));
            Judges.SetActive(true);
            Invoke("buttonsEnable", 15.0f);
        } else
        {
            bgButton.GetComponent<Button>().interactable = false;
            cameraButton.GetComponent<Button>().interactable = false;
            AiCharacter.SetActive(false);
            PlayerScore.SetActive(false);
            WaitingForOpp.SetActive(false);
            Invoke("buttonsEnable", 0.1f);
        }
    }

    void buttonsEnable()
    {
        bgButton.GetComponent<Button>().interactable = true;
        cameraButton.GetComponent<Button>().interactable = true;
    }

    IEnumerator Countdown(int seconds)
    {
        int count = seconds;

        while (count > 0)
        {
            // display something...
            WaitingText.text = count.ToString();
            yield return new WaitForSeconds(1);
            count--;
        }

        // count down is finished...
        AiCharacterShow();
    }

    void AiCharacterShow()
    {
        AiCharacter.SetActive(true);
        WaitingForOpp.SetActive(false);
        //SoundManager.instance.PlaysparkleAchivementSound();

    }

    #endregion

    #region Callback Methods


    private void SetViewContents()
    {
        Invoke("loadingImageInactive", 3f);
        SettingCharacter();
       
    }

    private void SettingCharacter()
    {
        characterStanding = GameManager.instance.player.GetMakeup();
        characterStanding.transform.SetParent(character.transform);
        characterStanding.GetComponent<RectTransform>().localScale = new Vector3(0.6f, 0.6f, 0.6f);
        characterStanding.transform.SetSiblingIndex(0);
        if (PlayerPrefs.GetInt("playerMode") == 1)
        {
            characterStanding.GetComponent<RectTransform>().localPosition = new Vector3(0f, -17f, 0f);
        } else
        {
            characterStanding.GetComponent<RectTransform>().localPosition = new Vector3(236f, -103f, 0f);
        }
        characterStanding.SetActive(true);

    }

    private void MoveAction(GameObject obj, RectTransform pos, float time, iTween.EaseType type)
    {
        Hashtable tweenParams = new Hashtable();
        tweenParams.Add("x", pos.position.x);
        tweenParams.Add("y", pos.position.y);
        tweenParams.Add("time", time);
        tweenParams.Add("easetype", type);
        iTween.MoveTo(obj, tweenParams);
    }

    private void ScaleAction(GameObject obj, float ScaleFactor, float time, iTween.EaseType type, iTween.LoopType loop)
    {
        Hashtable tweenParams = new Hashtable();
        tweenParams.Add("scale", new Vector3(ScaleFactor, ScaleFactor, 0));
        tweenParams.Add("time", 0.5f);
        tweenParams.Add("looptype", loop);
        tweenParams.Add("easetype", type);
        iTween.ScaleTo(obj, tweenParams);
    }

    private void loadingImageInactive()
    {
        AdsManager.Instance.HideMREC();
        loadingImage.SetActive(false);
    }
    private void buttonComes()
    {
        levelEndParticles.SetActive(true);
        Invoke("DelayForSelectionScene", 3f);
    }

    void DelayForSelectionScene()
    {
        AdsManager.Instance.ShowInterstitial("callad");

        OnClickReplay();
    }

    #endregion


    #region Callback Method
    public void OnClickBgButton()
    {
      weddingBg.sprite = weddingSprites[bgCounter];
      bgCounter++;
      SoundManager.instance.PlayButtonClickSound();
      if (bgCounter > 4)
       {
         bgCounter = 0;
       }
    }

    public void OnClickCamera()
    {
        if (PlayerPrefs.GetInt("playedLevel") == 0)
        {
            PlayerPrefs.SetInt("playedLevel", 1);
        }
        else if (PlayerPrefs.GetInt("playedLevel") == 1)
        {
            PlayerPrefs.SetInt("playedLevel", 2);
        }
        else if (PlayerPrefs.GetInt("playedLevel") == 2)
        {
            PlayerPrefs.SetInt("playedLevel", 3);
        }
        SoundManager.instance.PlaycameraClickSound();
        SoundManager.instance.PlaysparkleAchivementSound();
        //SoundManager.instance.playEndSparkles();
        bgButton.SetActive(false);
        cameraButton.SetActive(false);
        //frame.SetActive(true);
        //ScaleAction(frame, 1.0f, 0.3f, iTween.EaseType.easeInBounce, iTween.LoopType.none);
        finishPartical1.SetActive(true);
        finishPartical2.SetActive(true);
        finishPartical3.SetActive(true);
        finishPartical4.SetActive(true);
        finishPartical5.SetActive(true);
        levelEndParticles.SetActive(true);
        PlayerPrefs.SetInt("PlayerCash", PlayerPrefs.GetInt("PlayerCash") + 500);
        Invoke("DelayForSelectionScene", 3f);
        //Invoke("buttonComes", 1.0f);
    }

    public void OnClickRateUs()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=" + Application.identifier);
    }

    public void OnClickrMoreGames()
    {
        Application.OpenURL("https://play.google.com/store/apps/developer?id=Petdragon+Inc");
    }

    public void OnClickReplay()
    {
        NavigationManager.instance.ReplaceScene(GameScene.SELECTIONVIEW);

    }

    public void reward2x()
    {
        if (PlayerPrefs.GetInt("ChallengeMode") == 1)
        {
            PlayerPrefs.SetInt("UnlimitedUnlock", 1);
        }
        if (PlayerPrefs.GetInt("playedLevel") == 0)
        {
            PlayerPrefs.SetInt("playedLevel", 1);
        }
        else if (PlayerPrefs.GetInt("playedLevel") == 1)
        {
            PlayerPrefs.SetInt("playedLevel", 2);
        }
        else if (PlayerPrefs.GetInt("playedLevel") == 2)
        {
            PlayerPrefs.SetInt("playedLevel", 3);
        }
        else if (PlayerPrefs.GetInt("playedLevel") == 3)
        {
            PlayerPrefs.SetInt("ChallengeUnlock", 1);
        }
        PlayerPrefs.SetInt("PlayerCash", PlayerPrefs.GetInt("PlayerCash") + 500);
        NavigationManager.instance.ReplaceScene(GameScene.SELECTIONVIEW);
    }

    #endregion
}
