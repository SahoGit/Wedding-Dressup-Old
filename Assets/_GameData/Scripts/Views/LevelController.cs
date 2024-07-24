using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public int levelId;
    public int careerLevelId;
    public bool isLocked;
    public GameObject levelNumberText;
    public GameObject lockBtn;
    public GameObject lockImg;
    public Sprite lockedImg;
    public Sprite UnLockedImg;
    public int levelCode;

    // Start is called before the first frame update

    void OnValidate()
    {
        //PlayerPrefs.SetInt("LevelPlayed", 30);
        //string[] digits = Regex.Split(this.gameObject.name, @"\D+");
        //foreach (string value in digits)
        //{
        //    int number;
        //    if (int.TryParse(value, out number))
        //    {
        //        levelId = int.Parse(value) - 1;
        //        levelNumberText.GetComponent<Text>().text = int.Parse(value).ToString();
        //    }
        //
        //
        //}
        //levelNumberText = this.gameObject.transform.GetChild(0).gameObject;
        //lockBtn = this.gameObject;

        //lockImg = this.gameObject.transform.GetChild(1).gameObject;


    }
    void Start()
    {
        if (PlayerPrefs.GetInt("LevelPlayed") >= levelId)
        {
            levelNumberText.SetActive(true);
            lockImg.SetActive(false);
            lockBtn.GetComponent<Image>().sprite = UnLockedImg;
            lockBtn.GetComponent<Button>().interactable = true;
            lockBtn.GetComponent<ActionManager>().enabled = true;
        }
        else
        {
            levelNumberText.SetActive(false);
            lockImg.SetActive(true);
            lockBtn.GetComponent<Image>().sprite = lockedImg;
            lockBtn.GetComponent<Button>().interactable = false;
            lockBtn.GetComponent<ActionManager>().enabled = false;
        }
    }
    //
    //
    //
    public void CareerModeLevelPlay(int playingLevelId)
    {
        SoundManager.instance.PlayButtonClickSound();
        PlayerPrefs.SetInt("levelPlayedId", levelId + 1);
        PlayerPrefs.SetInt("levelPlayedIdNew", levelId);
        PlayerPrefs.SetInt("careerLevelId", careerLevelId);
        //PlayerPrefs.SetInt("PlayingLevel", playingLevelId);
        if (levelCode == 0)
        {
            NavigationManager.instance.ReplaceScene(GameScene.CAREERMODEMAKEUP);
        }
        else if (levelCode == 1)
        {
            NavigationManager.instance.ReplaceScene(GameScene.CAREERMODEDRESSUP);
        }
        
    }
}
