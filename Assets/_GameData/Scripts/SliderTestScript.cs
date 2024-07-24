using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using System;
using TMPro;
using Unity.VisualScripting;

public class SliderTestScript : MonoBehaviour
{

    public int currentRewardMultiplier = 1;

    public Slider slider_RewardMultiplier;
    public List<RewardSliderData> multiplierRewardValues;

    public Text text_ClaimValue;
    public Text text_gainCoin;


    public static SliderTestScript instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    public void OnEnable()
    {
        AdsManager.Instance.ShowInterstitial("Ad show on level complete");
    }
    private void Start()
    {
        StartClaimRewardMultiplier();
        
        Debug.Log(text_gainCoin.text +  "Before Multiply value");
    }
    public void StartClaimRewardMultiplier()
    {
        slider_RewardMultiplier.DOValue(slider_RewardMultiplier.maxValue, 0.75f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
        var rewardMultiplierValue = multiplierRewardValues[(int)slider_RewardMultiplier.value - 1];
    }
    public void Update()
    {
        //StartClaimRewardMultiplier();
        text_ClaimValue.text = multiplierRewardValues[(int)slider_RewardMultiplier.value - 1].rewardValue.ToString() + "x";
    }
    public void Button_ClaimRewardMultiplier()
    {
        int totalcash = PlayerPrefs.GetInt("PlayerCash");

        slider_RewardMultiplier.DOKill();
        var rewardMultiplierValue = multiplierRewardValues[(int)slider_RewardMultiplier.value - 1];

        currentRewardMultiplier = rewardMultiplierValue.rewardValue;
        slider_RewardMultiplier.wholeNumbers = false;
        currentRewardMultiplier = Mathf.RoundToInt(currentRewardMultiplier);

        slider_RewardMultiplier.DOValue(rewardMultiplierValue.sliderValue, 0.1f);

        int finalCoinsToAdd = 0;
        finalCoinsToAdd = totalcash * currentRewardMultiplier;
        text_gainCoin.text = finalCoinsToAdd.ToString();

        //---new add lines for update cash---
        PlayerPrefs.SetInt("PlayerCash", finalCoinsToAdd); // Save updated PlayerCash value in PlayerPrefs
        PlayerPrefs.Save(); // PlayerPrefs data ko save karo
        Debug.Log(finalCoinsToAdd +    "After Multiply value check work or not??????");

    }

    [Serializable]
    public class RewardSliderData
    {
        public int rewardValue;
        public float sliderValue;
    }
}
