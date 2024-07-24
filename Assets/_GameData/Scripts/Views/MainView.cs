using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;

public class MainView : MonoBehaviour {

	#region Variables, Constants & Initializers
	public GameObject quitPopup, CashPopup, SettingPanel;
	public GameObject logo, playButton, rateButton, moreGamesButton, twinkleImage;
    public RectTransform logoEndPoint, playButtonEndPoint, rateButtonEndPoint, moreGamesButtonEndPoint;
    public GameObject arm;
	public Text cashtext;
	[SerializeField] Image soundon;
    [SerializeField] Image soundoff;

    private bool muted = false;

    public Button SFXButton;

    public Sprite onSprite;
    public Sprite offSprite;

    #endregion

    #region Lifecycle Methods

    // Use this for initialization
    void Start()
    {
        SoundManager.instance.PlayGPSound(0);
        Invoke ("SetViewContents", 0.1f);
		if (PlayerPrefs.GetString("playerName") == "")
		{
			PlayerPrefs.SetString("playerName", "Player_" + Random.Range(100, 999));
        }
		AdsManager.Instance.ShowBanner();
        cashtext.text = FormatNumber(PlayerPrefs.GetInt("PlayerCash"));
        Debug.Log("Check after update text " + cashtext.text);

        // Music script start---------------

        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }
        UpdateButtonIcon();
        // music script end--------------------

        // sfx sound //
        if (PlayerPrefs.GetInt("isSetting") == 0)
        {
            PlayerPrefs.SetInt("SoundController", 1);
            PlayerPrefs.SetInt("isSetting", 1);
        }
        // end ///

        // for sfx sound 
        if (PlayerPrefs.GetInt("SoundController") == 0)
        {
            SFXButton.transform.gameObject.GetComponent<Image>().sprite = offSprite;
        }
        else
        {
            SFXButton.transform.gameObject.GetComponent<Image>().sprite = onSprite;
        }

        //-----end------//

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

    // Update is called once per frame
    void Update () {
		#if UNITY_ANDROID || UNITY_WP8
				if (Input.GetKeyDown(KeyCode.Escape)) 
				{ 
					if (quitPopup != null) {
						quitPopup.SetActive(true);
					} else {
						OnQuitYesButtonClicked();
					}
				}
		
		#endif
    }

    void Destroy() {
		iTween.Stop ();
	}

	#endregion

	#region Callback Methods

