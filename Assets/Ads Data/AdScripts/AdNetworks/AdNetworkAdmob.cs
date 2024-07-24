﻿using UnityEngine;
using GoogleMobileAds.Api;
using System;
using GameAnalyticsSDK;

public class AdNetworkAdmob : AdNetworkBase
{
    #region Fields & Properties
    BannerView bannerView, mrecView;
    InterstitialAd interstitialAd;
    RewardedAd rewardedAd;
    AppOpenAd appOpenAd;

    int bannerIndex, collapsibleIndex, mrecIndex, interIndex, rewardIndex, appOpenIndex;
    bool m_IsShowingAppOpenAd;
    bool BannerStatus;

    bool LoadingAppOpen;
    [System.NonSerialized] public bool ShowAppOpenOnLoad;
    AdImpressionData bannerImp, mrecImp, interImp, rewardedImp, appOpenImp;

    string interAdUnitId;
    string rewardAdUnitId;

    #endregion

    #region SDK Initialize
    public override void Initialize()
    {
        MobileAds.SetiOSAppPauseOnBackground(true);
        //SetConfigurations();
        MobileAds.RaiseAdEventsOnUnityMainThread = false;
        MobileAds.Initialize(HandleInitCompleteAction);
        AppStateEventNotifier.AppStateChanged += AdsManager.Instance.OnAppStateChanged;
    }

    void SetConfigurations()
    {
        RequestConfiguration config = new RequestConfiguration.Builder()
        .SetTagForUnderAgeOfConsent(AdsManager.Instance.IsForFamily ? TagForUnderAgeOfConsent.True : TagForUnderAgeOfConsent.False)
        .build();

        MobileAds.SetRequestConfiguration(config);
    }

    private void HandleInitCompleteAction(InitializationStatus status)
    {
        ThreadDispatcher.Enqueue(() =>
        {
            isInitialized = true;

            RequestRewardedAd();
            if (!AdConstants.AdsRemoved)
            {
                RequestInterstitial();
                if (!AdsManager.Instance.IsForFamily)
                    RequestAppOpenAd();
            }

            AdsManager.OnAdmobInitSuccess?.Invoke();
        });
    }

    #endregion

    #region Banner Ad
    public void ShowBanner()
    {
        if (!isInitialized) return;

        BannerStatus = true;
        if (bannerView != null)
            bannerView.Show();
        else
            RequestBanner();
    }

    void RequestBanner()
    {
        string adUnitId = AdsManager.Instance.TestAds ? AdConstants.GetAdmobTestID(AdFormat.Banner) : AdsManager.Instance.BannerIDs[bannerIndex];
        if (string.IsNullOrEmpty(adUnitId)) return;

        int width = (AdsManager.Instance.BannerSize == BannerWidth.Full) ? AdSize.FullWidth : 320;
        AdSize adSize = AdSize.GetCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth(width);

        if (bannerView != null)
            bannerView.Destroy();

        bannerImp = new AdImpressionData(bannerIndex, adUnitId, AdFormat.Banner);
        bannerView = new BannerView(adUnitId, adSize, AdsManager.Instance.BannerPos);
        GameAnalyticsILRD.SubscribeAdMobImpressions(adUnitId, bannerView);

        bannerView.OnBannerAdLoaded += BannerView_OnBannerAdLoaded;
        bannerView.OnBannerAdLoadFailed += BannerView_OnBannerAdLoadFailed;
        bannerView.OnAdPaid += BannerView_OnAdPaid;
        bannerView.LoadAd(CreateAdRequest());

    }

    private void BannerView_OnBannerAdLoaded()
    {
        ThreadDispatcher.Enqueue(() =>
        {
            if (!BannerStatus)
                HideBanner();
        });
    }

    private void BannerView_OnBannerAdLoadFailed(LoadAdError obj)
    {
        ThreadDispatcher.Enqueue(() =>
        {
            bannerIndex++;
            if (bannerIndex >= AdsManager.Instance.BannerIDs.Length)
                DestroyBanner();
            else
                RequestBanner();
        });
    }

    private void BannerView_OnAdPaid(AdValue value)
    {
        ThreadDispatcher.Enqueue(() =>
        {
            AnalyticsManager.ReportRevenue_Admob(value, bannerImp);
        });
    }

    public void HideBanner()
    {
        if (bannerView != null)
            bannerView.Hide();

        BannerStatus = false;
    }

