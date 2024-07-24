using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Linq;
using System;
using DG.DemiLib;
using Random = UnityEngine.Random;
using DG.Tweening;
using System.CodeDom;

public class CareerModeMakeUp : MonoBehaviour
{

    #region Variables,Constants & Initializers

    //public static Func<int> GetRewardMultiplier;

    public GameObject loadingBG;

    public GameObject Player2Pic;

    public PaintTexture2D PaintingTexture;
    private int lastTag = 0;
    public GameObject loadingImage;
    public GameObject Character, CharacterParent, characterMakeup;
    public RectTransform CharacterEndPoint;
    public Image CharacterBody, CharacterEyes;
    public GameObject[] itemGrids;
    public string[] ObjectiveString;
    public RectTransform itemsGridStartPoint, itemsGridEndPoint;


    private bool flagBtnClick;
    private bool clickflag = true;
    private int[] NextArr;
    private int NextCount;
    private int LastClickGrid;
    public List<RectTransform> ItemsEndPoints;
    public List<GameObject> ScrollContentItems;
    public Image CurrentItem;
    public RectTransform CurrentItemStartPoint;
    public Image DrawMaskImage;
    public RectTransform DrawMaskImageEndPoint;
    public Image Hair, EarRing;
    public Image leftEyeLens, rightEyeLens;
    public Image leftEyeBrow, rightEyeBrow;
    public Image leftEyeLash, rightEyeLash;
    public GameObject Next;
    public GameObject levelCompletedParticles;
    public int counter = 0;
    public List<int> numbers;
    public GameObject noInternetConect;

    public GameObject GamePlay;
    public GameObject BattleAnimation;

    public Sprite[] Player2Images;

    public Sprite greenImage;

    //Item veriables
    public GameObject NothanksButton;
    public GameObject ClickedBtnRef;
    public GameObject LevelStartPanel;
    public GameObject LevelCompletePanel;
    public GameObject LowSelectItemPanel;
    public GameObject ItemPurchasePanel;
    public GameObject CashPanel;
    public Text ObjectiveTextTitle;
    public Text ObjectiveText;
    public Text ItemPurchaseText;
    public Text Amount;
    public Text ItemNameText;
    //Item veriables

    public Text cashTextLevelcomplete;
    public Text cashText;
    public Text RewardCashText;
    public int levelIndex;

    //public RectTransform leftPoint;
    //public RectTransform rightPoint;
    //public RectTransform moveObject;
    //public float moveSpeed = 4f;
    //private bool movingRight = true;

    public GameObject DimondMove;

    public int currentRewardMultiplier = 1;
    public int countCoin = 2;


    //public Slider RewardSlider;
    //public List<RewardSliderData> multiplierRewardValues;


    //public void MoveSlider()
    //{
    //    //RewardSlider.DOValue(5, 2).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
    //    //GetRewardMultiplier = GetRewardMuiliplier;
    //    RewardSlider.DOValue(RewardSlider.maxValue, 0.75f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
    //    var rewardMultiplierValue = multiplierRewardValues[(int)RewardSlider.value - 1];
    //}

    //[Serializable]
    //public class RewardSliderData
    //{
    //    public int rewardValue;
    //    public float sliderValue;
    //}


    //public int GetRewardMuiliplier()
    //{
    //    if((RewardSlider.value >=0 && RewardSlider.value<1 ) || (RewardSlider.value >= 4 && RewardSlider.value <= 5))
    //    {
    //        return 2;
    //    }

    //    else if ((RewardSlider.value >= 1 && RewardSlider.value <2 ) || (RewardSlider.value >= 3 && RewardSlider.value <= 4))
    //    {
    //        return 4;
    //    }

    //    else  if (RewardSlider.value >= 2 && RewardSlider.value <= 3)
    //    {
    //        return 6;
    //    }
    //    return -1;
    //}

    //public void Button_ClaimRewardMultiplier()
    //{
    //    RewardSlider.DOKill();
    //    var rewardMultiplierValue = multiplierRewardValues[(int)RewardSlider.value - 1];

    //    currentRewardMultiplier = rewardMultiplierValue.rewardValue;
    //    RewardSlider.wholeNumbers = false;
    //    currentRewardMultiplier = Mathf.RoundToInt(currentRewardMultiplier);

