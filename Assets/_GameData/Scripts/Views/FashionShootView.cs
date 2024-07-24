using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FashionShootView : MonoBehaviour
{
    #region Variables, Constants & Initializers
    public GameObject loadingImage;
    private int bgCounter = 0;
    public Image fashionBg;
    public Sprite[] fashionSprites;
    public GameObject buttons;
    public RectTransform buttonsEndPoint;
    public GameObject bgButton, cameraButton;
    public GameObject frame;
    public GameObject character, characterStanding, characterPosition;
    public GameObject levelEndParticles;
    #endregion

    #region Lifecycle Methods

    // Use this for initialization
    void Start()
    {
        SoundManager.instance.PlayGPSound(1);
        Invoke("SetViewContents", 0.1f);
    }

    // Update is called once per frame
    void Update()
    {

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
        characterStanding.GetComponent<RectTransform>().localScale = new Vector3(0.72f, 0.72f, 0.72f);
        characterStanding.transform.SetSiblingIndex(0);
        characterStanding.GetComponent<RectTransform>().localPosition = new Vector3(97f, -103f, 0f);
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
        buttons.SetActive(true);
       // MoveAction(buttons, buttonsEndPoint, 0.5f, iTween.EaseType.easeInBounce);
        Invoke("DelayForSelectionScene", 3f);
    }

    void DelayForSelectionScene()
    {
        AdsManager.Instance.ShowInterstitial("DelayForSelectionScene");
        OnClickReplay();
    }
    #endregion


    #region Callback Method
    public void OnClickBgButton()
    {
        fashionBg.sprite = fashionSprites[bgCounter];
        bgCounter++;
        SoundManager.instance.PlayButtonClickSound();
        if (bgCounter > 4)
        {
            bgCounter = 0;
        }
    }

    public void OnClickCamera()
    {
        SoundManager.instance.PlaycameraClickSound();
        bgButton.SetActive(false);
        cameraButton.SetActive(false);
        frame.SetActive(true);
        ScaleAction(frame, 1.0f, 0.3f, iTween.EaseType.easeInBounce, iTween.LoopType.none);
        Invoke("buttonComes", 1.0f);
    }

    public void OnClickRateUs()
    {
        SoundManager.instance.PlayButtonClickSound();
        Application.OpenURL(AdsManager.Instance.RateUsLink);
    }

    public void OnClickrMoreGames()
    {
        SoundManager.instance.PlayButtonClickSound();
        Application.OpenURL(AdsManager.Instance.MoreGames);

    }

    public void OnClickReplay()
    {
        SoundManager.instance.PlayButtonClickSound();
        NavigationManager.instance.ReplaceScene(GameScene.SELECTIONVIEW);
    }

    #endregion
}