    public void DestroyBanner()
    {
        if (bannerView != null)
        {
            bannerView.Destroy();
            bannerView = null;
        }
        bannerIndex = 0;
        BannerStatus = false;
    }

    #endregion

    #region MREC Ad

    public void ShowMREC()
    {
        if (!isInitialized) return;

        if (mrecView != null)
            mrecView.Show();
        else
            RequestMREC();
    }

    void RequestMREC()
    {
        string adUnitId = AdsManager.Instance.TestAds ? AdConstants.GetAdmobTestID(AdFormat.Banner) : AdsManager.Instance.MrecIDs[mrecIndex];
        if (string.IsNullOrEmpty(adUnitId)) return;

        if (mrecView != null)
            mrecView.Destroy();

        mrecImp = new AdImpressionData(mrecIndex, adUnitId, AdFormat.MREC);
        mrecView = new BannerView(adUnitId, new AdSize(300, 250), AdsManager.Instance.MrecPos);
        GameAnalyticsILRD.SubscribeAdMobImpressions(adUnitId, mrecView);

        mrecView.OnBannerAdLoadFailed += MrecView_OnBannerAdLoadFailed;
        mrecView.OnBannerAdLoaded += MrecView_OnBannerAdLoaded;
        mrecView.OnAdPaid += MrecView_OnAdPaid;
        mrecView.LoadAd(CreateAdRequest());
    }

    private void MrecView_OnBannerAdLoaded()
    {
        ThreadDispatcher.Enqueue(() =>
        {
            if (!AdsManager.Instance.MrecStatus)
                HideMREC();
        });
    }

    private void MrecView_OnBannerAdLoadFailed(LoadAdError obj)
    {
        ThreadDispatcher.Enqueue(() =>
        {
            mrecIndex++;
            if (mrecIndex >= AdsManager.Instance.MrecIDs.Length)
                AdsManager.Instance.DestroyMREC();
            else
                RequestMREC();
        });
    }

    private void MrecView_OnAdPaid(AdValue value)
    {
        ThreadDispatcher.Enqueue(() =>
        {
            AnalyticsManager.ReportRevenue_Admob(value, mrecImp);
        });
    }

    public void HideMREC()
    {
        if (mrecView != null)
            mrecView.Hide();
    }

    public void DestroyMREC()
    {
        if (mrecView != null)
        {
            mrecView.Destroy();
            mrecView = null;
        }

        mrecIndex = 0;
    }

    #endregion

    #region Interstitial Ad
    public void ShowInterstitial()
    {
        interstitialAd.Show();
    }

    public override bool HasInterstitial(bool doRequest)
    {
        if (!isInitialized) return false;

        if (interstitialAd != null && interstitialAd.CanShowAd())
            return true;
        else
        {
            if (doRequest)
                RequestInterstitial();
            return false;
        }
    }

    void RequestInterstitial()
    {
        interAdUnitId = AdsManager.Instance.TestAds ? AdConstants.GetAdmobTestID(AdFormat.Interstitial) : AdsManager.Instance.InterstitialIDs[interIndex];
        if (string.IsNullOrEmpty(interAdUnitId)) return;

        if (interstitialAd != null)
            interstitialAd.Destroy();

        interImp = new AdImpressionData(interIndex, interAdUnitId, AdFormat.Interstitial);
        InterstitialAd.Load(interAdUnitId, CreateAdRequest(), InterstitialLoadCallback);
    }

    void InterstitialLoadCallback(InterstitialAd ad, LoadAdError loadError)
    {
        ThreadDispatcher.Enqueue(() =>
        {
            if (loadError == null && ad != null) // Success
            {
                interstitialAd = ad;
                interstitialAd.OnAdPaid += InterstitialAd_OnAdPaid;
                interstitialAd.OnAdImpressionRecorded += InterstitialAd_OnAdImpressionRecorded;
                interstitialAd.OnAdFullScreenContentClosed += InterstitialAd_OnAdFullScreenContentClosed;
                GameAnalyticsILRD.SubscribeAdMobImpressions(interAdUnitId, interstitialAd);
            }
            else // Failed to Load Interstitial
            {
                interIndex++;
                if (interIndex >= AdsManager.Instance.InterstitialIDs.Length)
                    interIndex = 0;
                else
                    RequestInterstitial();
            }
        });
    }

