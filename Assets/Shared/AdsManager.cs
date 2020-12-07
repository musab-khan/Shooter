using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    // Start is called before the first frame update
    string AppStoreId = "3929222";
    string PlayStoreId = "3929223";
    string rewardVideoAd = "rewardedVideo";
    string interstitialAd = "video";
    [SerializeField]
    bool isTargetPlayStore = true;
    [SerializeField]
    bool isTestAd = true;
    public static event System.Action ReviveEvent;

    private void Start()
    {
        Advertisement.AddListener(this);
        InitializeAd();

    }

    void InitializeAd()
    {
        if (isTargetPlayStore)
        {
            Advertisement.Initialize(PlayStoreId, isTestAd);
            return;
        }
        else
        {
            Advertisement.Initialize(AppStoreId, isTestAd);
        }
    }
    public void PlayInterstitialAd()
    {
        if (!Advertisement.IsReady(interstitialAd))
        {
            return;
        }
        else
        {
            Advertisement.Show(interstitialAd);
        }
    }
    public void PlayRewardedAd()
    {
        if (!Advertisement.IsReady(rewardVideoAd))
        {
            return;
        }
        else
        {
            Advertisement.Show(rewardVideoAd);
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        //throw new System.NotImplementedException();
        if (placementId == interstitialAd)
        {
            Debug.Log("interstitial ready");
        }
        if (placementId == rewardVideoAd)
        {
            Debug.Log("rewarded ready");
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("Ads error");
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("Ad started playing");
    }
    public void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (placementId == rewardVideoAd)
        {
            switch (showResult)
            {
                case ShowResult.Failed:
                    Debug.Log("some error");
                    break;
                case ShowResult.Skipped:
                    Debug.Log("Skipped");
                    break;
                case ShowResult.Finished:
                    if (placementId == interstitialAd)
                    {
                        Debug.Log("Here is ur interstitial Reward");
                    }
                    else if (placementId == rewardVideoAd)
                    {
                        Debug.Log("Revive called");
                        ReviveEvent();
                    }

                    break;
            }
        }
    }
    public void skipAd()
    {

    }
}