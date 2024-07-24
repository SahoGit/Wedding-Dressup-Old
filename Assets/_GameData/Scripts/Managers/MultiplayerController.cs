using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MultiplayerController : MonoBehaviour
{
    #region Variables,Constants & Initializers

    public bool isWinner = false;

    public GameObject loadingImage;
    public GameObject MyCharacter, Character, CharacterBody;
    public RectTransform CharacterEndPoint, AiCharacterEndPoint, MyCharacterEndPoint, WinnerPlaceEndPoint;
    public GameObject characterMakeup, characterMakeupPosition;
    public GameObject dressedGirl;
    public Image weddingBg;
    public Image Dress;
    public Image Veil;
    public Image hairs;
    public Image HeadWear;
    public Image Necklace;
    public Image Earring;
    public Image Flower;
    public Image Shoes;

    /// Makeup Items Image Here /// 

    public Image LeftLens;
    public Image RightLens;
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

    public Text AiScore;
    public Text PlayerScore;

    //Arrays here

    public Sprite[] DressList;
    public Sprite[] VeilList;
    public Sprite[] HairsList;
    public Sprite[] ShoesList;
    public Sprite[] HeadWearList;
    public Sprite[] NecklaceList;
    public Sprite[] EarringList;
    public Sprite[] FlowerList;
    public Sprite[] LipsList;
    public Sprite[] LensList;
    public Sprite[] weddingBgList;

    int totalAiScore = 0;
    int totalPlayerScore = 0;

    public GameObject OpponentWinner;
    public GameObject YouWinner;

    public int winingRangeFrom;
    public int winingRangeTo;

    public Transform[] sparksPostions;

    public Text cashText;

    public Text PlayerScoreStore;

    int AiScoreInt;
    int PlayerScoreInt;

    public GameObject NothanksButton;
    public GameObject successPanel;
    public GameObject failedPanel;


    public GameObject levelEndParticles;
    public GameObject finishPartical1;
    public GameObject finishPartical2;
    public GameObject finishPartical3;
    public GameObject finishPartical4;
    public GameObject finishPartical5;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.instance.PlayGPSound(1);
        //cashText.text = FormatNumber(PrefsManager.instance.GetPlayerCash()).ToString();
        RefreshCharacter();
        AiScoreInt = 0;
        PlayerScoreInt = 0;
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

    private int getRandomNumber(int length)
    {
        int number = Random.Range(0, (length - 1));
        totalAiScore = totalAiScore + number;
        return number;
    }


    private int getPlayerScoreNew(int AiScore)
    {
        int randomInt = Random.Range(winingRangeFrom, winingRangeTo);
        if (randomInt == 0)
        {
            randomInt += 1;
        }
        int playerCalculatedScore = AiScore + randomInt;
        return playerCalculatedScore;
    }


    private int getPlayerScore(int AiScore)
    {
        int randomInt = Random.Range(winingRangeFrom, winingRangeTo);
        if (PlayerPrefs.GetInt("GameStart") == 1)
        {
            PlayerPrefs.SetInt("GameCount", PlayerPrefs.GetInt("GameCount") + 1);
            if (PlayerPrefs.GetInt("GameCount") >= 3)
            {
                PlayerPrefs.SetInt("GameStart", 0);
            }
            randomInt += 10;
        }
        else if (randomInt == 0)
        {
            randomInt += 1;
        }
        int playerCalculatedScore = AiScore + randomInt;
        return playerCalculatedScore;
    }
    private void SetUpCharacter()
    {
        Dress.GetComponent<Image>().sprite = DressList[getRandomNumber(DressList.Length)];
        Veil.GetComponent<Image>().sprite = VeilList[getRandomNumber(VeilList.Length)];
        hairs.GetComponent<Image>().sprite = HairsList[getRandomNumber(HairsList.Length)];
        Shoes.GetComponent<Image>().sprite = ShoesList[getRandomNumber(ShoesList.Length)];
        HeadWear.GetComponent<Image>().sprite = HeadWearList[getRandomNumber(HeadWearList.Length)];
        Necklace.GetComponent<Image>().sprite = NecklaceList[getRandomNumber(NecklaceList.Length)];
        Earring.GetComponent<Image>().sprite = EarringList[getRandomNumber(EarringList.Length)];
        Flower.GetComponent<Image>().sprite = FlowerList[getRandomNumber(FlowerList.Length)];
        Lips.GetComponent<Image>().sprite = LipsList[getRandomNumber(LipsList.Length)];
        Invoke("calculateScore", 2.0f);
        Invoke("ChooseWinner", 12.5f);
    }

    public void calculateScore()
    {
        totalAiScore = totalAiScore + 40;
        calculator(totalAiScore, "Ai");
        calculator(getPlayerScore(totalAiScore), "Player");
        //PlayerScore.text = getPlayerScore(totalAiScore).ToString();
    }

    public void calculator(int points, string playerName)
    {
        int number1 = Random.Range(21, 25);
        int number2 = Random.Range(26, 30);
        int number3 = points - (number1 + number2);
        int totalNumber = number1 + number2 + number3;

        if (playerName == "Ai")
        {
            StartCoroutine(AddAiScore(0, number1, 0));
            StartCoroutine(AddAiScore(2, number2, 1));
            StartCoroutine(AddAiScore(4, number3, 2));
        } 
        else if(playerName == "Player")
        {
            StartCoroutine(AddPlayerScore(6, number1, GameObject.Find("Makeup(Clone)")));
            StartCoroutine(AddPlayerScore(8, number2, GameObject.Find("Shoes")));
            StartCoroutine(AddPlayerScore(10, number3, GameObject.Find("Flower")));
        }
    }

    IEnumerator AddAiScore(int time, int number, int sparksPostionsId)
    {
        yield return new WaitForSeconds(time);
        AiScoreInt = AiScoreInt + number;
        AiScore.text = AiScoreInt.ToString();
        ParticleManger.instance.ShowStarParticle(sparksPostions[sparksPostionsId].gameObject);
        ParticleManger.instance.ShowStarParticle(AiScore.gameObject);
        SoundManager.instance.PlayScoreAddSound();
    }

    IEnumerator AddPlayerScore(int time, int number, GameObject characterPos)
    {
        yield return new WaitForSeconds(time);
        PlayerScoreInt = PlayerScoreInt + number;
        PlayerScore.text = PlayerScoreInt.ToString();
        ParticleManger.instance.ShowStarParticle(characterPos.gameObject);
        ParticleManger.instance.ShowStarParticle(PlayerScore.gameObject);
        //Debug.Log(GameObject.Find("Character").transform.GetChild(0).gameObject.transform.GetChild(1).transform.GetChild(0).gameObject.transform.position);
        SoundManager.instance.PlayScoreAddSound();
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

    void ChooseWinner()
    {

        Debug.Log(PlayerScore.text);
        Debug.Log(AiScore.text);

        if (int.Parse(AiScore.text) > int.Parse(PlayerScore.text))
        {
            YouWinner.SetActive(false);
            OpponentWinner.SetActive(true);
            ParticleManger.instance.ShowStarParticle(OpponentWinner.gameObject);
            ParticleManger.instance.ShowStarParticle(YouWinner.gameObject);
            SoundManager.instance.PlayScoreAddSound();
            Invoke("OppWinner", 0.1f);
        }
        else
        {
            isWinner = true;
            YouWinner.SetActive(true);
            OpponentWinner.SetActive(false);
            ParticleManger.instance.ShowStarParticle(OpponentWinner.gameObject);
            ParticleManger.instance.ShowStarParticle(YouWinner.gameObject);
            SoundManager.instance.PlayScoreAddSound();
            Invoke("MeWinner", 0.1f);
            //PlayerScoreStore.text = PlayerScore.text;
        }
    }

    void OppWinner()
    {
        MoveAction(MyCharacter, MyCharacterEndPoint, 0.5f, iTween.EaseType.linear);
        MoveAction(Character, WinnerPlaceEndPoint, 1.5f, iTween.EaseType.linear);
        Invoke("zoomCharacter", 1.5f);
        Invoke("PanelShow", 5.0f);
    }

    void MeWinner()
    {
        MoveAction(Character, AiCharacterEndPoint, 0.5f, iTween.EaseType.linear);
        MoveAction(MyCharacter, WinnerPlaceEndPoint, 1.5f, iTween.EaseType.linear);
        Invoke("zoomMyCharacter", 1.5f);
        Invoke("PanelShow", 5.0f);
    }

    void zoomMyCharacter()
    {
        ScaleAction(MyCharacter, 1.4f, 2.0f, iTween.EaseType.easeInBounce, iTween.LoopType.none);
        MyCharacter.transform.GetChild(1).GetComponent<Image>().enabled = false;
        MyCharacter.transform.GetChild(1).GetChild(0).GetComponent<Text>().enabled = false;
    }

    void zoomCharacter()
    {
        ScaleAction(Character, 0.8f, 2.0f, iTween.EaseType.easeInBounce, iTween.LoopType.none);
        Character.transform.GetChild(2).GetComponent<Image>().enabled = false;
        Character.transform.GetChild(2).GetChild(0).GetComponent<Text>().enabled = false;
    }

    public void NothanskButtonActive()
    {
        NothanksButton.SetActive(true);
    }

    void PanelShow()
    {
        if (PlayerPrefs.GetInt("playerMode") == 1)
        {
            if (int.Parse(AiScore.text) > int.Parse(PlayerScore.text))
            {
                failedPanel.SetActive(true);
            }
            else
            {
                SoundManager.instance.PlayPlayerWin();
                finishPartical1.SetActive(true);
                finishPartical2.SetActive(true);
                finishPartical3.SetActive(true);
                finishPartical4.SetActive(true);
                finishPartical5.SetActive(true);
                levelEndParticles.SetActive(true);
                PlayerPrefs.SetInt("PlayerCash", PlayerPrefs.GetInt("PlayerCash") + 500);
                successPanel.SetActive(true);
                Invoke("NothanskButtonActive", 3.0f);
                AdsManager.Instance.HideMREC();
                cashText.text = FormatNumber(PlayerPrefs.GetInt("PlayerCash")).ToString();
            }
        }
    }

    public void closePanel(GameObject parent)
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
        NavigationManager.instance.ReplaceScene(GameScene.SELECTIONVIEW);
        parent.SetActive(false);
    }

    private void ScaleAction(GameObject obj, float ScaleFactor, float time, iTween.EaseType type, iTween.LoopType loop)
    {
        Hashtable tweenParams = new Hashtable();
        tweenParams.Add("scale", new Vector3(ScaleFactor, ScaleFactor, 0));
        tweenParams.Add("time", time);
        //tweenParams.Add("looptype", loop);
        //tweenParams.Add("easetype", type);
        iTween.ScaleTo(obj, tweenParams);
    }

    public void RefreshCharacter()
    {
        
        totalAiScore = 0;
        SetUpCharacter();
    }
}
