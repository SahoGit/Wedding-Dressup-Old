using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Linq;
using System;
using Random = UnityEngine.Random;

public class CareerModeDressUp : MonoBehaviour
{
    #region Variables,Constants & Initializers
    public GameObject loadingBG;
    public GameObject GamePlay;

    public GameObject otherDress;

    public Sprite blankImage;
    public Sprite dummyhair;

    public Sprite[] DressList;
    public Sprite[] VeilList;
    public Sprite[] hairsList;
    public Sprite[] HeadWearList;
    public Sprite[] NecklaceList;
    public Sprite[] EarringList;
    public Sprite[] FlowerList;
    public Sprite[] ShoesList;

    //Item veriables
    public GameObject ClickedBtnRef;
    public GameObject ItemPurchasePanel;
    public GameObject CashPanel;
    public Text ItemPurchaseText;
    public Text Amount;
    public Text ItemNameText;
    //Item veriables

    public Text cashText;
    public Text cashTextLevelcomplete;

    private int lastTag = 0;
    private int currentTag = -1;
    private int LastClickGrid;
    private bool flagBtnClick;
    private int NextCount;
    private int[] NextArr;

    public GameObject loadingImage;
    public GameObject Character, CharacterBody;
    public RectTransform CharacterEndPoint;
    public GameObject characterMakeup, characterMakeupPosition;
    public GameObject dressedGirl;
    public Image Dress;
    public Image Veil;
    public Image hairs;
    public Image HeadWear;
    public Image Necklace;
    public Image Earring;
    public Image Flower;
    public Image Shoes;

    /// Makeup Items Image Here /// 

    public Image Lens;
    public Image LeftEyeShade;
    public Image RightEyeShade;
    public Image LeftEyeLiner;
    public Image RightEyeLiner;
    public Image LeftEyeLashes;
    public Image RightEyeLashes;
    public Image LeftCheekShade;
    public Image RightCheekShade;
    public Image Lips;
    public Image EarRing;



    public List<RectTransform> ItemsEndPoints;
    public Image CurrentItem;
    public List<GameObject> ScrollContentItems;

    public List<GameObject> Grids;
    public RectTransform GridStartPoint;
    public RectTransform GridEndPoint;

    public GameObject Next;
    public GameObject levelCompletedParticles;

    public int counter = 0;

    public GameObject[] clickedButtonArray;
    public GameObject noInternetConect;
    public GameObject LevelStartPanel;
    public GameObject LevelCompletePanel;
    public GameObject NothanksButton;

    public GameObject[] itemGrids;
    public string[] ObjectiveString;
    public Text ObjectiveTextTitle;
    public Text ObjectiveText;
    public int levelIndex;


   
    #endregion

    #region Lifecycle Methods
    void OnAwake()
    {
        Character.SetActive(false);
        SoundManager.instance.PlayGPSound(1);
    }

    // Use this for initialization
    void Start()
    {
        loadingBG.SetActive(true);
        GamePlay.SetActive(false);
        Invoke("afterLoading", 4.0f);
    }


    void afterLoading()
    {
        loadingBG.SetActive(false);
        GamePlay.SetActive(true);
        //if (PlayerPrefs.GetInt("LevelNumber") == 0)
        //{
        //    PlayerPrefs.SetInt("LevelNumber", 1);
        //}
        LevelStartPanel.SetActive(true);
        Character.SetActive(false);
        if (PlayerPrefs.GetInt("CareerMode") == 1)
        {
            levelIndex = PlayerPrefs.GetInt("careerLevelId");
            ObjectiveTextTitle.text = "Objective";
            Debug.Log("Test Objective Text Title change or not??????????" + ObjectiveTextTitle.text);
            ObjectiveText.text = ObjectiveString[levelIndex];
        }
        else
        {
            levelIndex = PlayerPrefs.GetInt("levelIndex");
            chooseRandom();
            ObjectiveTextTitle.text = "Level" + PlayerPrefs.GetInt("LevelNumber");
            ObjectiveText.text = ObjectiveString[levelIndex];
        }
        cashText.text = FormatNumber(PlayerPrefs.GetInt("PlayerCash")).ToString();
        dressUpRandomly();
    }