    private void InterstitialAd_OnAdPaid(AdValue value)
    {
        ThreadDispatcher.Enqueue(() =>
        {
            AnalyticsManager.ReportRevenue_Admob(value, interImp);
        });
    }

    private void InterstitialAd_OnAdImpressionRecorded()
    {
        ThreadDispatcher.Enqueue(() =>
        {
            AnalyticsManager.ReportPlacementEvent(AdNetwork.Admob, AdsManager.Instance.InterstitialType);
        });
    }

    private void InterstitialAd_OnAdFullScreenContentClosed()
    {
        ThreadDispatcher.Enqueue(() =>
        {
            AdsManager.Instance.InvokeReward();
            interIndex = 0;
            RequestInterstitial();
        });
    }

    #endregion

    #region Rewarded Ad

    public void ShowRewardedAd()
    {
        rewardedAd.Show(RewardedAd_OnUserEarnedReward);
    }

    public override bool HasRewarded(bool doRequest)
    {
        if (!isInitialized) return false;

        if (rewardedAd != null && rewardedAd.CanShowAd())
            return true;
        else
        {
            if (doRequest)
                RequestRewardedAd();
            return false;
        }
    }

    public void RequestRewardedAd()
    {
        rewardAdUnitId = AdsManager.Instance.TestAds ? AdConstants.GetAdmobTestID(AdFormat.Rewarded) : AdsManager.Instance.RewardedIDs[rewardIndex];
        if (string.IsNullOrEmpty(rewardAdUnitId)) return;

        if (rewardedAd != null)
            rewardedAd.Destroy();

        rewardedImp = new AdImpressionData(rewardIndex, rewardAdUnitId, AdFormat.Rewarded);
        RewardedAd.Load(rewardAdUnitId, CreateAdRequest(), RewardedLoadCallback);
    }

    void RewardedLoadCallback(RewardedAd ad, LoadAdError loadError)
    {
        ThreadDispatcher.Enqueue(() =>
        {
            if (loadError == null && ad != null) // Success
            {
                rewardedAd = ad;
                rewardedAd.OnAdPaid += RewardedAd_OnAdPaid;
                rewardedAd.OnAdImpressionRecorded += RewardedAd_OnAdImpressionRecorded;
                rewardedAd.OnAdFullScreenContentClosed += RewardedAd_OnAdFullScreenContentClosed;
                GameAnalyticsILRD.SubscribeAdMobImpressions(rewardAdUnitId, rewardedAd);
            }
            else // Failed to Load Rewarded
            {
                rewardIndex++;
                if (rewardIndex >= AdsManager.Instance.RewardedIDs.Length)
                    rewardIndex = 0;
                else
                    RequestRewardedAd();
            }
        });
    }

    private void RewardedAd_OnAdPaid(AdValue value)
    {
        ThreadDispatcher.Enqueue(() =>
        {
            AnalyticsManager.ReportRevenue_Admob(value, rewardedImp);
        });
    }

    private void RewardedAd_OnAdImpressionRecorded()
    {
        ThreadDispatcher.Enqueue(() =>
        {
            AnalyticsManager.ReportPlacementEvent(AdNetwork.Admob, AdFormat.Rewarded);
        });
    }

    private void RewardedAd_OnAdFullScreenContentClosed()
    {
        ThreadDispatcher.Enqueue(() =>
        {
            rewardIndex = 0;
            RequestRewardedAd();
        });
    }

    private void RewardedAd_OnUserEarnedReward(Reward e)
    {
        ThreadDispatcher.Enqueue(() =>
        {
            AdsManager.Instance.InvokeReward();
        });
    }

    #endregion

    #region AppOpen

    public void RequestAppOpenAd()
    {
        string adUnitId = AdsManager.Instance.TestAds ? AdConstants.GetAdmobTestID(AdFormat.AppOpen) : AdsManager.Instance.AppOpenIDs[appOpenIndex];
        if (string.IsNullOrEmpty(adUnitId)) return;

        LoadingAppOpen = true;
        appOpenImp = new AdImpressionData(appOpenIndex, adUnitId, AdFormat.AppOpen);
        if (appOpenAd != null)
            appOpenAd.Destroy();

        AppOpenAd.Load(adUnitId, Screen.orientation, CreateAdRequest(), AppOpenResponse);
    }