    //    RewardSlider.DOValue(rewardMultiplierValue.sliderValue, 0.1f);

    //    int finalCoinsToAdd = 0;
    //    finalCoinsToAdd = countCoin * currentRewardMultiplier;
    //    cashText.text = finalCoinsToAdd.ToString();

    //}


    #endregion

    #region Lifecycle Methods
    // Use this for initialization
    void Start()
    {
        SoundManager.instance.PlayGPSound(1);
        loadingBG.SetActive(true);
        GamePlay.SetActive(false);
        Invoke("afterLoading", 4.0f);

        //RewardCashText.text = FormatNumber(PlayerPrefs.GetInt("PlayerCash")).ToString();
        
    }

    
    void Update()
    {
        //RewardCashText.text = multiplierRewardValues[(int)RewardSlider.value - 1].rewardValue.ToString() + "x";
        // MoveObject();
    }

    

    //void MoveObject()
    //{
    //    if(LevelCompletePanel.activeInHierarchy != null)
    //    {
    //        float step = moveSpeed * Time.deltaTime;

    //        // Check if the object is moving right or left and move accordingly
    //        if (movingRight)
    //        {
    //            moveObject.position = Vector3.MoveTowards(moveObject.position, rightPoint.position, step);
    //            if (Vector3.Distance(moveObject.position, rightPoint.position) < 0.01f)
    //            {
    //                movingRight = false;
    //            }
    //        }
    //        else
    //        {
    //            moveObject.position = Vector3.MoveTowards(moveObject.position, leftPoint.position, step);
    //            if (Vector3.Distance(moveObject.position, leftPoint.position) < 0.01f)
    //            {
    //                movingRight = true;
    //            }
    //        }
    //    }
        
    //}

    void afterLoading()
    {
        loadingBG.SetActive(false);
        GamePlay.SetActive(true);
        if (PlayerPrefs.GetInt("LevelNumber") == 0)
        {
            PlayerPrefs.SetInt("LevelNumber", 1);
        }
        LevelStartPanel.SetActive(true);
        Character.SetActive(false);
        if (PlayerPrefs.GetInt("CareerMode") == 1)
        {
            levelIndex = PlayerPrefs.GetInt("careerLevelId");
            ObjectiveTextTitle.text = "Objective";
            ObjectiveText.text = ObjectiveString[levelIndex];
        } else
        {
            levelIndex = PlayerPrefs.GetInt("levelIndex");
            chooseRandom();
            ObjectiveTextTitle.text = "Level" + PlayerPrefs.GetInt("LevelNumber");
            ObjectiveText.text = ObjectiveString[levelIndex];
        }
        cashText.text = FormatNumber(PlayerPrefs.GetInt("PlayerCash")).ToString();

    }


    void chooseRandom()
    {
        levelIndex = Random.Range(0, itemGrids.Length);
        if (PlayerPrefs.GetInt("levelIndex") != levelIndex)
        {
            PlayerPrefs.SetInt("levelIndex", levelIndex);
        }
        else
        {
            chooseRandom();
        }
    }

    public void levelStart()
    {
        SoundManager.instance.PlayButtonClickSound();
        LevelStartPanel.SetActive(false);
        Character.SetActive(true);
        itemGrids[levelIndex].SetActive(true);
        itemGrids[levelIndex].GetComponent<RectTransform>().localPosition = itemsGridStartPoint.gameObject.GetComponent<RectTransform>().localPosition;
        MoveAction(itemGrids[levelIndex], itemsGridEndPoint, 0.3f, iTween.EaseType.linear);
        Invoke("SetViewContents", 0.2f);
        //AdsManager.Instance.ShowBanner();
    }

    void Destroy()
    {
        iTween.Stop();
    }

    #endregion

    #region Utility Methods

    private void SetViewContents()
    {
        GameManager.instance.currentScene = Utils.CURRENT_SCENE_MAKEUP;
        //Invoke("loadingImageInactive", 3f);
        //Character.SetActive(true);
        SoundManager.instance.playCharacterAppear();
        ParticleManger.instance.ShowStarParticle(CharacterParent.gameObject);
        LastClickGrid = 0;
        flagBtnClick = true;
        NextArr = new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0 };