    void dressUpRandomly()
    {
        if (levelIndex != 0)
        {
            otherDress.SetActive(false);
            Dress.GetComponent<Image>().sprite = DressList[Random.Range(0, DressList.Length - 1)];
        }
        if (levelIndex != 1)
        {
            Veil.GetComponent<Image>().sprite = VeilList[Random.Range(0, VeilList.Length - 1)];
        }
        if (levelIndex != 2)
        {
            hairs.GetComponent<Image>().sprite = dummyhair;
            hairs.GetComponent<Image>().sprite = hairsList[Random.Range(0, hairsList.Length - 1)];
        }
        if (levelIndex != 3)
        {
            HeadWear.GetComponent<Image>().sprite = HeadWearList[Random.Range(0, HeadWearList.Length - 1)];
        }
        if (levelIndex != 4)
        {
            Necklace.GetComponent<Image>().sprite = NecklaceList[Random.Range(0, NecklaceList.Length - 1)];
        }
        if (levelIndex != 5)
        {
            Earring.GetComponent<Image>().sprite = EarringList[Random.Range(0, EarringList.Length - 1)];
        }
        if (levelIndex != 6)
        {
            Flower.GetComponent<Image>().sprite = FlowerList[Random.Range(0, FlowerList.Length - 1)];
        }
        if (levelIndex != 7)
        {
            Shoes.GetComponent<Image>().sprite = ShoesList[Random.Range(0, ShoesList.Length - 1)];
        }
        
    }


    void chooseRandom()
    {
        levelIndex = Random.Range(0, itemGrids.Length);
        if (PlayerPrefs.GetInt("levelIndexDressUp") != levelIndex)
        {
            PlayerPrefs.SetInt("levelIndexDressUp", levelIndex);
        }
        else
        {
            chooseRandom();
        }
    }