    public void AppOpenResponse(AppOpenAd ad, LoadAdError error)
    {
        ThreadDispatcher.Enqueue(() =>
        {
            LoadingAppOpen = false;
            if (error == null && ad != null)
            {
                appOpenAd = ad;
                appOpenAd.OnAdFullScreenContentOpened += AppOpenAd_OnAdFullScreenContentOpened;
                appOpenAd.OnAdFullScreenContentClosed += AppOpenAd_OnAdFullScreenContentClosed;
                appOpenAd.OnAdFullScreenContentFailed += AppOpenAd_OnAdFullScreenContentFailed;
                appOpenAd.OnAdPaid += AppOpenAd_OnAdPaid;

                if (ShowAppOpenOnLoad)
                {
                    ShowAppOpenOnLoad = false;
                    ShowAppOpen();
                }
            }
            else
                LoadNextAppOpen();
        });
    }

    private void AppOpenAd_OnAdFullScreenContentOpened()
    {
        ThreadDispatcher.Enqueue(() =>
        {
            m_IsShowingAppOpenAd = true;
        });
    }

    private void AppOpenAd_OnAdFullScreenContentClosed()
    {
        ThreadDispatcher.Enqueue(() =>
        {
            appOpenIndex = 0;
            DestroyAppOpen();
            RequestAppOpenAd();

            AdsManager.Instance.ResumeAllBanners();
        });
    }

    private void AppOpenAd_OnAdFullScreenContentFailed(AdError obj)
    {
        ThreadDispatcher.Enqueue(LoadNextAppOpen);
    }

    private void AppOpenAd_OnAdPaid(AdValue value)
    {
        ThreadDispatcher.Enqueue(() =>
        {
            AnalyticsManager.ReportRevenue_Admob(value, appOpenImp);
        });
    }

    public void ShowAppOpen()
    {
        if (!isInitialized || m_IsShowingAppOpenAd) return;

        if (appOpenAd != null)
        {
            AdsManager.Instance.HideAllBanners();
            appOpenAd.Show();
        }
        else if (!LoadingAppOpen)
            RequestAppOpenAd();
    }

    void LoadNextAppOpen()
    {
        DestroyAppOpen();
        appOpenIndex++;
        if (appOpenIndex >= AdsManager.Instance.AppOpenIDs.Length)
            appOpenIndex = 0;
        else
            RequestAppOpenAd();
    }

    void DestroyAppOpen()
    {
        m_IsShowingAppOpenAd = false;

        if (appOpenAd != null)
        {
            appOpenAd.Destroy();
            appOpenAd = null;
        }
    }

    #endregion

    #region Others
    public AdRequest CreateAdRequest()
    {
        if (ConsentManager.CanShowPersonalizedAds)
        {
            return new AdRequest.Builder()
                .AddExtra("npa", "0")
                .Build();
                //.AddExtra("npa", AdsManager.Instance.PersonalizedAds ? "0" : "1")
        }

        return new AdRequest();
    }

    #endregion



     #region Collabsable Banner Ad

    BannerView _bannerView;
    bool _CollBannerStatus;
    public void ShowCollBanner()
    {
        if (!isInitialized) return;

        _CollBannerStatus = true;
        if (_bannerView != null)
            _bannerView.Show();
        else
            CollabsRequestBanner();
    }


    void CollabsRequestBanner()
    {
        string _adUnitId = AdsManager.Instance.TestAds ? AdConstants.GetAdmobTestID(AdFormat.Collapsible) : AdsManager.Instance.CollapsibleID[collapsibleIndex];
        if (string.IsNullOrEmpty(_adUnitId)) return;

        // _bannerView.OnAdClosed += HandleOnAdClosed;
        if (_bannerView != null)
            _bannerView.Destroy();

        bannerImp = new AdImpressionData(collapsibleIndex,_adUnitId, AdFormat.Collapsible);
        _bannerView = new BannerView(_adUnitId, AdSize.Banner, AdsManager.Instance.BannerPos);
        GameAnalyticsILRD.SubscribeAdMobImpressions(_adUnitId, _bannerView);

        _bannerView.OnBannerAdLoaded += CollBannerView_OnBannerAdLoaded;
        _bannerView.OnBannerAdLoadFailed += CollBannerView_OnBannerAdLoadFailed;
        _bannerView.OnAdPaid += CollBannerView_OnAdPaid;
      _bannerView.OnAdFullScreenContentClosed += CollapsibleBanner_OnFullScreenContentClosed; // Register the new event
        //bannerView.LoadAd(CreateAdRequest());
        var adRequest = new AdRequest();
        adRequest.Extras.Add("collapsible", "bottom");
        _bannerView.LoadAd(adRequest);

    }
    private void CollBannerView_OnBannerAdLoaded()
    {
        ThreadDispatcher.Enqueue(() =>
        {
            if (!_CollBannerStatus)
                HideCollBanner();
        });
    }

