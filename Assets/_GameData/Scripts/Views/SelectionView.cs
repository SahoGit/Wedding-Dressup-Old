using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SelectionView : MonoBehaviour
{

    #region Variables, Constants & Initializers
    public GameObject loadingBG;
    public GameObject gamePlay;

    public GameObject weddingButton, superStarButton;
    public GameObject weddingMultiplayer, fashionMultiplayer;

    public GameObject weddingPanel, fashionPanel, lockPanel, challengePanel, careerModePanel;
    public Button ChallengeBtn;

    public Text lockText;


    public GameObject Player2Pic;
    public Sprite[] Player2Images;
    public GameObject ChallengePic;
    public Sprite[] ChallengeImages;
    public int ImageNumber;

    public ScrollRect carrerModeScroll;
    public ScrollRect ModeScroll;
    public Image[] lockImageMode;
    public Text watchPanelText;
    public Text WatchAdCountText;
    public Text CoinText;

    public int[] wathcAdCounter;
    public int[] ModeAmount;

    public Text cashText;
    public GameObject CashPanel;
    public GameObject[] Outline;

    private int challengPlayed;

    public GameObject ModeButtonsScoll;
    #endregion

    #region Lifecycle Methods

    // Use this for initialization
    void Start()
    {
       // ModeButtonsScoll.gameObject.GetComponent<Animation>().Play();
        SoundManager.instance.PlayGPSound(0);
        //Debug.Log(GameManager.instance.selectedHair);
        GameManager.instance.selectedHair = null;
        GameManager.instance.selectedEarRing = null;
        //loadingBG.SetActive(true);
        gamePlay.SetActive(false);
        //Invoke("afterLoading", 4.0f);
        afterLoading();

        if (PlayerPrefs.GetInt("CareerMode") == 1)
        {
            loadingBG.SetActive(false);
        }
        else
        {
            loadingBG.SetActive(true);
            Invoke("afterLoading", 4.0f);
        }

        //PlayerPrefs.SetInt("WeddingSingleUnlock", 0);
        //PlayerPrefs.SetInt("WeddingMultiUnlock", 0);
        //PlayerPrefs.SetInt("FashionSingleUnlock", 0);
        //PlayerPrefs.SetInt("FashionMultiUnlock", 0);
        //PlayerPrefs.SetInt("ChallengeUnlock", 0);
        //PlayerPrefs.SetInt("UnlimitedUnlock", 0);

        //PlayerPrefs.SetInt("WeddingMode", 1);
        //PlayerPrefs.SetInt("FashionMode", 1);
        //PlayerPrefs.SetInt("ChallengeMode", 1);
        //PlayerPrefs.SetInt("UnlimitedMode", 1);
        //for (int i = 0; i < lockImageMode.length; i++)
        //{
        //    lockImageMode[3].gameObject.SetActive(false);
        //}

    }

    

    void afterLoading()
    {
        PlayerPrefs.SetInt("first", 1);
        loadingBG.SetActive(false);
        gamePlay.SetActive(true);
        outlineShow();
        cashText.text = FormatNumber(PlayerPrefs.GetInt("PlayerCash")).ToString();
        allLevelUnlock();
        //PlayerPrefs.SetInt("PlayerCash", 28000);
        //PlayerPrefs.SetInt("LevelPlayed", 29);
        scrollSetting();
        modeScrollSetting();
        //PlayerPrefs.SetInt("playedLevel", 5);
        if (PlayerPrefs.GetInt("CareerMode") == 1)
        {
            //careerModePanel.SetActive(false);
            careerModePanel.SetActive(true);
            Debug.Log("careeModePanel check true or False???????" + careerModePanel);
        }
        if (PlayerPrefs.GetInt("WeddingSingleUnlock") == 1 || PlayerPrefs.GetInt("LevelPlayed") >= 30)
        {
            lockImageMode[0].gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("WeddingMultiUnlock") == 1 || PlayerPrefs.GetInt("playedLevel") >= 1)
        {
            lockImageMode[1].gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("FashionSingleUnlock") == 1 || PlayerPrefs.GetInt("playedLevel") >= 2)
        {
            lockImageMode[2].gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("FashionMultiUnlock") == 1 || PlayerPrefs.GetInt("playedLevel") >= 3)
        {
            lockImageMode[3].gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("ChallengeUnlock") == 1 || PlayerPrefs.GetInt("playedLevel") >= 4)
        {
            lockImageMode[4].gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("UnlimitedUnlock") == 1)
        {
            lockImageMode[5].gameObject.SetActive(false);
        }
    }

    void outlineShow()
    {
        for (int i = 0; i < Outline.Length; i++)
        {
            Outline[i].SetActive(false);
        }
        if (PlayerPrefs.GetInt("CareerMode") == 1)
        {
            Outline[0].SetActive(true);
        }
        else
        {
            Outline[0].SetActive(false);
        }
        if (PlayerPrefs.GetInt("WeddingMode") == 1)
        {
            Outline[1].SetActive(true);
        }
        else
        {
            Outline[1].SetActive(false);
        }
        if (PlayerPrefs.GetInt("WeddingMultiMode") == 1)
        {
            Outline[2].SetActive(true);
        }
        else
        {
            Outline[2].SetActive(false);
        }
        if (PlayerPrefs.GetInt("FashionMode") == 1)
        {
            Outline[3].SetActive(true);
        }
        else
        {
            Outline[3].SetActive(false);
        }
        if (PlayerPrefs.GetInt("FashionMultiMode") == 1)
        {
            Outline[4].SetActive(true);
        }
        else
        {
            Outline[4].SetActive(false);
        }
        if (PlayerPrefs.GetInt("ChallengeMode") == 1)
        {
            Outline[5].SetActive(true);
        }
        else
        {
            Outline[5].SetActive(false);
        }
        if (PlayerPrefs.GetInt("UnlimitedMode") == 1)
        {
            Outline[6].SetActive(true);
        }
        else
        {
            Outline[6].SetActive(false);
        }
    }
    void allLevelUnlock()
    {
        PlayerPrefs.SetInt("WeddingSingleUnlock", 1);
        PlayerPrefs.SetInt("WeddingMultiUnlock", 1);
        PlayerPrefs.SetInt("FashionSingleUnlock", 1);
        PlayerPrefs.SetInt("FashionMultiUnlock", 1);
        PlayerPrefs.SetInt("ChallengeUnlock", 1);
        PlayerPrefs.SetInt("UnlimitedUnlock", 1);

       
    }

    void modeScrollSetting()
    {
        if (PlayerPrefs.GetInt("CareerMode") == 1)
        {
            ModeScroll.normalizedPosition = new Vector2(0, 1.0f);
        }
        if (PlayerPrefs.GetInt("WeddingMode") == 1)
        {
            ModeScroll.normalizedPosition = new Vector2(0, 0.80f);
        }
        if (PlayerPrefs.GetInt("WeddingMultiMode") == 1)
        {
            ModeScroll.normalizedPosition = new Vector2(0, 0.60f);
        }
        if (PlayerPrefs.GetInt("FashionMode") == 1)
        {
            ModeScroll.normalizedPosition = new Vector2(0, 0.4f);
        }
        if (PlayerPrefs.GetInt("FashionMultiMode") == 1)
        {
            ModeScroll.normalizedPosition = new Vector2(0, 0.4f);
        }
        if (PlayerPrefs.GetInt("ChallengeMode") == 1)
        {
            ModeScroll.normalizedPosition = new Vector2(0, 0.2f);
        }
        if (PlayerPrefs.GetInt("UnlimitedMode") == 1)
        {
            ModeScroll.normalizedPosition = new Vector2(0, 0.0f);
        }
    }

    void scrollSetting()
    {
        if (PlayerPrefs.GetInt("LevelPlayed") <= 2)
        {
            carrerModeScroll.normalizedPosition = new Vector2(0, 1.0f);
        }
        if (PlayerPrefs.GetInt("LevelPlayed") >= 3 && PlayerPrefs.GetInt("LevelPlayed") <= 5)
        {
            carrerModeScroll.normalizedPosition = new Vector2(0, 0.79f);
        }
        if (PlayerPrefs.GetInt("LevelPlayed") >= 6 && PlayerPrefs.GetInt("LevelPlayed") <= 8)
        {
            carrerModeScroll.normalizedPosition = new Vector2(0, 0.59f);
        }
        if (PlayerPrefs.GetInt("LevelPlayed") >= 9 && PlayerPrefs.GetInt("LevelPlayed") <= 11)
        {
            carrerModeScroll.normalizedPosition = new Vector2(0, 0.38f);
        }
        if (PlayerPrefs.GetInt("LevelPlayed") >= 12 && PlayerPrefs.GetInt("LevelPlayed") <= 14)
        {
            carrerModeScroll.normalizedPosition = new Vector2(0, 0.18f);
        }
        if (PlayerPrefs.GetInt("LevelPlayed") >= 15 && PlayerPrefs.GetInt("LevelPlayed") <= 17)
        {
            carrerModeScroll.normalizedPosition = new Vector2(0, 0.0f);
        }
        if (PlayerPrefs.GetInt("LevelPlayed") >= 18 && PlayerPrefs.GetInt("LevelPlayed") <= 20)
        {
            carrerModeScroll.normalizedPosition = new Vector2(0, 0.0f);
        }
        if (PlayerPrefs.GetInt("LevelPlayed") >= 21 && PlayerPrefs.GetInt("LevelPlayed") <= 23)
        {
            carrerModeScroll.normalizedPosition = new Vector2(0, 0.0f);
        }
        if (PlayerPrefs.GetInt("LevelPlayed") >= 24 && PlayerPrefs.GetInt("LevelPlayed") <= 26)
        {
            carrerModeScroll.normalizedPosition = new Vector2(0, 0.0f);
        }
        if (PlayerPrefs.GetInt("LevelPlayed") >= 27 && PlayerPrefs.GetInt("LevelPlayed") <= 29)
        {
            carrerModeScroll.normalizedPosition = new Vector2(0, 0.0f);
        }
    }

    void Destroy()
    {
        iTween.Stop();
    }
    #endregion

    #region Callback Methods

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

    private void RotateAction(GameObject obj, float rotationAmout, float time, iTween.EaseType actionType)
    {
        Hashtable tweenParams = new Hashtable();
        tweenParams.Add("z", rotationAmout);
        tweenParams.Add("time", time);
        tweenParams.Add("easetype", actionType);
        iTween.RotateTo(obj, tweenParams);
    }

    #endregion

    #region Callback Method
    public void OnWeddingButtonClicked()
    {
        SoundManager.instance.PlayButtonClickSound();
        if (PlayerPrefs.GetInt("WeddingSingleUnlock") == 1)
        {
            weddingButton.GetComponent<Button>().enabled = false;
            superStarButton.GetComponent<Button>().enabled = false;
            weddingPanel.SetActive(true);
        }
        else
        {
            lockPanel.SetActive(true);
        }
        //light1.SetActive(false);
        //light2.SetActive(false);
    }

    public void gotoWeddingScene(int playerMode)
    {
        SoundManager.instance.PlayButtonClickSound();
        PlayerPrefs.SetInt("CareerMode", 0);
        PlayerPrefs.SetInt("WeddingMode", 1);
        PlayerPrefs.SetInt("WeddingMultiMode", 0);
        PlayerPrefs.SetInt("FashionMode", 0);
        PlayerPrefs.SetInt("FashionMultiMode", 0);
        PlayerPrefs.SetInt("ChallengeMode", 0);
        PlayerPrefs.SetInt("UnlimitedMode", 0);
        outlineShow();
         PlayerPrefs.SetInt("playerMode", playerMode);
         NavigationManager.instance.ReplaceScene(GameScene.MAKEUP);
        // if (PlayerPrefs.GetInt("WeddingSingleUnlock") == 0 || PlayerPrefs.GetInt("LevelPlayed") >= 30)
        // {
        //     PlayerPrefs.SetInt("playerMode", playerMode);
        //     NavigationManager.instance.ReplaceScene(GameScene.MAKEUP);
        // }
        // else
        // {
        //     watchPanelText.text = "Unlock by watching video or by cash";
        //     WatchAdCountText.text = "WatchAd " + PlayerPrefs.GetInt("WeddingSingleUnlockCounter") + "/" + wathcAdCounter[0].ToString();
        //     CoinText.text = ModeAmount[0].ToString();
        //     lockPanel.SetActive(true);
        // }
    }

    public void gotoWeddingMultiScene(int playerMode)
    {
        SoundManager.instance.PlayButtonClickSound();
        PlayerPrefs.SetInt("CareerMode", 0);
        PlayerPrefs.SetInt("WeddingMode", 0);
        PlayerPrefs.SetInt("WeddingMultiMode", 1);
        PlayerPrefs.SetInt("FashionMode", 0);
        PlayerPrefs.SetInt("FashionMultiMode", 0);
        PlayerPrefs.SetInt("ChallengeMode", 0);
        PlayerPrefs.SetInt("UnlimitedMode", 0);
        outlineShow();
         PlayerPrefs.SetInt("playerMode", playerMode);
        NavigationManager.instance.ReplaceScene(GameScene.MAKEUP);
        // if (PlayerPrefs.GetInt("WeddingMultiUnlock") == 0 || PlayerPrefs.GetInt("playedLevel") >= 1)
        // {
        //     PlayerPrefs.SetInt("playerMode", playerMode);
        //     NavigationManager.instance.ReplaceScene(GameScene.MAKEUP);
        // }
        // else
        // {
        //     watchPanelText.text = "Unlock by watching video or by cash";
        //     WatchAdCountText.text = "WatchAd " + PlayerPrefs.GetInt("WeddingMultiUnlockCounter") + "/" + wathcAdCounter[1].ToString();
        //     CoinText.text = ModeAmount[1].ToString();
        //     lockPanel.SetActive(true);
        // }
    }

    public void OnFashionButtonClicked()
    {
        SoundManager.instance.PlayButtonClickSound();
        if (PlayerPrefs.GetInt("playedLevel") >= 2)
        {
            weddingButton.GetComponent<Button>().enabled = false;
            superStarButton.GetComponent<Button>().enabled = false;
            fashionPanel.SetActive(true);
            //light1.SetActive(false);
            //light2.SetActive(false);
        } 
        else
        {
            lockText.text = "Please complete Wedding Mode first";
            lockPanel.SetActive(true);
            Invoke("lockPanelClose", 2.0f);
        }

    }

    void lockPanelClose()
    {
        SoundManager.instance.PlayButtonClickSound();
        lockPanel.SetActive(false);
    }

    public void gotoFashionScene(int playerMode)
    {
        SoundManager.instance.PlayButtonClickSound();
        PlayerPrefs.SetInt("CareerMode", 0);
        PlayerPrefs.SetInt("WeddingMode", 0);
        PlayerPrefs.SetInt("WeddingMultiMode", 0);
        PlayerPrefs.SetInt("FashionMode", 1);
        PlayerPrefs.SetInt("FashionMultiMode", 0);
        PlayerPrefs.SetInt("ChallengeMode", 0);
        PlayerPrefs.SetInt("UnlimitedMode", 0);
        outlineShow();
        PlayerPrefs.SetInt("playerMode", playerMode);
        NavigationManager.instance.ReplaceScene(GameScene.FASHIONMAKEUP);
        // if (PlayerPrefs.GetInt("FashionSingleUnlock") == 0 || PlayerPrefs.GetInt("playedLevel") >= 2)
        // {
        //     PlayerPrefs.SetInt("playerMode", playerMode);
        //     NavigationManager.instance.ReplaceScene(GameScene.FASHIONMAKEUP);
        // }
        // else
        // {
        //     watchPanelText.text = "Unlock by watching video or by cash";
        //     WatchAdCountText.text = "WatchAd " + PlayerPrefs.GetInt("FashionSingleUnlockCounter") + "/" + wathcAdCounter[2].ToString();
        //     CoinText.text = ModeAmount[2].ToString();
        //     lockPanel.SetActive(true);
        // }
    }

    public void gotoFashionMultiScene(int playerMode)
    {
        SoundManager.instance.PlayButtonClickSound();
        PlayerPrefs.SetInt("CareerMode", 0);
        PlayerPrefs.SetInt("WeddingMode", 0);
        PlayerPrefs.SetInt("WeddingMultiMode", 0);
        PlayerPrefs.SetInt("FashionMode", 0);
        PlayerPrefs.SetInt("FashionMultiMode", 1);
        PlayerPrefs.SetInt("ChallengeMode", 0);
        PlayerPrefs.SetInt("UnlimitedMode", 0);
        outlineShow();
        PlayerPrefs.SetInt("playerMode", playerMode);
         NavigationManager.instance.ReplaceScene(GameScene.FASHIONMAKEUP);
        // if (PlayerPrefs.GetInt("FashionMultiUnlock") == 0 || PlayerPrefs.GetInt("playedLevel") >= 3)
        // {
        //     PlayerPrefs.SetInt("playerMode", playerMode);
        //     NavigationManager.instance.ReplaceScene(GameScene.FASHIONMAKEUP);
        // }
        // else
        // {
        //     watchPanelText.text = "Unlock by watching video or by cash";
        //     WatchAdCountText.text = "WatchAd " + PlayerPrefs.GetInt("FashionMultiUnlockCounter") + "/" + wathcAdCounter[3].ToString();
        //     CoinText.text = ModeAmount[3].ToString(); 
        //     lockPanel.SetActive(true);
        // }
    }

    public void onclickBack()
    {
        SoundManager.instance.PlayButtonClickSound();
        NavigationManager.instance.ReplaceScene(GameScene.MAINMENU);
    }

    public void closePanel(GameObject parent)
    {
        SoundManager.instance.PlayButtonClickSound();
        weddingButton.GetComponent<Button>().enabled = true;
        superStarButton.GetComponent<Button>().enabled = true;
        //light1.SetActive(true);
        //light2.SetActive(true);
        parent.SetActive(false);
    }

    public void onChallengePanelClick()
    {
        PlayerPrefs.SetInt("CareerMode", 0);
        PlayerPrefs.SetInt("WeddingMode", 0);
        PlayerPrefs.SetInt("WeddingMultiMode", 0);
        PlayerPrefs.SetInt("FashionMode", 0);
        PlayerPrefs.SetInt("FashionMultiMode", 0);
        PlayerPrefs.SetInt("ChallengeMode", 1);
        PlayerPrefs.SetInt("UnlimitedMode", 0);
        outlineShow();
        SoundManager.instance.PlayButtonClickSound();
        challengePanel.SetActive(true);
            InvokeRepeating("Player2ImageShuffle", 1.0f, 0.1f);
            InvokeRepeating("ChallengeImageShuffle", 4.50f, 0.1f);
            Invoke("cancelImageShuffle", 3.0f);
            Invoke("cancelChallengeShuffle", 7.0f);
        // if (PlayerPrefs.GetInt("ChallengeUnlock") == 0)
        // {
        //     challengePanel.SetActive(true);
        //     InvokeRepeating("Player2ImageShuffle", 1.0f, 0.1f);
        //     InvokeRepeating("ChallengeImageShuffle", 4.50f, 0.1f);
        //     Invoke("cancelImageShuffle", 3.0f);
        //     Invoke("cancelChallengeShuffle", 7.0f);
        // }
        // else
        // {
        //     watchPanelText.text = "Unlock by watching video or by cash";
        //     WatchAdCountText.text = "WatchAd " + PlayerPrefs.GetInt("ChallengeUnlockCounter") + "/" + wathcAdCounter[4].ToString();
        //     CoinText.text = ModeAmount[4].ToString();
        //     lockPanel.SetActive(true);
        // }
    }

    public void OnclickBackButton(GameObject parent)
    {
        SoundManager.instance.PlayButtonClickSound();
        parent.SetActive(false);
    }

    public void onCareerModeClick()
    {
        SoundManager.instance.PlayButtonClickSound();
        PlayerPrefs.SetInt("CareerMode", 1);
        PlayerPrefs.SetInt("WeddingMode", 0);
        PlayerPrefs.SetInt("FashionMode", 0);
        PlayerPrefs.SetInt("ChallengeMode", 0);
        PlayerPrefs.SetInt("UnlimitedMode", 0);
        outlineShow();
        careerModePanel.SetActive(true);
    }

    public void onUnlimitedModeClick()
    {
        PlayerPrefs.SetInt("CareerMode", 0);
        PlayerPrefs.SetInt("WeddingMode", 0);
        PlayerPrefs.SetInt("WeddingMultiMode", 0);
        PlayerPrefs.SetInt("FashionMode", 0);
        PlayerPrefs.SetInt("FashionMultiMode", 0);
        PlayerPrefs.SetInt("ChallengeMode", 0);
        PlayerPrefs.SetInt("UnlimitedMode", 1);
        outlineShow();
        SoundManager.instance.PlayButtonClickSound();
           NavigationManager.instance.ReplaceScene(GameScene.CAREERMODEDRESSUP);
                PlayerPrefs.SetInt("MakeUpMode", 0);
        // if (PlayerPrefs.GetInt("UnlimitedUnlock") == 0)
        // {
        //     if (PlayerPrefs.GetInt("MakeUpMode") == 1)
        //     {
        //         NavigationManager.instance.ReplaceScene(GameScene.CAREERMODEDRESSUP);
        //         PlayerPrefs.SetInt("MakeUpMode", 0);
        //     }
        //     else
        //     {
        //         NavigationManager.instance.ReplaceScene(GameScene.CAREERMODEMAKEUP);
        //         PlayerPrefs.SetInt("MakeUpMode", 1);
        //     }
        // }
        // else
        // {
        //     watchPanelText.text = "Unlock by watching video or by cash";
        //     WatchAdCountText.text = "WatchAd " + PlayerPrefs.GetInt("UnlimitedUnlockCounter") + "/" + wathcAdCounter[5].ToString();
        //     CoinText.text = ModeAmount[5].ToString();
        //     lockPanel.SetActive(true);
        // }
    }

    void cancelImageShuffle()
    {
        CancelInvoke("Player2ImageShuffle");
        SoundManager.instance.PlayScoreAddSound();
        //ParticleManger.instance.ShowStarParticleForScore(Player2Pic.gameObject);
    }

    void Player2ImageShuffle()
    {
        int imageInt = Random.Range(0, Player2Images.Length - 1);
        ImageNumber = imageInt;
        Player2Pic.GetComponent<Image>().sprite = Player2Images[imageInt];
        SoundManager.instance.playPhotoFlip();

    }

    void cancelChallengeShuffle()
    {
        CancelInvoke("ChallengeImageShuffle");
        SoundManager.instance.PlayScoreAddSound();
        //ParticleManger.instance.ShowStarParticleForScore(ChallengePic.gameObject);
    }

    void ChallengeImageShuffle()
    {
        int imageInt = Random.Range(0, ChallengeImages.Length - 1);
        //ImageNumber = imageInt;
        ChallengePic.GetComponent<Image>().sprite = ChallengeImages[imageInt];
        challengPlayed = imageInt;
        SoundManager.instance.playPhotoFlip();

    }

    public void startChallenge()
    {
        SoundManager.instance.PlayButtonClickSound();
        PlayerPrefs.SetInt("isChallenge", 1);
        //PlayerPrefs.SetInt("PlayingLevelId", 2);
        PlayerPrefs.SetInt("playerMode", 1);
        if (challengPlayed == 0 || challengPlayed == 1)
        {
            NavigationManager.instance.ReplaceScene(GameScene.FASHIONMAKEUP);
        } else if (challengPlayed == 3 || challengPlayed == 3)
        {
            NavigationManager.instance.ReplaceScene(GameScene.MAKEUP);
        }
    }

    public void watchAdReward()
    {
        SoundManager.instance.PlayButtonClickSound();
        if (PlayerPrefs.GetInt("WeddingMode") == 1)
        {
            PlayerPrefs.SetInt("WeddingSingleUnlockCounter", PlayerPrefs.GetInt("WeddingSingleUnlockCounter") + 1);
            WatchAdCountText.text = "WatchAd " + PlayerPrefs.GetInt("WeddingSingleUnlockCounter") + "/" + wathcAdCounter[0].ToString();
            weddingSingleUnlockFun();
        }
        if (PlayerPrefs.GetInt("WeddingMultiMode") == 1)
        {
            PlayerPrefs.SetInt("WeddingMultiUnlockCounter", PlayerPrefs.GetInt("WeddingMultiUnlockCounter") + 1);
            WatchAdCountText.text = "WatchAd " + PlayerPrefs.GetInt("WeddingMultiUnlockCounter") + "/" + wathcAdCounter[1].ToString();
            weddingMultiUnlockFun();
        }
        if (PlayerPrefs.GetInt("FashionMode") == 1)
        {
            PlayerPrefs.SetInt("FashionSingleUnlockCounter", PlayerPrefs.GetInt("FashionSingleUnlockCounter") + 1);
            WatchAdCountText.text = "WatchAd " + PlayerPrefs.GetInt("FashionSingleUnlockCounter") + "/" + wathcAdCounter[2].ToString();
            fashionSingleUnlockFun();
        }
        if (PlayerPrefs.GetInt("FashionMultiMode") == 1)
        {
            PlayerPrefs.SetInt("FashionMultiUnlockCounter", PlayerPrefs.GetInt("FashionMultiUnlockCounter") + 1);
            WatchAdCountText.text = "WatchAd " + PlayerPrefs.GetInt("FashionMultiUnlockCounter") + "/" + wathcAdCounter[3].ToString();
            fashionMultiUnlockFun();
        }
        if (PlayerPrefs.GetInt("ChallengeMode") == 1)
        {
            PlayerPrefs.SetInt("ChallengeUnlockCounter", PlayerPrefs.GetInt("ChallengeUnlockCounter") + 1);
            WatchAdCountText.text = "WatchAd " + PlayerPrefs.GetInt("ChallengeUnlockCounter") + "/" + wathcAdCounter[4].ToString();
            challengeUnlockFun();
        }
        if (PlayerPrefs.GetInt("UnlimitedMode") == 1)
        {
            PlayerPrefs.SetInt("UnlimitedUnlockCounter", PlayerPrefs.GetInt("UnlimitedUnlockCounter") + 1);
            WatchAdCountText.text = "WatchAd " + PlayerPrefs.GetInt("UnlimitedUnlockCounter") + "/" + wathcAdCounter[5].ToString();
            unlimitedUnlockFun();
        }
    }

    void weddingSingleUnlockFun()
    {
        if (PlayerPrefs.GetInt("WeddingSingleUnlockCounter") == wathcAdCounter[0])
        {
            lockPanel.SetActive(false);
            PlayerPrefs.SetInt("WeddingSingleUnlock", 0);
            lockImageMode[0].gameObject.SetActive(false);
        }
    }

    void weddingMultiUnlockFun()
    {
        if (PlayerPrefs.GetInt("WeddingMultiUnlockCounter") == wathcAdCounter[1])
        {
            lockPanel.SetActive(false);
            PlayerPrefs.SetInt("WeddingMultiUnlock", 0);
            lockImageMode[1].gameObject.SetActive(false);
        }
    }

    void fashionSingleUnlockFun()
    {
        if (PlayerPrefs.GetInt("FashionSingleUnlockCounter") == wathcAdCounter[2])
        {
            lockPanel.SetActive(false);
            PlayerPrefs.SetInt("FashionSingleUnlock", 0);
            lockImageMode[2].gameObject.SetActive(false);
        }
    }

    void fashionMultiUnlockFun()
    {
        if (PlayerPrefs.GetInt("FashionMultiUnlockCounter") == wathcAdCounter[3])
        {
            lockPanel.SetActive(false);
            PlayerPrefs.SetInt("FashionMultiUnlock", 0);
            lockImageMode[3].gameObject.SetActive(false);
        }
    }

    void challengeUnlockFun()
    {
        if (PlayerPrefs.GetInt("ChallengeUnlockCounter") == wathcAdCounter[4])
        {
            lockPanel.SetActive(false);
            PlayerPrefs.SetInt("ChallengeUnlock", 0);
            lockImageMode[4].gameObject.SetActive(false);
        }
    }

    void unlimitedUnlockFun()
    {
        if (PlayerPrefs.GetInt("UnlimitedUnlockCounter") == wathcAdCounter[5])
        {
            lockPanel.SetActive(false);
            PlayerPrefs.SetInt("UnlimitedUnlock", 0);
            lockImageMode[5].gameObject.SetActive(false);
        }
    }

    public void PurchaseWithCash()
    {
        SoundManager.instance.PlayButtonClickSound();
        if (PlayerPrefs.GetInt("WeddingMode") == 1)
        {
            if (PlayerPrefs.GetInt("PlayerCash") >= ModeAmount[0])
            {
                PlayerPrefs.SetInt("PlayerCash", PlayerPrefs.GetInt("PlayerCash") - ModeAmount[0]);
                lockPanel.SetActive(false);
                PlayerPrefs.SetInt("WeddingSingleUnlock", 1);
                lockImageMode[0].gameObject.SetActive(false);
            }
            else
            {
                cashPanelShow();
            }
        }
        if (PlayerPrefs.GetInt("WeddingMultiMode") == 1)
        {
            if (PlayerPrefs.GetInt("PlayerCash") >= ModeAmount[1])
            {
                PlayerPrefs.SetInt("PlayerCash", PlayerPrefs.GetInt("PlayerCash") - ModeAmount[1]);
                lockPanel.SetActive(false);
                PlayerPrefs.SetInt("WeddingMultiUnlock", 1);
                lockImageMode[1].gameObject.SetActive(false);
            }
            else
            {
                cashPanelShow();
            }

        }
        if (PlayerPrefs.GetInt("FashionMode") == 1)
        {
            if (PlayerPrefs.GetInt("PlayerCash") >= ModeAmount[2])
            {
                PlayerPrefs.SetInt("PlayerCash", PlayerPrefs.GetInt("PlayerCash") - ModeAmount[2]);
                lockPanel.SetActive(false);
                PlayerPrefs.SetInt("FashionSingleUnlock", 1);
                lockImageMode[2].gameObject.SetActive(false);
            }
            else
            {
                cashPanelShow();
            }

        }
        if (PlayerPrefs.GetInt("FashionMultiMode") == 1)
        {
            if (PlayerPrefs.GetInt("PlayerCash") >= ModeAmount[3])
            {
                PlayerPrefs.SetInt("PlayerCash", PlayerPrefs.GetInt("PlayerCash") - ModeAmount[3]);
                lockPanel.SetActive(false);
                PlayerPrefs.SetInt("FashionMultiUnlock", 1);
                lockImageMode[3].gameObject.SetActive(false);
            }
            else
            {
                cashPanelShow();
            }

        }
        if (PlayerPrefs.GetInt("ChallengeMode") == 1)
        {
            if (PlayerPrefs.GetInt("PlayerCash") >= ModeAmount[4])
            {
                PlayerPrefs.SetInt("PlayerCash", PlayerPrefs.GetInt("PlayerCash") - ModeAmount[4]);
                lockPanel.SetActive(false);
                PlayerPrefs.SetInt("ChallengeUnlock", 1);
                lockImageMode[4].gameObject.SetActive(false);
            }
            else
            {
                cashPanelShow();
            }

        }
        if (PlayerPrefs.GetInt("UnlimitedMode") == 1)
        {
            if (PlayerPrefs.GetInt("PlayerCash") >= ModeAmount[5])
            {
                PlayerPrefs.SetInt("PlayerCash", PlayerPrefs.GetInt("PlayerCash") - ModeAmount[5]);
                lockPanel.SetActive(false);
                PlayerPrefs.SetInt("UnlimitedUnlock", 1);
                lockImageMode[5].gameObject.SetActive(false);
            }
            else
            {
                cashPanelShow();
            }

        }
        cashText.text = FormatNumber(PlayerPrefs.GetInt("PlayerCash")).ToString();
    }

    static string FormatNumber(long num)
    {
        if (num >= 100000000)
        {
            return (num / 1000000D).ToString("0.#M");
        }
        if (num >= 1000000)
        {
            return (num / 1000000D).ToString("0.##M");
        }
        if (num >= 100000)
        {
            return (num / 1000D).ToString("0.#k");
        }
        if (num >= 10000)
        {
            return (num / 1000D).ToString("0.##k");
        }

        return num.ToString("#,0");
    }

    public void cashPanelShow()
    {
        SoundManager.instance.PlayButtonClickSound();
        CashPanel.SetActive(true);
    }

    public void cashAdButton()
    {
        PlayerPrefs.SetInt("PlayerCash", PlayerPrefs.GetInt("PlayerCash") + 500);
        SoundManager.instance.PlayButtonClickSound();
        CashPanel.SetActive(false);
        SoundManager.instance.PlayScoreAddSound();
        cashText.text = FormatNumber(PlayerPrefs.GetInt("PlayerCash")).ToString();
        //AdCode Here
    }

    #endregion
}