    public void levelStart()
    {
       // AdsManager.Instance.ShowBanner();
        SoundManager.instance.PlayButtonClickSound();
        LevelStartPanel.SetActive(false);
        Character.SetActive(true);
        cashText.text = FormatNumber(PlayerPrefs.GetInt("PlayerCash")).ToString();
        MoveAction(itemGrids[levelIndex], GridEndPoint, 0.3f, iTween.EaseType.linear);
        Invoke("SetViewContents", 0.2f);
        ObjectiveTextTitle.text = "Level" + PlayerPrefs.GetInt("levelIndexDressUp");
        ObjectiveText.text = ObjectiveString[levelIndex];
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

    public void panelClose(GameObject parent)
    {
        SoundManager.instance.PlayButtonClickSound();
        parent.SetActive(false);
    }

    public void purchaseBtn()
    {
        if (PlayerPrefs.GetInt("PlayerCash") >= int.Parse(Amount.text))
        {
            PlayerPrefs.SetInt("PlayerCash", PlayerPrefs.GetInt("PlayerCash") - int.Parse(Amount.text));
            PlayerPrefs.SetInt(ItemNameText.text, 1);
            if (ClickedBtnRef.transform.childCount > 1)
            {
                ClickedBtnRef.transform.GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                ClickedBtnRef.transform.GetChild(0).gameObject.SetActive(false);
            }
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

    void Destroy()
    {
        iTween.Stop();
    }

    #endregion

    #region Utility Methods



    private void SetViewContents()
    {
        LastClickGrid = -1;
        flagBtnClick = true;
        NextArr = new int[] { 1, 0, 0, 0, 0, 0, 0, 0 };
        //SettingPizza();
        SetCharacter();
        Invoke("loadingImageInactive", 3f);
        Character.SetActive(true);
        SoundManager.instance.playEndSparkles();
        ParticleManger.instance.ShowStarParticle(Character.gameObject);
    }

    private void SettingPizza()
    {
        characterMakeup = GameManager.instance.player.GetMakeup();
        characterMakeup.transform.SetParent(CharacterBody.transform);
        characterMakeup.GetComponent<RectTransform>().localScale = new Vector3(0.4f, 0.4f, 0.4f);
        //pizzaPrepared.GetComponent<RectTransform>().eulerAngles = new Vector3(48.01f, 0.7f, 0.93f);
        //   characterMakeup.GetComponent<RectTransform>().localPosition = characterMakeupPosition.gameObject.transform.position;
        characterMakeup.transform.SetSiblingIndex(0);
        characterMakeup.GetComponent<RectTransform>().localPosition = new Vector3(-44f, 564f, 0f);
        characterMakeup.SetActive(true);
        CharacterBody.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject.SetActive(false);
        CharacterBody.transform.GetChild(0).gameObject.transform.GetChild(4).gameObject.SetActive(false);
    }

    private void SetCharacter()
    {
        if (GameManager.instance.selectedHair != null)
        {
            hairs.sprite = Resources.Load<Sprite>(GameManager.instance.selectedHair.getInGameImageName());
        }

        if (GameManager.instance.selectedEarRing != null)
        {
            Earring.sprite = Resources.Load<Sprite>(GameManager.instance.selectedEarRing.getInGameImageName());
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
    //private void SetCharacterMakeupItems ()
    //{
    //	if (GameManager.instance.selectedGirlHair != null) {
    //		Hair.sprite = Resources.Load <Sprite> (GameManager.instance.selectedGirlHair.getInGameImageName ());
    //		Hair.gameObject.SetActive (true);
    //	}
    //	if (GameManager.instance.selectedLens != null) {
    //		Lens.sprite = Resources.Load <Sprite> (GameManager.instance.selectedLens.getInGameImageName ());
    //		Lens.gameObject.SetActive (true);
    //	}
    //	if (GameManager.instance.selectedLeftEyeShade != null) {
    //		LeftEyeShade.sprite = Resources.Load <Sprite> (GameManager.instance.selectedLeftEyeShade.getInGameImageName ());
    //		LeftEyeShade.gameObject.SetActive (true);
    //	}
    //	if (GameManager.instance.selectedRightEyeShade != null) {
    //		RightEyeShade.sprite = Resources.Load <Sprite> (GameManager.instance.selectedRightEyeShade.getInGameImageName ());
    //		RightEyeShade.gameObject.SetActive (true);
    //	}
    //	if (GameManager.instance.selectedLeftEyeLiner != null) {
    //		LeftEyeLiner.sprite = Resources.Load <Sprite> (GameManager.instance.selectedLeftEyeLiner.getInGameImageName ());
    //		LeftEyeLiner.gameObject.SetActive (true);
    //	}
    //	if (GameManager.instance.selectedRightEyeLiner != null) {
    //		RightEyeLiner.sprite = Resources.Load <Sprite> (GameManager.instance.selectedRightEyeLiner.getInGameImageName ());
    //		RightEyeLiner.gameObject.SetActive (true);
    //	}
    //	if (GameManager.instance.selectedLeftEyeLashTypeOne != null) {
    //		LeftEyeLashes.sprite = Resources.Load <Sprite> (GameManager.instance.selectedLeftEyeLashTypeOne.getInGameImageName ());	
    //		LeftEyeLashes.gameObject.SetActive (true);
    //	}
    //	if (GameManager.instance.selectedRightEyeLashTypeOne != null) {
    //		RightEyeLashes.sprite = Resources.Load <Sprite> (GameManager.instance.selectedRightEyeLashTypeOne.getInGameImageName ());	
    //		RightEyeLashes.gameObject.SetActive (true);
    //	}
    //	if (GameManager.instance.selectedLeftCheekShade != null) {
    //		LeftCheekShade.sprite = Resources.Load <Sprite> (GameManager.instance.selectedLeftCheekShade.getInGameImageName ());
    //		LeftCheekShade.gameObject.SetActive (true);
    //	}
    //	if (GameManager.instance.selectedRightCheekShade != null) {
    //		RightCheekShade.sprite = Resources.Load <Sprite> (GameManager.instance.selectedRightCheekShade.getInGameImageName ());
    //		RightCheekShade.gameObject.SetActive (true);
    //	}
    //	if (GameManager.instance.selectedLips != null) {
    //		Lips.sprite = Resources.Load <Sprite> (GameManager.instance.selectedLips.getInGameImageName ());
    //		Lips.gameObject.SetActive (true);
    //	}
    //	if (GameManager.instance.selectedEarRing != null) {
    //		EarRing.sprite = Resources.Load <Sprite> (GameManager.instance.selectedEarRing.getInGameImageName ());
    //		EarRing.gameObject.SetActive (true);
    //	}
    //	if (GameManager.instance.selectedNecklace != null) {
    //		Necklace.sprite = Resources.Load <Sprite> (GameManager.instance.selectedNecklace.getInGameImageName ());
    //		Necklace.gameObject.SetActive (true);
    //	}

    //	//if (GameManager.instance.selectedhairband != null) {
    //	//	HeadStyle.sprite = Resources.Load <Sprite> (GameManager.instance.selectedhairband.getInGameImageName ());
    //	//	HeadStyle.gameObject.SetActive (true);

    //	//}
    //	if (GameManager.instance.selectedDress != null) {
    //		Dress.sprite = Resources.Load <Sprite> (GameManager.instance.selectedDress.getInGameImageName ());
    //		Dress.gameObject.SetActive (true);
    //	}
    //}

    //private void makeDressupItemsNull()
    //{
    //	GameManager.instance.selectedNecklace = null;
    //	GameManager.instance.selectedShoes = null;
    //	GameManager.instance.selectedGirlNecklace = null;
    //	GameManager.instance.selectedDress = null;
    //	GameManager.instance.selectedDress = null;
    //	GameManager.instance.selectedPent = null;
    //	GameManager.instance.selectedGlases = null;
    //	GameManager.instance.selectedHandBag = null;

    //}


    private void ScaleAction(GameObject obj, float ScaleFactor, float time, iTween.EaseType type)
    {
        Hashtable tweenParams = new Hashtable();
        tweenParams.Add("scale", new Vector3(ScaleFactor, ScaleFactor, 0));
        tweenParams.Add("time", 0.5f);
        tweenParams.Add("easetype", type);
        iTween.ScaleTo(obj, tweenParams);
    }

    private void loadingImageInactive()
    {
        AdsManager.Instance.HideMREC();
        loadingImage.SetActive(false);
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
        if (NextCount == 8)
        {
            Next.SetActive(true);
        }
    }




    #endregion

    #region Callback Methods

    void noInternetConectClose()
    {
        noInternetConect.SetActive(false);
    }



    public void closeGrid()
    {
        for (int i = 0; i < Grids.Count; i++)
        {
            MoveAction(Grids[i], GridStartPoint, 0.5f, iTween.EaseType.easeInOutSine);
        }

    }
    /// Grids Click Code Here /// 




    public void OnDressGirdClick(int tag)
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
            SoundManager.instance.PlaysdressSound();
            GameManager.instance.CurrentDressupItem = GameManager.instance.dressDataList[tag] as BaseItem;
            GameManager.instance.selectedDress = GameManager.instance.dressDataList[tag] as BaseItem;
            CurrentItem.sprite = Resources.Load<Sprite>(GameManager.instance.CurrentDressupItem.getInGameImageName());
            StartCoroutine(MoveCurrentItem(Dress, 0, tag));
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
    public void OnVeilClick(int tag)
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
            SoundManager.instance.PlaysdressSound();
            GameManager.instance.CurrentDressupItem = GameManager.instance.veilDataList[tag] as BaseItem;
            GameManager.instance.selectedVeil = GameManager.instance.veilDataList[tag] as BaseItem;
            CurrentItem.sprite = Resources.Load<Sprite>(GameManager.instance.CurrentDressupItem.getInGameImageName());
            StartCoroutine(MoveCurrentItem(Veil, 1, tag));
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

    public void OnHairsGridClick(int tag)
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
            SoundManager.instance.PlayhairSound();
            GameManager.instance.CurrentDressupItem = GameManager.instance.makeuphairDataList[tag] as BaseItem;
            GameManager.instance.selectedDressupHairs = GameManager.instance.makeuphairDataList[tag] as BaseItem;
            CurrentItem.sprite = Resources.Load<Sprite>(GameManager.instance.CurrentDressupItem.getInGameImageName());
            StartCoroutine(MoveCurrentItem(hairs, 2, tag));
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

    public void OnHeadWearClick(int tag)
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
            GameManager.instance.CurrentDressupItem = GameManager.instance.headwearDataList[tag] as BaseItem;
            GameManager.instance.selectedHeadWear = GameManager.instance.headwearDataList[tag] as BaseItem;
            CurrentItem.sprite = Resources.Load<Sprite>(GameManager.instance.CurrentDressupItem.getInGameImageName());
            StartCoroutine(MoveCurrentItem(HeadWear, 3, tag));
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
    public void OnNecklaceGirdClick(int tag)
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
            GameManager.instance.CurrentDressupItem = GameManager.instance.necklaceDataList[tag] as BaseItem;
            GameManager.instance.selectedNecklace = GameManager.instance.necklaceDataList[tag] as BaseItem;
            CurrentItem.sprite = Resources.Load<Sprite>(GameManager.instance.CurrentDressupItem.getInGameImageName());
            StartCoroutine(MoveCurrentItem(Necklace, 4, tag));
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
    public void OnEarringGridClick(int tag)
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
            GameManager.instance.CurrentDressupItem = GameManager.instance.earringDataList[tag] as BaseItem;
            GameManager.instance.selectedEarRing = GameManager.instance.earringDataList[tag] as BaseItem;
            CurrentItem.sprite = Resources.Load<Sprite>(GameManager.instance.CurrentDressupItem.getInGameImageName());
            StartCoroutine(MoveCurrentItem(Earring, 5, tag));
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

    public void OnFlowerGridClick(int tag)
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
            GameManager.instance.CurrentDressupItem = GameManager.instance.flowerDataList[tag] as BaseItem;
            GameManager.instance.selectedFlower = GameManager.instance.flowerDataList[tag] as BaseItem;
            CurrentItem.sprite = Resources.Load<Sprite>(GameManager.instance.CurrentDressupItem.getInGameImageName());
            StartCoroutine(MoveCurrentItem(Flower, 6, tag));
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

    public void OnShoesGirdClick(int tag)
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
            GameManager.instance.CurrentDressupItem = GameManager.instance.shoesDataList[tag] as BaseItem;
            GameManager.instance.selectedShoes = GameManager.instance.shoesDataList[tag] as BaseItem;
            CurrentItem.sprite = Resources.Load<Sprite>(GameManager.instance.CurrentDressupItem.getInGameImageName());
            StartCoroutine(MoveCurrentItem(Shoes, 7, tag));
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
        AdsManager.Instance.ShowInterstitial("call ad");
    }

    IEnumerator MoveCurrentItem(Image ReplaceImage, int ClickItem, int ItemTag)
    {
        if (flagBtnClick)
        {
            flagBtnClick = false;
            NextArr[ClickItem] = 1;
            CurrentItem.transform.position = ScrollContentItems[ClickItem].transform.GetChild(ItemTag).transform.position;
            CurrentItem.gameObject.SetActive(true);
            CurrentItem.GetComponent<Image>().SetNativeSize();
            MoveAction(CurrentItem.gameObject, ItemsEndPoints[ClickItem], 0.7f, iTween.EaseType.linear);

            if (levelIndex == 2)
            {
                ScaleAction(CurrentItem.gameObject, 0.3f, 0.7f, iTween.EaseType.easeInOutQuad);

            }
            else if (levelIndex == 5)
            {
                ScaleAction(CurrentItem.gameObject, 0.35f, 0.7f, iTween.EaseType.easeInOutQuad);
            }
            else
            {
                ScaleAction(CurrentItem.gameObject, 0.7f, 0.7f, iTween.EaseType.easeInOutQuad);
            }

            yield return new WaitForSeconds(0.8f);
            ReplaceImage.sprite = Resources.Load<Sprite>(GameManager.instance.CurrentDressupItem.getInGameImageName());
            ReplaceImage.gameObject.SetActive(true);
            ParticleManger.instance.ShowStarParticle(ReplaceImage.gameObject);
            CurrentItem.transform.localScale = Vector3.zero;
            if (ClickItem == 0)
            {
                otherDress.SetActive(false);
            }
            StopAllCoroutines();
            flagBtnClick = true;
            Next.SetActive(true);
            ShowNext();
            if (ClickItem < 7)
            {
                clickedButtonArray[ClickItem + 1].GetComponent<Button>().interactable = true;
            }
        }
    }

    public void OnClickItemsButtons(int tag)
    {
        SoundManager.instance.PlayButtonClickSound();
        currentTag = tag;
        if (lastTag != tag)
        {
            print("value is" + tag + "" + lastTag);
            gridsGoesOut();
            Invoke("gridComesInn", 0.1f);
            counter++;
            //CallAds();
        }
    }

    void CallAds()
    {
        if (counter % 3 == 0)
        {
            print("Counter =" + counter);
            AdsManager.Instance.ShowInterstitial("Call Ads");
        }
    }

    private void gridsGoesOut()
    {
        if (lastTag != -1)
        {
            MoveAction(Grids[lastTag], GridStartPoint, 0.3f, iTween.EaseType.easeInBack);

        }
    }
    private void gridComesInn()
    {
        MoveAction(Grids[currentTag], GridEndPoint, 0.3f, iTween.EaseType.linear);
        lastTag = currentTag;
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
        } else
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
    private void GirlInstantiate()
    {
        GameManager.instance.player.SetMakeup(Instantiate(dressedGirl));
    }

    void levelCompleteShow()
    {
        SoundManager.instance.PlayButtonClickSound();
        LevelCompletePanel.SetActive(true);
        AdsManager.Instance.HideMREC();
        cashTextLevelcomplete.text = FormatNumber(PlayerPrefs.GetInt("PlayerCash")).ToString();
        Invoke("NothanskButtonActive", 3.0f);
    }

    public void NothanskButtonActive()
    {
        NothanksButton.SetActive(true);
    }

    public void nextLevelBtn()
    {
        SoundManager.instance.PlayButtonClickSound();
        AdsManager.Instance.ShowInterstitial("Ad Show on click button next scene");
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
    }

    public void MainMenu()
    {
        SoundManager.instance.PlayButtonClickSound();
        NavigationManager.instance.ReplaceScene(GameScene.MAINMENU);
    }



    #endregion
}