        //SetCharacter (GameManager.instance.girlSelected);
    }

    private void ShowNext()
    {
        NextCount = 0;
        for (int i = 0; i < NextArr.Count(); i++)
        {

            if (NextArr[i] == 1)
            {
                NextCount++;
            }
        }
        if (NextCount == 7)
        {
            Next.SetActive(true);
        }
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


    private void ScaleAction(GameObject obj, float ScaleFactor, float time, iTween.EaseType type)
    {
        Hashtable tweenParams = new Hashtable();
        tweenParams.Add("scale", new Vector3(ScaleFactor, ScaleFactor, 0));
        tweenParams.Add("time", 0.5f);
        tweenParams.Add("easetype", type);
        iTween.ScaleTo(obj, tweenParams);
    }

    private void ScaleActionloop(GameObject obj, float ScaleFactor, float time, iTween.EaseType type, iTween.LoopType loop)
    {
        Hashtable tweenParams = new Hashtable();
        tweenParams.Add("scale", new Vector3(ScaleFactor, ScaleFactor, 0));
        tweenParams.Add("time", 0.5f);
        tweenParams.Add("easetype", type);
        tweenParams.Add("looptype", loop);
        iTween.ScaleTo(obj, tweenParams);

    }
    private void MoveActionloop(GameObject obj, RectTransform pos, float time, iTween.EaseType type, iTween.LoopType loop)
    {
        Hashtable tweenParams = new Hashtable();
        tweenParams.Add("x", pos.position.x);
        tweenParams.Add("y", pos.position.y);
        tweenParams.Add("time", time);
        tweenParams.Add("easetype", type);
        tweenParams.Add("looptype", loop);
        iTween.MoveTo(obj, tweenParams);
    }
    private void RotateAction(GameObject obj, float rotationAmout, float time, iTween.EaseType actionType)
    {
        Hashtable tweenParams = new Hashtable();
        tweenParams.Add("z", rotationAmout);
        tweenParams.Add("time", time);
        tweenParams.Add("easetype", actionType);
        iTween.RotateTo(obj, tweenParams);
    }

    private void loadingImageInactive()
    {
        AdsManager.Instance.HideMREC();
        loadingImage.SetActive(false);
    }


    #endregion

    #region Callback Methods

    void noInternetConectClose()
    {
        noInternetConect.SetActive(false);
    }
    public void OnClickItemsButtons(int tag)
    {
        SoundManager.instance.PlayButtonClickSound();
        if (lastTag != tag)
        {
            for (int i = 0; i < itemGrids.Length; i++)
            {
                itemGrids[i].SetActive(false);
                itemGrids[i].GetComponent<RectTransform>().localPosition = itemsGridStartPoint.gameObject.GetComponent<RectTransform>().localPosition;
            }
            itemGrids[tag].SetActive(true);
            MoveAction(itemGrids[tag], itemsGridEndPoint, 0.3f, iTween.EaseType.linear);
            lastTag = tag;
            counter++;
            //CallAds();
            CheckAllBtnsClicked(tag);
        }
    }

    public void btnClicked(GameObject btn)
    {
        SoundManager.instance.PlayButtonClickSound();
        btn.GetComponent<Image>().sprite = greenImage;
    }

    void CheckAllBtnsClicked(int value)
    {
        if (!numbers.Contains(value))
        {
            numbers.Add(value);
            if (numbers.Count == 6)
            {
                Next.SetActive(true);
            }
        }
    }

    void CallAds()
    {
        if (counter % 3 == 0)
        {
            print("Counter =" + counter);
            AdsManager.Instance.ShowInterstitial("CallAds");
        }
    }


    public void OnLensGirdClick(int tag)
    {
        GameObject clickedItem = EventSystem.current.currentSelectedGameObject;
        int itemId = clickedItem.GetComponent<ItemController>().id;
        bool itemLocked = clickedItem.GetComponent<ItemController>().isLocked;
        string itemName = clickedItem.GetComponent<ItemController>().name;
        int itemAmount = clickedItem.GetComponent<ItemController>().amount;
        string prefName = clickedItem.GetComponent<ItemController>().name + clickedItem.GetComponent<ItemController>().id;
        GameObject LockImage = clickedItem.transform.GetChild(0).gameObject;
        if (!itemLocked)
        {
            Next.SetActive(true);
            SoundManager.instance.PlayniceColorSound();
            ParticleManger.instance.ShowStarParticle(leftEyeLens.gameObject);
            ParticleManger.instance.ShowStarParticle(rightEyeLens.gameObject);
            GameManager.instance.CurrentDressupItem = GameManager.instance.lensDataList[tag] as BaseItem;
            GameManager.instance.selectedLens = GameManager.instance.lensDataList[tag] as BaseItem;
            CurrentItem.sprite = Resources.Load<Sprite>(GameManager.instance.CurrentDressupItem.getInGameImageName());
            leftEyeLens.sprite = Resources.Load<Sprite>(GameManager.instance.CurrentDressupItem.getInGameImageName());
            rightEyeLens.sprite = Resources.Load<Sprite>(GameManager.instance.CurrentDressupItem.getInGameImageName());
        }
        else
        {
            if (PlayerPrefs.GetInt("PlayerCash") >= itemAmount)
            {
                PlayerPrefs.SetInt("PlayerCash", PlayerPrefs.GetInt("PlayerCash") - itemAmount);
                PlayerPrefs.SetInt(prefName, 1);
                clickedItem.transform.GetChild(0).gameObject.SetActive(false);
                clickedItem.GetComponent<ItemController>().isLocked = false;
                SoundManager.instance.PlayScoreAddSound();
                cashText.text = FormatNumber(PlayerPrefs.GetInt("PlayerCash")).ToString();
            }
            else
            {
                SoundManager.instance.errorSound();
                CashPanel.SetActive(true);
            }

        }
    }

    public void OnHairSelected(int tag)
    {
        GameObject clickedItem = EventSystem.current.currentSelectedGameObject;
        int itemId = clickedItem.GetComponent<ItemController>().id;
        bool itemLocked = clickedItem.GetComponent<ItemController>().isLocked;
        string itemName = clickedItem.GetComponent<ItemController>().name;
        int itemAmount = clickedItem.GetComponent<ItemController>().amount;
        string prefName = clickedItem.GetComponent<ItemController>().name + clickedItem.GetComponent<ItemController>().id;
        GameObject LockImage = clickedItem.transform.GetChild(0).gameObject;
        if (!itemLocked)
        {
            Next.SetActive(true);
            SoundManager.instance.PlayhairSound();
            ParticleManger.instance.ShowStarParticle(Hair.gameObject);
            GameManager.instance.CurrentDressupItem = GameManager.instance.makeuphairDataList[tag] as BaseItem;
            GameManager.instance.selectedHair = GameManager.instance.makeuphairDataList[tag] as BaseItem;
            CurrentItem.sprite = Resources.Load<Sprite>(GameManager.instance.CurrentDressupItem.getInGameImageName());
            Hair.sprite = Resources.Load<Sprite>(GameManager.instance.CurrentDressupItem.getInGameImageName());
        }
        else
        {
            if (PlayerPrefs.GetInt("PlayerCash") >= itemAmount)
            {
                PlayerPrefs.SetInt("PlayerCash", PlayerPrefs.GetInt("PlayerCash") - itemAmount);
                PlayerPrefs.SetInt(prefName, 1);
                clickedItem.transform.GetChild(0).gameObject.SetActive(false);
                clickedItem.GetComponent<ItemController>().isLocked = false;
                SoundManager.instance.PlayScoreAddSound();
                cashText.text = FormatNumber(PlayerPrefs.GetInt("PlayerCash")).ToString();
            }
            else
            {
                SoundManager.instance.errorSound();
                CashPanel.SetActive(true);
            }
        }
    }

    public void OnEyeBrowSelected(int tag)
    {
        GameObject clickedItem = EventSystem.current.currentSelectedGameObject;
        int itemId = clickedItem.GetComponent<ItemController>().id;
        bool itemLocked = clickedItem.GetComponent<ItemController>().isLocked;
        string itemName = clickedItem.GetComponent<ItemController>().name;
        int itemAmount = clickedItem.GetComponent<ItemController>().amount;
        string prefName = clickedItem.GetComponent<ItemController>().name + clickedItem.GetComponent<ItemController>().id;
        GameObject LockImage = clickedItem.transform.GetChild(0).gameObject;
        if (!itemLocked)
        {
            Next.SetActive(true);
            SoundManager.instance.PlaysparkleClickSound();
            ParticleManger.instance.ShowStarParticle(leftEyeBrow.gameObject);
            ParticleManger.instance.ShowStarParticle(rightEyeBrow.gameObject);
            GameManager.instance.CurrentDressupItem = GameManager.instance.eyeBrowsDataList[tag] as BaseItem;
            GameManager.instance.selectedEyeBrow = GameManager.instance.eyeBrowsDataList[tag] as BaseItem;
            CurrentItem.sprite = Resources.Load<Sprite>(GameManager.instance.CurrentDressupItem.getInGameImageName());
            leftEyeBrow.sprite = Resources.Load<Sprite>(GameManager.instance.CurrentDressupItem.getInGameImageName());
            rightEyeBrow.sprite = Resources.Load<Sprite>(GameManager.instance.CurrentDressupItem.getInGameImageName());
        }
        else
        {
            if (PlayerPrefs.GetInt("PlayerCash") >= itemAmount)
            {
                PlayerPrefs.SetInt("PlayerCash", PlayerPrefs.GetInt("PlayerCash") - itemAmount);
                PlayerPrefs.SetInt(prefName, 1);
                clickedItem.transform.GetChild(0).gameObject.SetActive(false);
                clickedItem.GetComponent<ItemController>().isLocked = false;
                SoundManager.instance.PlayScoreAddSound();
                cashText.text = FormatNumber(PlayerPrefs.GetInt("PlayerCash")).ToString();
            }
            else
            {
                SoundManager.instance.errorSound();
                CashPanel.SetActive(true);
            }
        }
    }

    public void OnEyeLashSelected(int tag)
    {
        GameObject clickedItem = EventSystem.current.currentSelectedGameObject;
        int itemId = clickedItem.GetComponent<ItemController>().id;
        bool itemLocked = clickedItem.GetComponent<ItemController>().isLocked;
        string itemName = clickedItem.GetComponent<ItemController>().name;
        int itemAmount = clickedItem.GetComponent<ItemController>().amount;
        string prefName = clickedItem.GetComponent<ItemController>().name + clickedItem.GetComponent<ItemController>().id;
        GameObject LockImage = clickedItem.transform.GetChild(0).gameObject;
        if (!itemLocked)
        {
            Next.SetActive(true);
            SoundManager.instance.PlaysparkleClickSound();
            ParticleManger.instance.ShowStarParticle(leftEyeLash.gameObject);
            ParticleManger.instance.ShowStarParticle(rightEyeLash.gameObject);
            GameManager.instance.CurrentDressupItem = GameManager.instance.eyeLashesDataList[tag] as BaseItem;
            GameManager.instance.selectedEyeLash = GameManager.instance.eyeBrowsDataList[tag] as BaseItem;
            CurrentItem.sprite = Resources.Load<Sprite>(GameManager.instance.CurrentDressupItem.getInGameImageName());
            leftEyeLash.sprite = Resources.Load<Sprite>(GameManager.instance.CurrentDressupItem.getInGameImageName());
            rightEyeLash.sprite = Resources.Load<Sprite>(GameManager.instance.CurrentDressupItem.getInGameImageName());
        }
        else
        {
            if (PlayerPrefs.GetInt("PlayerCash") >= itemAmount)
            {
                PlayerPrefs.SetInt("PlayerCash", PlayerPrefs.GetInt("PlayerCash") - itemAmount);
                PlayerPrefs.SetInt(prefName, 1);
                clickedItem.transform.GetChild(0).gameObject.SetActive(false);
                clickedItem.GetComponent<ItemController>().isLocked = false;
                SoundManager.instance.PlayScoreAddSound();
                cashText.text = FormatNumber(PlayerPrefs.GetInt("PlayerCash")).ToString();
            }
            else
            {
                SoundManager.instance.errorSound();
                CashPanel.SetActive(true);
            }
        }

    }

    public void OnEarringSelected(int tag)
    {
        GameObject clickedItem = EventSystem.current.currentSelectedGameObject;
        int itemId = clickedItem.GetComponent<ItemController>().id;
        bool itemLocked = clickedItem.GetComponent<ItemController>().isLocked;
        string itemName = clickedItem.GetComponent<ItemController>().name;
        int itemAmount = clickedItem.GetComponent<ItemController>().amount;
        string prefName = clickedItem.GetComponent<ItemController>().name + clickedItem.GetComponent<ItemController>().id;
        GameObject LockImage = clickedItem.transform.GetChild(0).gameObject;
        if (!itemLocked)
        {
            Next.SetActive(true);
            SoundManager.instance.PlaysparkleClickSound();
            ParticleManger.instance.ShowStarParticle(EarRing.gameObject);
            GameManager.instance.CurrentDressupItem = GameManager.instance.earringDataList[tag] as BaseItem;
            GameManager.instance.selectedEarRing = GameManager.instance.earringDataList[tag] as BaseItem;
            CurrentItem.sprite = Resources.Load<Sprite>(GameManager.instance.CurrentDressupItem.getInGameImageName());
            EarRing.sprite = Resources.Load<Sprite>(GameManager.instance.CurrentDressupItem.getInGameImageName());
        }
        else
        {
            if (PlayerPrefs.GetInt("PlayerCash") >= itemAmount)
            {
                PlayerPrefs.SetInt("PlayerCash", PlayerPrefs.GetInt("PlayerCash") - itemAmount);
                PlayerPrefs.SetInt(prefName, 1);
                clickedItem.transform.GetChild(0).gameObject.SetActive(false);
                clickedItem.GetComponent<ItemController>().isLocked = false;
                SoundManager.instance.PlayScoreAddSound();
                cashText.text = FormatNumber(PlayerPrefs.GetInt("PlayerCash")).ToString();
            }
            else
            {
                SoundManager.instance.errorSound();
                CashPanel.SetActive(true);
            }
        }
    }

    void callAd()
    {
        AdsManager.Instance.ShowInterstitial("callad");

    }

    public void OnNextClick()
    {
        PlayerPrefs.SetInt("PlayerCash", PlayerPrefs.GetInt("PlayerCash") + 100);
        if (PlayerPrefs.GetInt("CareerMode") == 0)
        {
            PlayerPrefs.SetInt("LevelNumber", PlayerPrefs.GetInt("LevelNumber") + 1);
        }
        cashText.text = FormatNumber(PlayerPrefs.GetInt("PlayerCash")).ToString();
        SoundManager.instance.PlayButtonClickSound();
        Next.SetActive(false);
        levelCompletedParticles.SetActive(true);
        levelCompleteShow();
        //MakeupInstantiate();
        //loadingImage.SetActive(true);
        //Invoke("LoadNextScene", 3.0f);
        //AssignAdIds_CB.instance.CallInterstitialAd(Adspref.JustStatic);

    }

    public void HomeBtn()
    {
        PlayerPrefs.SetInt("PlayerCash", PlayerPrefs.GetInt("PlayerCash") + 100);
        SoundManager.instance.PlayButtonClickSound();
        if (PlayerPrefs.GetInt("CareerMode") == 1)
        {
            if (PlayerPrefs.GetInt("LevelPlayed") == PlayerPrefs.GetInt("levelPlayedIdNew"))
            {
                PlayerPrefs.SetInt("LevelPlayed", PlayerPrefs.GetInt("LevelPlayed") + 1);
            }
        }
        NavigationManager.instance.ReplaceScene(GameScene.MAINMENU);
    }

    private void LoadNextScene()
    {
        if (PlayerPrefs.GetInt("CareerMode") == 1)
        {
            NavigationManager.instance.ReplaceScene(GameScene.SELECTIONVIEW);
            //NavigationManager.instance.ReplaceScene(GameScene.MAINMENU);
        }
        else
        {
            if (PlayerPrefs.GetInt("MakeUpMode") == 1)
            {
                NavigationManager.instance.ReplaceScene(GameScene.CAREERMODEDRESSUP);
                PlayerPrefs.SetInt("MakeUpMode", 0);
            }
            else
            {
                NavigationManager.instance.ReplaceScene(GameScene.CAREERMODEMAKEUP);
                PlayerPrefs.SetInt("MakeUpMode", 1);
            }
        }
    }

    private void MakeupInstantiate()
    {
        GameManager.instance.player.SetMakeup(Instantiate(characterMakeup));
    }

    IEnumerator MoveCurrentItem(Image ReplaceImage, int ClickItem, int ItemTag)
    {
        if (flagBtnClick)
        {
            SoundManager.instance.PlayButtonClickSound();
            flagBtnClick = false;
            NextArr[ClickItem] = 1;
            CurrentItem.transform.position = ScrollContentItems[ClickItem].transform.GetChild(ItemTag).transform.position;
            CurrentItem.gameObject.SetActive(true);
            CurrentItem.GetComponent<Image>().SetNativeSize();
            MoveAction(CurrentItem.gameObject, ItemsEndPoints[ClickItem], 0.7f, iTween.EaseType.linear);
            ScaleAction(CurrentItem.gameObject, 1, 1.0f, iTween.EaseType.easeInOutQuad);
            yield return new WaitForSeconds(0.8f);
            ReplaceImage.sprite = Resources.Load<Sprite>(GameManager.instance.CurrentDressupItem.getInGameImageName());
            ReplaceImage.gameObject.SetActive(true);
            ParticleManger.instance.ShowStarParticle(ReplaceImage.gameObject);
            CurrentItem.transform.localScale = Vector3.zero;
            StopAllCoroutines();
            flagBtnClick = true;
            //ShowNext ();
        }
    }

    public void panelClose(GameObject parent)
    {
        SoundManager.instance.PlayButtonClickSound();
        parent.SetActive(false);
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

    public void purchaseBtn()
    {
        if (PlayerPrefs.GetInt("PlayerCash") >= int.Parse(Amount.text))
        {
            PlayerPrefs.SetInt("PlayerCash", PlayerPrefs.GetInt("PlayerCash") - int.Parse(Amount.text));
            PlayerPrefs.SetInt(ItemNameText.text, 1);
            ClickedBtnRef.transform.GetChild(0).gameObject.SetActive(false);
            ClickedBtnRef.GetComponent<ItemController>().isLocked = false;
            SoundManager.instance.PlayScoreAddSound();
            ItemPurchasePanel.SetActive(false);
            cashText.text = FormatNumber(PlayerPrefs.GetInt("PlayerCash")).ToString();
        }
        else
        {
            SoundManager.instance.errorSound();
            CashPanel.SetActive(true);
            ItemPurchasePanel.SetActive(false);
        }

    }

    public void unLockWithAd()
    {
        PlayerPrefs.SetInt(ItemNameText.text, 1);
        ClickedBtnRef.transform.GetChild(0).gameObject.SetActive(false);
        ClickedBtnRef.GetComponent<ItemController>().isLocked = false;
        SoundManager.instance.PlayScoreAddSound();
        ItemPurchasePanel.SetActive(false);

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
     
    void levelCompleteShow()
    {
        LevelCompletePanel.SetActive(true);
        AdsManager.Instance.HideMREC();
        //MoveSlider();
        cashTextLevelcomplete.text = FormatNumber(PlayerPrefs.GetInt("PlayerCash")).ToString();
        //cashText.text = countCoin.ToString();
        //RewardCashText.text = FormatNumber(PlayerPrefs.GetInt("PlayerCash")).ToString();
        Invoke("NothanskButtonActive", 3.0f);
    }

    public void NothanskButtonActive()
    {
        NothanksButton.SetActive(true);
    }

    public void nextLevelBtn()
    {
        SoundManager.instance.PlayButtonClickSound();
        if (PlayerPrefs.GetInt("CareerMode") == 1)
        {
            if (PlayerPrefs.GetInt("LevelPlayed") == PlayerPrefs.GetInt("levelPlayedIdNew"))
            {
                PlayerPrefs.SetInt("LevelPlayed", PlayerPrefs.GetInt("LevelPlayed") + 1);
            }
        }
        //LevelCompletePanel.SetActive(false);
        //loadingImage.SetActive(true);
        LoadNextScene();
        Debug.Log("NO Thansk Button Clicked");
    }

    public void MainMenu()
    {
        SoundManager.instance.PlayButtonClickSound();
        NavigationManager.instance.ReplaceScene(GameScene.MAINMENU);
    }

    #endregion
}
