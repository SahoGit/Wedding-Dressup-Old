using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Linq;
using System;
using Random = UnityEngine.Random;

public class MakeUpView : MonoBehaviour {

    #region Variables,Constants & Initializers
    public GameObject mainGrid;
    public GameObject loadingBG;

    public GameObject Player2Pic;

    public PaintTexture2D PaintingTexture;
    private int lastTag;
    public GameObject loadingImage;
    public GameObject Character, CharacterParent, characterMakeup;
    public RectTransform CharacterEndPoint;
    public Image CharacterBody, CharacterEyes;
    public GameObject[] itemGrids;
    public RectTransform itemsGridStartPoint, itemsGridEndPoint;

   
	private bool flagBtnClick;
    private bool clickflag = true;
    private int[] NextArr;
	private int NextCount;
	private int LastClickGrid;
	public List <RectTransform> ItemsEndPoints;
	public List <GameObject> ScrollContentItems;
	public Image CurrentItem;
	public RectTransform CurrentItemStartPoint;
	public Image DrawMaskImage;
	public RectTransform DrawMaskImageEndPoint;
    public Image Lips, leftCheekShade, rightCheekShade, leftEyeShade, rightEyeShade;
    public Sprite[] makeUpTextures;
    public Sprite LipsTexture, CheekShadeTexture, EyeBrowTexture, EyeShadeTexture, EyeLashTexture, EyeLensTexture;
    public Image Hair, EarRing;
    public Image leftEyeLens, rightEyeLens;
    public Image leftEyeBrow, rightEyeBrow;
    public Image leftEyeLash, rightEyeLash;
    public GameObject Next;
    public GameObject SubmitBtn;
    public GameObject SkipBtn;
    public GameObject levelCompletedParticles;
    public int counter = 0;
    public List<int> numbers;
    public GameObject noInternetConect;

    public GameObject GamePlay;
    public GameObject BattleAnimation;

    public Sprite[] Player2Images;

    public Sprite greenImage;

    //Item veriables
    public GameObject ClickedBtnRef;
    public GameObject LowSelectItemPanel;
    public GameObject ItemPurchasePanel;
    public GameObject CashPanel;
    public Text ItemPurchaseText;
    public Text Amount;
    public Text ItemNameText;
    //Item veriables

    public Text cashText;


    #endregion

    #region Lifecycle Methods
    // Use this for initialization
    void Start ()
    {
        SoundManager.instance.PlayGPSound(1);
        loadingBG.SetActive(true);
        GamePlay.SetActive(false);
        Invoke("afterLoading", 4.0f);
    }

    void afterLoading()
    {
        loadingBG.SetActive(false);
        // AdsManager.Instance.ShowBanner();
        cashText.text = FormatNumber(PlayerPrefs.GetInt("PlayerCash")).ToString();
        //Character.SetActive(false);
        GamePlay.SetActive(false);
        BattleAnimation.SetActive(false);
        if (PlayerPrefs.GetInt("playerMode") == 1 && PlayerPrefs.GetInt("isChallenge") == 0)
        {
            BattleAnimation.SetActive(true);
            //SoundManager.instance.PlayScoreAddSound();
            InvokeRepeating("Player2ImageShuffle", 1.5f, 0.1f);
            Invoke("cancelImageShuffle", 3.0f);
            Invoke("BattleAnimationOff", 6.0f);
            Invoke("GamePlayOn", 5.5f);
        }
        else
        {
            GamePlay.SetActive(true);
            //itemGrids[0].GetComponent<RectTransform>().localPosition = itemsGridStartPoint.gameObject.GetComponent<RectTransform>().localPosition;
            //MoveAction(itemGrids[0], itemsGridEndPoint, 0.3f, iTween.EaseType.linear);
            Invoke("SetViewContents", 0.2f);
        }

        if (PlayerPrefs.GetInt("isChallenge") == 1)
        {
            PlayerPrefs.SetInt("isChallenge", 0);
        }
    }

    void BattleAnimationOff()
    {
        BattleAnimation.SetActive(false);
    }