	private void SetViewContents() {
       // armMovement();
       // titleMovement();
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
	private void RotateActionloop(GameObject obj,float rotationAmout,float time,iTween.EaseType actionType,iTween.LoopType loop)
	{
		Hashtable tweenParams = new Hashtable();
		tweenParams.Add ("z", rotationAmout);
		tweenParams.Add ("time", time);
		tweenParams.Add ("easetype", actionType);
		tweenParams.Add ("looptype", loop);
		iTween.RotateTo(obj, tweenParams);

	}
	private void MoveActionloop(GameObject obj,RectTransform pos,float time,iTween.EaseType actionType,iTween.LoopType loop)
	{
		Hashtable tweenParams = new Hashtable();
		tweenParams.Add ("x", pos.position.x);
		tweenParams.Add ("y", pos.position.y);
		tweenParams.Add ("time", time);
		tweenParams.Add ("easetype", actionType);
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
	private void ScaleAction(GameObject obj,float scaleval,float time,iTween.EaseType type,iTween.LoopType loop) {
		Hashtable tweenParams = new Hashtable();
		tweenParams.Add ("scale", new Vector3 (scaleval,scaleval, 0));
		tweenParams.Add ("time", time);
		tweenParams.Add ("easetype", type);
		tweenParams.Add ("looptype", loop);
		iTween.ScaleTo(obj, tweenParams);
	}

    //private void armMovement()
    //{
    //    RotateActionloop(arm, -12f, 3.0f, iTween.EaseType.linear, iTween.LoopType.pingPong);
    //}

    //private void titleMovement()
    //{
    //    MoveAction(logo, logoEndPoint, 1.0f, iTween.EaseType.easeInOutBounce);
    //    Invoke("MoreGamesMovement", 1.0f);
    //}

    //private void MoreGamesMovement()
    //{
    //    MoveAction(moreGamesButton,moreGamesButtonEndPoint, 0.5f, iTween.EaseType.linear);
    //    Invoke("rateusMovement", 0.5f);
    //}
    //private void rateusMovement()
    //{
    //    MoveAction(rateButton, rateButtonEndPoint, 0.5f, iTween.EaseType.linear);
    //    Invoke("playMovement", 1.0f);
    //}

    //private void playMovement()
    //{
    //    MoveAction(playButton,playButtonEndPoint, 0.5f, iTween.EaseType.easeInOutBounce);
    //    Invoke("twinkleActive", 0.5f);
    //}

    private void twinkleActive()
    {
        twinkleImage.SetActive(true);
    }

  
	#endregion

	#region Callback Methods


    // For BG Music On Off Functions Starting Point--------
	public void OnClickMusicOnOff()
	{
        SoundManager.instance.PlayButtonClickSound();
        AudioSource bgMusic = SoundManager.instance.bgSound.GetComponent<AudioSource>();
        if (muted == false)
        {
            muted = true;
            bgMusic.Pause();
            SoundManager.instance.PlayAndPause(false);
        }
        else
        {
            muted = false;
            Debug.Log("on" + muted);
            bgMusic.Play();
            SoundManager.instance.PlayAndPause(true);
        }

        Save();
        UpdateButtonIcon();
    }

    private void UpdateButtonIcon()
    {
        if (muted == false)
        {
            soundon.enabled = true;
            soundoff.enabled = false;
        }
        else
        {
            soundon.enabled = false;
            soundoff.enabled = true;
        }
    }

    private void Load()
    {
        ///New Update
        muted = PlayerPrefs.GetInt("muted") == 1;

        AudioSource bgMusic = SoundManager.instance.bgSound.GetComponent<AudioSource>();
        if (muted)
        {
            bgMusic.Pause();
        }
        else
        {
            bgMusic.Play();
        }
    }

    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }

    // End BG Music--------------

    // SFX Sound Start-----

    public void soundController()
    {
        if (PlayerPrefs.GetInt("SoundController") == 0)
        {
            PlayerPrefs.SetInt("SoundController", 1);
            SFXButton.transform.gameObject.GetComponent<Image>().sprite = onSprite;
        }
        else
        {
            PlayerPrefs.SetInt("SoundController", 0);
            SFXButton.transform.gameObject.GetComponent<Image>().sprite = offSprite;
        }
        SoundManager.instance.PlayButtonClickSound();
    }


    // End SFX Sound----

    public void OnPlayButtonClicked() {
        SoundManager.instance.PlayButtonClickSound();
        //AssignAdIds_CB.instance.CallInterstitialAd(Adspref.Menu);
        NavigationManager.instance.ReplaceScene(GameScene.SELECTIONVIEW);
    }

	public void OnRateUsButtonClicked() {
        SoundManager.instance.PlayButtonClickSound();

		//Application.OpenURL("");
        Application.OpenURL("market://details?id=com.bestonegames.mydream.makeup.wedding.fashionsalon");
    }

	public void OnMoreFunButtonClicked() {
        SoundManager.instance.PlayButtonClickSound();
		Application.OpenURL ("https://play.google.com/store/apps/dev?id=4826365601331502275");
	}

	public void OnNoAdsButtonClicked() {
		GameManager.instance.LogDebug ("NoAds Clicked");
	}

	public void OnPrivacyPolicyButtonClicked()
    {
        SoundManager.instance.PlayButtonClickSound();
        GameManager.instance.LogDebug ("PrivacyPolicy Clicked");
		Application.OpenURL ("https://doc-hosting.flycricket.io/pet-dragon-inc-policy/0eaa397d-d077-424f-9603-bc62ba307b2f/privacy");
	}

    public void OnSettingButtonClicked()
    {
        SoundManager.instance.PlayButtonClickSound();
		SettingPanel.SetActive(true);
		Debug.Log("Setting penel active");
    }

    public void OnDimondBarButtonClicked()
    {
        SoundManager.instance.PlayButtonClickSound();
        CashPopup.SetActive(true);
        Debug.Log("Dimond Bar panel Active");
    }

	public void OnClickCross()
	{
        SoundManager.instance.PlayButtonClickSound();
        if (CashPopup != null)
		{
			CashPopup.SetActive(false);
		}
		else
		{
			Debug.LogWarning("No assigned!...");
		}
	}

    public void OnGemsButtonClicked()
    {
        SoundManager.instance.PlayButtonClickSound();
        Debug.Log("Gems Bar panel Active");
        PlayerPrefs.SetInt("PlayerCash", PlayerPrefs.GetInt("PlayerCash") + 500);
        cashtext.text = FormatNumber(PlayerPrefs.GetInt("PlayerCash")).ToString();
        SoundManager.instance.PlayScoreAddSound();
    }

    public void OnQuitNoButtonClicked() {
		GameManager.instance.LogDebug ("QuitNo Clicked");
		SoundManager.instance.PlayButtonClickSound ();
        quitPopup.SetActive(false);
    }

	public void OnQuitYesButtonClicked() {
		SoundManager.instance.PlayButtonClickSound ();
		GameManager.instance.LogDebug ("QuitYes Clicked");
		Application.Quit ();
	}
	public void OnClickCrossSetting(GameObject parent)
	{
        SoundManager.instance.PlayButtonClickSound();
        parent.SetActive(false);
	}

    public void cashAdButton()
    {
        PlayerPrefs.SetInt("PlayerCash", PlayerPrefs.GetInt("PlayerCash") + 500);
        SoundManager.instance.PlayButtonClickSound();
        CashPopup.SetActive(false);
        SoundManager.instance.PlayScoreAddSound();
        cashtext.text = FormatNumber(PlayerPrefs.GetInt("PlayerCash")).ToString();
        //AdCode Here
    }
    #endregion
}