    private void CollBannerView_OnBannerAdLoadFailed(LoadAdError obj)
    {
        ThreadDispatcher.Enqueue(() =>
        {
            DestroyCollBanner();
        });
    }


    private void CollBannerView_OnAdPaid(AdValue value)
    {
        ThreadDispatcher.Enqueue(() =>
        {
            AnalyticsManager.ReportRevenue_Admob(value, bannerImp);
        });
    }
     public Action OnCollapsibleBannerClosed;
    private void CollapsibleBanner_OnFullScreenContentClosed()
{
    ThreadDispatcher.Enqueue(() =>
    {
        // Perform actions needed when the collapsible banner's full-screen content is closed
        // For example, reset the collapsible banner index and request a new banner ad
        collapsibleIndex = 0;
        CollabsRequestBanner();
      //  AdsManager.Instance.ShowInterstitial();
       
        AdsManager.Instance.DestroyCollapsibleBanner();
        AdsManager.Instance.HideCollapsibleBanner();
         AdsManager.Instance.ShowBanner();
        // Optionally, invoke any specific callbacks or events you need
        OnCollapsibleBannerClosed?.Invoke();
         //AdsManager.Instance.DestroyCollapsibleBanner();
         //AdsManager.Instance.ShowBanner();
       // AdsManager.Instance.ShowBanner();
       // AdsManager.Instance.ShowMREC();
    });
}
    private void CollBannerView()
    {
        Debug.Log("Banner view full screen content opened.");
        ShowBanner();
        ShowInterstitial();
    }

    public void HideCollBanner()
    {
        if (_bannerView != null)
            _bannerView.Hide();

        _CollBannerStatus = false;
        Debug.Log("--hide1--");
    }

    public void DestroyCollBanner()
    {
        if (_bannerView != null)
        {
            _bannerView.Destroy();
            _bannerView = null;
              Debug.Log("--hide2--");
        }
        _CollBannerStatus = false;
          Debug.Log("--hide1--");
    }
// private void ListenToAdEvents()
// {
//     // Raised when an ad is loaded into the banner view.
//     _bannerView.OnBannerAdLoaded += () =>
//     {
//         Debug.Log("Banner view loaded an ad with response : "
//             + bannerView.GetResponseInfo());
//     };
//     // Raised when an ad fails to load into the banner view.
//     _bannerView.OnBannerAdLoadFailed += (LoadAdError error) =>
//     {
//         Debug.LogError("Banner view failed to load an ad with error : "
//             + error);
//     };
//     // Raised when the ad is estimated to have earned money.
//     _bannerView.OnAdPaid += (AdValue adValue) =>
//     {
//         Debug.Log(String.Format("Banner view paid {0} {1}.",
//             adValue.Value,
//             adValue.CurrencyCode));
//     };
//     // Raised when an impression is recorded for an ad.
//     _bannerView.OnAdImpressionRecorded += () =>
//     {
//         Debug.Log("Banner view recorded an impression.");
//                 ShowBanner();
//         ShowInterstitial();
//     };
//     // Raised when a click is recorded for an ad.
//     _bannerView.OnAdClicked += () =>
//     {
//         Debug.Log("Banner view was clicked.");
//                 ShowBanner();
//         ShowInterstitial();
//     };
//     // Raised when an ad opened full screen content.
//     _bannerView.OnAdFullScreenContentOpened += () =>
//     {
//         Debug.Log("Banner view full screen content opened.");
//         ShowBanner();
//         ShowInterstitial();
//     };
//     // Raised when the ad closed full screen content.
//     _bannerView.OnAdFullScreenContentClosed += () =>
//     {
//         Debug.Log("Banner view full screen content closed.");
//         ShowBanner();
//         ShowInterstitial();
//     };
//}
    #endregion
}