using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using UnityEngine.Events;



public class AdManager : MonoBehaviour
{
    /*#region PUBLIC_VARS
    public static AdManager Instance;
    public Text text;
    public List<BannerView> bannerList;
    public int reqCount = 0;
    *//* public UnityEvent OnAdLoadedEvent;
     public UnityEvent OnAdFailedToLoadEvent;
     public UnityEvent OnAdOpeningEvent;
     public UnityEvent OnAdFailedToShowEvent;
     public UnityEvent OnUserEarnedRewardEvent;
     public UnityEvent OnAdClosedEvent;
     public UnityEvent OnAdLeavingApplicationEvent;*//*
    #endregion

    #region PRIVATE_VARS
    private string appId = "ca-app-pub-1534474541196511~3359154682";
    private string bannerId = "ca-app-pub-1534474541196511/3004480200";
    private string rewardedVideoId = "ca-app-pub-1534474541196511/5723827091";

    private BannerView bannerView;
    private RewardedAd rewardedAd;
    // private InterstitialAd interstitialAd;
    #endregion

    #region UNITY_CALLBACKS
    public void Awake()
    {
        Instance = this;
    }
    [Obsolete]
    private void Start()
    {
        MobileAds.Initialize(appId);
        StartCoroutine(LoadBanner());
    }
    #endregion

    #region PUBLIC_FUNCTIONS
    public void ShowBannerAd()
    {
        bannerView = GetEmptyBanner();
        Debug.Log("Show banner call");
        RequestBanner();
        bannerView.LoadAd(GetRequest());
    }

    private BannerView GetEmptyBanner()
    {
        return new BannerView(bannerId, AdSize.SmartBanner, AdPosition.Bottom);
    }

    private AdRequest GetRequest()
    {
        return new AdRequest.Builder().Build();
    }

    public void DestroyBannerAd()
    {
        if (bannerView != null)
            bannerView.Destroy();
    }
    public void RequestBanner()
    {
        bannerView.OnAdLoaded += HandleOnAdLoaded;
        bannerView.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        bannerView.OnAdOpening += HandleOnAdOpened;
        bannerView.OnAdClosed += HandleOnAdClosed;
        bannerView.OnAdLeavingApplication += HandleOnAdLeavingApplication;
    }

    public void RewardedAdLoad()
    {
        rewardedAd = new RewardedAd(rewardedVideoId);
        RewardsAdEvent();
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        rewardedAd.LoadAd(request);

    }
    public void ShowRewardedAd()
    {
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }
        else
            text.text = "ad not load now";
    }

    private void RewardsAdEvent()
    {
        // Called when an ad request has successfully loaded.
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;
    }
    #endregion

    #region PRIVATE_FUNCTIONS
    private void DestroyUnnecessaryBanner()
    {
        bannerView.Destroy();
    }
    #endregion

    #region CO-ROUTINES
    IEnumerator LoadBanner()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
            ShowBannerAd();
            StartCoroutine(DestroyBanner());
        }
    }
    IEnumerator DestroyBanner()
    {
        yield return new WaitForSeconds(9);
        DestroyUnnecessaryBanner();
    }
    #endregion

    #region EVENT_HANDLERS
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
        Debug.Log("ad loaded");
        // DestroyUnnecessaryBanner();
        text.text = (++reqCount).ToString();
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                            + args.Message);
        Debug.Log("ad load fail");
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
        Debug.Log("ad open");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
        Debug.Log("ad close");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }



    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
        text.text = "ad loaded";
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToLoad event received with message: "
                             + args.Message);
        text.text = "loadFailed";
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
        text.text = "open ad";
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdClosed event received");
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print(
            "HandleRewardedAdRewarded event received for "
                        + amount.ToString() + " " + type);
    }
    #endregion

    #region UI_CALLBACKS
    #endregion*/
}