    void GamePlayOn()
    {
        GamePlay.SetActive(true);
        itemGrids[0].GetComponent<RectTransform>().localPosition = itemsGridStartPoint.gameObject.GetComponent<RectTransform>().localPosition;
        MoveAction(itemGrids[0], itemsGridEndPoint, 0.3f, iTween.EaseType.linear);
        Invoke("SetViewContents", 0.2f);
    }

    void cancelImageShuffle()
    {
        CancelInvoke("Player2ImageShuffle");
        SoundManager.instance.PlayScoreAddSound();
        ParticleManger.instance.ShowStarParticle(Player2Pic.gameObject);
    }

    void Player2ImageShuffle()
    {
        int imageInt = Random.Range(0, Player2Images.Length - 1);
        Player2Pic.GetComponent<Image>().sprite = Player2Images[imageInt];
        SoundManager.instance.playPhotoFlip();

    }


    void Destroy() {
		iTween.Stop ();
	}

	#endregion

	#region Utility Methods

	private void SetViewContents() {
		GameManager.instance.currentScene = Utils.CURRENT_SCENE_MAKEUP;
        Invoke("loadingImageInactive", 3f);
        //Character.SetActive(true);
        SoundManager.instance.playCharacterAppear();
        ParticleManger.instance.ShowStarParticle(CharacterParent.gameObject);
        LastClickGrid = 0;
		flagBtnClick = true;
		NextArr = new int[]{ 1, 0, 0, 0, 0, 0 , 0 ,0 , 0 };

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
            SkipBtn.SetActive(false);
        }
    }

    private void MoveAction(GameObject obj,RectTransform pos,float time,iTween.EaseType type)
	{
		Hashtable tweenParams = new Hashtable();
		tweenParams.Add ("x", pos.position.x);
		tweenParams.Add ("y", pos.position.y);
		tweenParams.Add ("time", time);
		tweenParams.Add ("easetype", type);
		iTween.MoveTo (obj, tweenParams);
	}


	private void ScaleAction(GameObject obj,float ScaleFactor,float time,iTween.EaseType type) {
		Hashtable tweenParams = new Hashtable();
		tweenParams.Add ("scale", new Vector3 (ScaleFactor, ScaleFactor, 0));
		tweenParams.Add ("time", 0.5f);
		tweenParams.Add ("easetype",type);
		iTween.ScaleTo(obj, tweenParams);
	}

	private void ScaleActionloop(GameObject obj,float ScaleFactor,float time,iTween.EaseType type,iTween.LoopType loop) {
		Hashtable tweenParams = new Hashtable();
		tweenParams.Add ("scale", new Vector3 (ScaleFactor, ScaleFactor, 0));
		tweenParams.Add ("time", 0.5f);
		tweenParams.Add ("easetype",type);
		tweenParams.Add ("looptype",loop);
		iTween.ScaleTo(obj, tweenParams);

	}
	private void MoveActionloop(GameObject obj,RectTransform pos,float time,iTween.EaseType type,iTween.LoopType loop)
	{
		Hashtable tweenParams = new Hashtable();
		tweenParams.Add ("x", pos.position.x);
		tweenParams.Add ("y", pos.position.y);
		tweenParams.Add ("time", time);
		tweenParams.Add ("easetype", type);
		tweenParams.Add ("looptype", loop);
		iTween.MoveTo (obj, tweenParams);
	}
	private void RotateAction(GameObject obj,float rotationAmout,float time,iTween.EaseType actionType)
	{
		Hashtable tweenParams = new Hashtable();
		tweenParams.Add ("z", rotationAmout);
		tweenParams.Add ("time", time);
		tweenParams.Add ("easetype", actionType);
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
        if (lastTag == tag)
        {
            for (int i = 0; i < itemGrids.Length; i++)
            {
                itemGrids[i].SetActive(false);
                itemGrids[i].GetComponent<RectTransform>().localPosition = itemsGridStartPoint.gameObject.GetComponent<RectTransform>().localPosition;
            }
            itemGrids[tag].SetActive(true);
            MoveAction(itemGrids[tag], itemsGridEndPoint, 0.3f, iTween.EaseType.linear);
            lastTag = tag;
        }
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
            CallAds();
            CheckAllBtnsClicked(tag);
        }
        else if (tag == 0)
        {
            itemGrids[0].SetActive(true);
            MoveAction(itemGrids[0], itemsGridEndPoint, 0.3f, iTween.EaseType.linear);
            CheckAllBtnsClicked(tag);
        }
        SkipBtn.SetActive(true);
        mainGrid.SetActive(false);
    }

    public void btnClicked(GameObject btn)
    {
        btn.GetComponent<Image>().sprite = greenImage;
    }

    void CheckAllBtnsClicked(int value)
    {
        if(!numbers.Contains(value))
        {
            numbers.Add(value);
            if(numbers.Count >= 6)
            {
                //Next.SetActive(true);
                //SubmitBtn.SetActive(true);
                SkipBtn.SetActive(false);
            }
        }
    }
  //public GameObject LoadingScreen_New;
  
 public GameObject DummyScreen_AdsLoad;
    void CallAds()
    {
        if(counter%3==0)
        {
            print("Counter =" + counter);
            DummyScreen_AdsLoad.SetActive(true);
            Invoke("ShowAds",2.5f);
             Invoke("DummyScreen",2.7f);
           // AdsManager.Instance.ShowInterstitial("callad");
            

        }
      
    }
    
    void ShowAds()
    {
         AdsManager.Instance.ShowInterstitial("ad show on loading screen");
    }
   void DummyScreen()
    {
        DummyScreen_AdsLoad.SetActive(false);
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
            SoundManager.instance.PlayniceColorSound();
            ParticleManger.instance.ShowStarParticle(leftEyeLens.gameObject);
            ParticleManger.instance.ShowStarParticle(rightEyeLens.gameObject);
            GameManager.instance.CurrentDressupItem = GameManager.instance.lensDataList[tag] as BaseItem;
            GameManager.instance.selectedLens = GameManager.instance.lensDataList[tag] as BaseItem;
            CurrentItem.sprite = Resources.Load<Sprite>(GameManager.instance.CurrentDressupItem.getInGameImageName());
            leftEyeLens.sprite = Resources.Load<Sprite>(GameManager.instance.CurrentDressupItem.getInGameImageName());
            rightEyeLens.sprite = Resources.Load<Sprite>(GameManager.instance.CurrentDressupItem.getInGameImageName());
            Next.SetActive(true);
            SkipBtn.SetActive(false);
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
        SubmitBtn.SetActive(true);
        SkipBtn.SetActive(false);
        Next.SetActive(false);
    }

    public void OnHairSelected(int tag)
	{
        GameObject clickedItem = EventSystem.current.currentSelectedGameObject;
        int itemId = clickedItem.GetComponent<ItemController>().id;
        bool itemLocked = clickedItem.GetComponent<ItemController>().isLocked;
        string itemName = clickedItem.GetComponent<ItemController>().name;
        int itemAmount = clickedItem.GetComponent<ItemController>().amount;
        GameObject LockImage = clickedItem.transform.GetChild(0).gameObject;
        if (!itemLocked)
        {
            SoundManager.instance.PlayhairSound();
            ParticleManger.instance.ShowStarParticle(Hair.gameObject);
            GameManager.instance.CurrentDressupItem = GameManager.instance.makeuphairDataList[tag] as BaseItem;
            GameManager.instance.selectedHair = GameManager.instance.makeuphairDataList[tag] as BaseItem;
            CurrentItem.sprite = Resources.Load<Sprite>(GameManager.instance.CurrentDressupItem.getInGameImageName());
            Hair.sprite = Resources.Load<Sprite>(GameManager.instance.CurrentDressupItem.getInGameImageName());
            Next.SetActive(true);
            SkipBtn.SetActive(false);
        }
        else
        {
            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                SoundManager.instance.PlayButtonClickSound();
                noInternetConect.SetActive(true);
                Invoke("noInternetConectClose", 2.0f);
            }
            else
            {
                //callAd();
                SoundManager.instance.PlaysparkleClickSound();
                ItemPurchasePanel.SetActive(true);
                ItemPurchaseText.text = "You need " + itemAmount + " cash for this item";
                Amount.text = itemAmount.ToString();
                ItemNameText.text = itemName + itemId;
                ClickedBtnRef = clickedItem;
                //LockImage.SetActive(false);
                //PlayerPrefs.SetInt(itemName + itemId, 1);
                //clickedItem.GetComponent<ItemController>().isLocked = false;
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
            SoundManager.instance.PlaysparkleClickSound();
            ParticleManger.instance.ShowStarParticle(leftEyeBrow.gameObject);
            ParticleManger.instance.ShowStarParticle(rightEyeBrow.gameObject);
            GameManager.instance.CurrentDressupItem = GameManager.instance.eyeBrowsDataList[tag] as BaseItem;
            GameManager.instance.selectedEyeBrow = GameManager.instance.eyeBrowsDataList[tag] as BaseItem;
            CurrentItem.sprite = Resources.Load<Sprite>(GameManager.instance.CurrentDressupItem.getInGameImageName());
            leftEyeBrow.sprite = Resources.Load<Sprite>(GameManager.instance.CurrentDressupItem.getInGameImageName());
            rightEyeBrow.sprite = Resources.Load<Sprite>(GameManager.instance.CurrentDressupItem.getInGameImageName());
            Next.SetActive(true);
            SkipBtn.SetActive(false);
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
            SoundManager.instance.PlaysparkleClickSound();
            ParticleManger.instance.ShowStarParticle(leftEyeLash.gameObject);
            ParticleManger.instance.ShowStarParticle(rightEyeLash.gameObject);
            GameManager.instance.CurrentDressupItem = GameManager.instance.eyeLashesDataList[tag] as BaseItem;
            GameManager.instance.selectedEyeLash = GameManager.instance.eyeBrowsDataList[tag] as BaseItem;
            CurrentItem.sprite = Resources.Load<Sprite>(GameManager.instance.CurrentDressupItem.getInGameImageName());
            leftEyeLash.sprite = Resources.Load<Sprite>(GameManager.instance.CurrentDressupItem.getInGameImageName());
            rightEyeLash.sprite = Resources.Load<Sprite>(GameManager.instance.CurrentDressupItem.getInGameImageName());
            Next.SetActive(true);
            SkipBtn.SetActive(false);
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
            SoundManager.instance.PlaysparkleClickSound();
            ParticleManger.instance.ShowStarParticle(EarRing.gameObject);
            GameManager.instance.CurrentDressupItem = GameManager.instance.earringDataList[tag] as BaseItem;
            GameManager.instance.selectedEarRing = GameManager.instance.earringDataList[tag] as BaseItem;
            CurrentItem.sprite = Resources.Load<Sprite>(GameManager.instance.CurrentDressupItem.getInGameImageName());
            EarRing.sprite = Resources.Load<Sprite>(GameManager.instance.CurrentDressupItem.getInGameImageName());
            Next.SetActive(true);
            SkipBtn.SetActive(false);
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
        SoundManager.instance.PlayButtonClickSound();
       
        for (int i = 0; i < itemGrids.Length; i++)
        {
            itemGrids[i].SetActive(false);
            //itemGrids[i].GetComponent<RectTransform>().localPosition = itemsGridStartPoint.gameObject.GetComponent<RectTransform>().localPosition;
            MoveAction(itemGrids[i], itemsGridStartPoint, 0.3f, iTween.EaseType.linear);
        }
        //itemGrids[tag].SetActive(true);
        //MoveAction(itemGrids[tag], itemsGridEndPoint, 0.3f, iTween.EaseType.linear);
        mainGrid.SetActive(true);
        //SoundManager.instance.PlayButtonClickSound();
        Next.SetActive(false);
        SkipBtn.SetActive(false);
        //levelCompletedParticles.SetActive(true);
        //MakeupInstantiate();
        ////loadingImage.SetActive(true);
        //Invoke ("LoadNextScene",0.1f);
        ////AssignAdIds_CB.instance.CallInterstitialAd(Adspref.JustStatic);

    }
    public void OnSubmitClick()
    {
        SoundManager.instance.PlayButtonClickSound();
        //SubmitBtn.SetActive(false);
        levelCompletedParticles.SetActive(true);
        MakeupInstantiate();
        //loadingImage.SetActive(true);
        Invoke ("LoadNextScene",0.1f);
        //AssignAdIds_CB.instance.CallInterstitialAd(Adspref.JustStatic);

    }

    private void LoadNextScene()
    {
        NavigationManager.instance.ReplaceScene(GameScene.DRESSUP);
    }

    private void MakeupInstantiate()
    {
        GameManager.instance.player.SetMakeup(Instantiate(characterMakeup));
    }
    IEnumerator MoveCurrentItem(Image ReplaceImage,int ClickItem,int ItemTag)
	{
		if(flagBtnClick)
		{
			SoundManager.instance.PlayButtonClickSound ();
			flagBtnClick = false;
			NextArr [ClickItem] = 1;
			CurrentItem.transform.position = ScrollContentItems [ClickItem].transform.GetChild (ItemTag).transform.position;
			CurrentItem.gameObject.SetActive (true);
			CurrentItem.GetComponent<Image> ().SetNativeSize ();
		     MoveAction (CurrentItem.gameObject, ItemsEndPoints[ClickItem], 0.7f, iTween.EaseType.linear);
			ScaleAction (CurrentItem.gameObject, 1, 1.0f, iTween.EaseType.easeInOutQuad);
			yield return new WaitForSeconds(0.8f);
			ReplaceImage.sprite = Resources.Load <Sprite> (GameManager.instance.CurrentDressupItem.getInGameImageName ());
			ReplaceImage.gameObject.SetActive (true);
			ParticleManger.instance.ShowStarParticle(ReplaceImage.gameObject);
			CurrentItem.transform.localScale = Vector3.zero;
			StopAllCoroutines ();
			flagBtnClick = true;
			//ShowNext ();
		}
	}

    public void panelClose(GameObject parent)
    {
        SoundManager.instance.PlayButtonClickSound();
        parent.SetActive (false);
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
    }


    public void OnSkipClick()
    {
        for (int i = 0; i < itemGrids.Length; i++)
        {
            itemGrids[i].SetActive(false);
            itemGrids[i].GetComponent<RectTransform>().localPosition = itemsGridStartPoint.gameObject.GetComponent<RectTransform>().localPosition;
        }
        mainGrid.SetActive(true);
        SoundManager.instance.PlayButtonClickSound();
        if (lastTag == 0)
        {
            Lips.sprite = makeUpTextures[lastTag];
        }
        else if (lastTag == 1)
        {
            leftCheekShade.sprite = makeUpTextures[lastTag];
            rightCheekShade.sprite = makeUpTextures[lastTag];
        }
        else if (lastTag == 2)
        {
            leftEyeBrow.sprite = makeUpTextures[lastTag];
            rightEyeBrow.sprite = makeUpTextures[lastTag];
        }
        else if (lastTag == 3)
        {
            leftEyeShade.sprite = makeUpTextures[lastTag];
            rightEyeShade.sprite = makeUpTextures[lastTag];
        }
        else if (lastTag == 4)
        {
            leftEyeLash.sprite = makeUpTextures[lastTag];
            rightEyeLash.sprite = makeUpTextures[lastTag];
        }
        else if (lastTag == 5)
        {
            leftEyeLens.sprite = makeUpTextures[lastTag];
            rightEyeLens.sprite = makeUpTextures[lastTag];
            SubmitBtn.SetActive(true);
        }
        SkipBtn.SetActive(false);
        //Next.SetActive(true);
        Debug.Log(lastTag);
       AdsManager.Instance.ShowInterstitial("Makeup skip");
    }

    #endregion
}
