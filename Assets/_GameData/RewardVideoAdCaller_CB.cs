
using System;
using System.Collections;
using System.Collections.Generic;
//using ToastPlugin;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RewardVideoAdCaller_CB : MonoBehaviour
{

    //public static bool isRewardAd = false;
    public bool showPopup;
    public Text cashText;

    [DrawIf("showPopup", true)]
    public GameObject confirmationPopup;
    
    //[Tooltip("To Recognize Reward")]
    public int RewardInteger;
    public UnityEvent OnWatchVideoSuccess, OnWatchVideoFailed;
    //private void OnValidate()
    //{
    //    if (showPopup && confirmationPopup == null)
    //    {
    //        confirmationPopup = FindObjectOfType<RewardedVideoConfirmationPopup_CB>().gameObject;
    //        if (confirmationPopup == null)
    //        {
    //            Debug.LogError("Please Drag prefab ==> -Watch Video Confirmation popup- from Prefab folder in AdsScript.");
    //        }
    //    }
    //}

    public void CallRewardedVideo()
    {
        AdsManager.Instance.ShowRewarded(() =>
        {
            //SliderTestScript.instance.Button_ClaimRewardMultiplier();
            //int playerCash = PlayerPrefs.GetInt("PlayerCash"); // PlayerCash ki value ko PlayerPrefs se hasil karein
            //int multipliedValue = playerCash * 3; // PlayerCash ko 3 se multiply karein

            //cashText.text = multipliedValue.ToString(); // Multiply ki hui value ko string mein convert kar ke cashText mein display karein

            //Debug.Log("formattedValue update value with 3 digit" + multipliedValue);

            /////--------end------------------
            //int returnedValue = (int)CareerModeMakeUp.GetRewardMultiplier?.Invoke();

            // cashText.text = FormatNumber(PlayerPrefs.GetInt("PlayerCash")).ToString();
            //cashText.text = returnedValue.ToString();
            //Debug.Log("Returned Value:  " + returnedValue);
            // OnRewardComplete?.Invoke();
            VideoWatches();

        }, "get item by video");
        //try
        //{
        //    if (Application.internetReachability != NetworkReachability.NotReachable)
        //    {

        //        SoundManager.instance.PlayButtonClickSound();
        //        WatchRewardedVideoAd_CB.callBackObject = gameObject;
        //        if (showPopup)
        //        {
        //            confirmationPopup.SetActive(true);
        //        }
        //        else
        //        {

        //            WatchRewardedVideoAd_CB.instance.CallRewardedAd();
        //        }

        //    }
        //    else
        //    {
        //        ToastHelper.ShowToast("No, Network Available", true);
        //        RewardedVideoFailed();
        //    }
    //}
    //    catch (Exception ex)
    //    {
    //        GeneralScript._instance.SendExceptionEmail(ex.Message.ToString());
    //    }


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
    public void CallRewardedVideoLovin()
    {
        CallRewardedVideo();
    }

    public void WatchVideoOnly()
    {
        CallRewardedVideo();

     //   WatchRewardedVideoAd_CB.instance.CallRewardedAd();
    }
    void VideoWatches()
    {
        //try
        //{
            OnWatchVideoSuccess.Invoke();
            switch (RewardInteger)
            {
                case 0:
                    Debug.Log("Set rewarded here for index 0");
                    break;

            }

            if (showPopup)
            {
                confirmationPopup.SetActive(false);
            }
        //}
        //catch (Exception ex)
        //{
        //    GeneralScript._instance.SendExceptionEmail(ex.Message.ToString());
        //}
    }

    public void RewardedVideoFailed()
    {
        //Debug.Log("Failure With int : " + RewardInteger);
        OnWatchVideoFailed.Invoke();
    }
}

