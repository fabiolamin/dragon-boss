using UnityEngine;
using GoogleMobileAds.Api;
using System.Collections.Generic;

public class GameAds : MonoBehaviour
{
    private InterstitialAd interstitialAd;

    [SerializeField] private string interstitialId = "ca-app-pub-3940256099942544/1033173712";
    [SerializeField] private string rewardedId = "ca-app-pub-3940256099942544/5224354917";

    public RewardedAd RewardedAd { get; private set; }

    private void Awake()
    {
        //List<string> deviceIds = new List<string>() { AdRequest.TestDeviceSimulator };

        //deviceIds.Add("d3991624475b3dd3");

        //RequestConfiguration requestConfiguration =
        //    new RequestConfiguration.Builder()
        //    .SetTestDeviceIds(deviceIds).build();

        //MobileAds.SetRequestConfiguration(requestConfiguration);

        MobileAds.Initialize(initstatus => { });

        RequestInterstitialAd();
        RequestRewardedAd();
    }

    private void RequestInterstitialAd()
    {
        if (interstitialAd != null)
        {
            interstitialAd.Destroy();
        }

        interstitialAd = new InterstitialAd(interstitialId);
        interstitialAd.LoadAd(GetAdRequest());
    }

    private void RequestRewardedAd()
    {
        if (RewardedAd != null)
        {
            RewardedAd.Destroy();
        }

        RewardedAd = new RewardedAd(rewardedId);
        RewardedAd.LoadAd(GetAdRequest());
    }

    private AdRequest GetAdRequest()
    {
        return new AdRequest.Builder().Build();
    }

    public void ShowInterstitialAd()
    {
        if (interstitialAd.IsLoaded())
        {
            interstitialAd.Show();
            RequestInterstitialAd();
        }
    }

    public void ShowRewardedAd()
    {
        if (RewardedAd.IsLoaded())
        {
            RewardedAd.Show();
            RequestRewardedAd();
        }
    }
}
