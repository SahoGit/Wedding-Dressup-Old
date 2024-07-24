using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    public GameObject currentItem;
    public GameObject LockImage;
    public GameObject ItemPurchasePanel;
    public GameObject CashPanel;
    public Text ItemPurchaseText;
    public Text cashText;
    public bool isLocked;
    public string name;
    public int id;
    public int amount;
    public GameObject noInternetConect;

    //void OnValidate()
    //{
    //    //LockImage = gameObject.transform.GetChild(2).gameObject;
    //
    //}

    // Start is called before the first frame update
    void Start()
    {
        
        unLockedOnStart();
        var prefName = name + id;

        if (PlayerPrefs.GetInt(prefName) == 0)
        {
            isLocked = true;
        }
        else
        {
            isLocked = false;
        }
        //Debug.Log(prefName);
        if (!isLocked)
        {
            if (this.gameObject.tag == "Lipstick")
            {
                this.gameObject.GetComponent<ApplicatorListener>().enabled = true;
            }
            if (this.gameObject.tag == "CheekShadeBrush")
            {
                this.gameObject.GetComponent<ApplicatorListener>().enabled = true;
            }
            if (this.gameObject.tag == "eyeshadebrush")
            {
                this.gameObject.GetComponent<ApplicatorListener>().enabled = true;
            }
            LockImage.SetActive(false);

        }
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

    public void BuyItems(GameObject clickedItem)
    {
        SoundManager.instance.PlayButtonClickSound();
        currentItem = clickedItem;
        int itemId = clickedItem.GetComponent<ItemController>().id;
        bool itemLocked = clickedItem.GetComponent<ItemController>().isLocked;
        string itemName = clickedItem.GetComponent<ItemController>().name;
        int itemAmount = clickedItem.GetComponent<ItemController>().amount;
        string prefName = clickedItem.GetComponent<ItemController>().name + clickedItem.GetComponent<ItemController>().id;



        if (itemLocked)
        {
            if (PlayerPrefs.GetInt("PlayerCash") >= itemAmount)
            {
                PlayerPrefs.SetInt("PlayerCash", PlayerPrefs.GetInt("PlayerCash") - itemAmount);
                PlayerPrefs.SetInt(prefName, 1);
                LockImage.SetActive(false);
                isLocked = false;
                SoundManager.instance.PlayScoreAddSound();
                ItemPurchasePanel.SetActive(false);
                cashText.text = FormatNumber(PlayerPrefs.GetInt("PlayerCash")).ToString();
                clickedItem.GetComponent<ApplicatorListener>().enabled = true;
            }
            else
            {
        Debug.Log(currentItem.name);
                SoundManager.instance.errorSound();
                CashPanel.SetActive(true);
                ItemPurchasePanel.SetActive(false);
            }

        }
    }

    public void BuyItemsWithAd(GameObject clickedItem)
    {
        SoundManager.instance.PlayButtonClickSound();
        currentItem = clickedItem;
        int itemId = clickedItem.GetComponent<ItemController>().id;
        bool itemLocked = clickedItem.GetComponent<ItemController>().isLocked;
        string itemName = clickedItem.GetComponent<ItemController>().name;
        int itemAmount = clickedItem.GetComponent<ItemController>().amount;
        string prefName = clickedItem.GetComponent<ItemController>().name + clickedItem.GetComponent<ItemController>().id;
        Debug.Log(clickedItem.name);



        if (itemLocked)
        {
            PlayerPrefs.SetInt(prefName, 1);
            LockImage.SetActive(false);
            isLocked = false;
            SoundManager.instance.PlayScoreAddSound();
            if(ItemPurchasePanel)
             ItemPurchasePanel.SetActive(false);
            cashText.text = FormatNumber(PlayerPrefs.GetInt("PlayerCash")).ToString();
            if(clickedItem.GetComponent<ApplicatorListener>()!=null)
                clickedItem.GetComponent<ApplicatorListener>().enabled = true;
        }
    }



    public void purchaseBtn()
    {

        SoundManager.instance.PlayButtonClickSound();
        //Debug.Log(currentItem.name);
        bool isLocked = currentItem.GetComponent<ItemController>().isLocked;
        GameObject LockImage = currentItem.GetComponent<ItemController>().LockImage;
        string prefName = currentItem.GetComponent<ItemController>().name + currentItem.GetComponent<ItemController>().id;
        int newAmount = currentItem.GetComponent<ItemController>().amount;
        if (PlayerPrefs.GetInt("PlayerCash") >= newAmount)
        {
            PlayerPrefs.SetInt("PlayerCash", PlayerPrefs.GetInt("PlayerCash") - newAmount);
            PlayerPrefs.SetInt(prefName, 1);
            LockImage.SetActive(false);
            isLocked = false;
            SoundManager.instance.PlayScoreAddSound();
            ItemPurchasePanel.SetActive(false);
            cashText.text = FormatNumber(PlayerPrefs.GetInt("PlayerCash")).ToString();
            if (currentItem.GetComponent<ApplicatorListener>() != null)
                currentItem.GetComponent<ApplicatorListener>().enabled = true;
            
        }
        else
        {
            SoundManager.instance.errorSound();
            CashPanel.SetActive(true);
            ItemPurchasePanel.SetActive(false);
        }



    }

    void noInternetConectClose()
    {
        noInternetConect.SetActive(false);
    }

    void unLockedOnStart()
    {
        PlayerPrefs.SetInt("Lipstick1", 1);
        PlayerPrefs.SetInt("Lipstick4", 1);

        PlayerPrefs.SetInt("BlushOn1", 1);
        PlayerPrefs.SetInt("BlushOn4", 1);

        PlayerPrefs.SetInt("EyeShadow1", 1);
        PlayerPrefs.SetInt("EyeShadow4", 1);

        PlayerPrefs.SetInt("EyeBrow1", 1);
        PlayerPrefs.SetInt("EyeBrow4", 1);

        PlayerPrefs.SetInt("EyeLash1", 1);
        PlayerPrefs.SetInt("EyeLash4", 1);

        PlayerPrefs.SetInt("EyeLense1", 1);
        PlayerPrefs.SetInt("EyeLense4", 1);

        PlayerPrefs.SetInt("Hair1", 1);
        PlayerPrefs.SetInt("Hair4", 1);

        PlayerPrefs.SetInt("Earring1", 1);
        PlayerPrefs.SetInt("Earring4", 1);

        PlayerPrefs.SetInt("WeddingDress1", 1);
        
        PlayerPrefs.SetInt("WeddingVeil1", 1);
        
        PlayerPrefs.SetInt("WeddingHair1", 1);
        
        PlayerPrefs.SetInt("WeddingHeadWear1", 1);
        
        PlayerPrefs.SetInt("WeddingNecklace1", 1);
        
        PlayerPrefs.SetInt("WeddingEarrings1", 1);
        
        PlayerPrefs.SetInt("WeddingFlower1", 1);
        
        PlayerPrefs.SetInt("WeddingShoes1", 1);
        
        PlayerPrefs.SetInt("FashionDress1", 1);
        
        PlayerPrefs.SetInt("FashionBag1", 1);
        
        PlayerPrefs.SetInt("FashionHair1", 1);
        
        PlayerPrefs.SetInt("FashionBreslet1", 1);
        
        PlayerPrefs.SetInt("FashionNecklace1", 1);
        
        PlayerPrefs.SetInt("FashionEarrings1", 1);
        
        PlayerPrefs.SetInt("FashionShoes1", 1);
    }
}
