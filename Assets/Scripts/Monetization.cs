using UnityEngine;
using UnityEngine.Advertisements;

public class Monetization : MonoBehaviour
{
    [SerializeField] private GameObject _rewardButtonCross;
    [SerializeField] private int _deathsToAd;
    [SerializeField] private PlayerMoney _playerMoney;
    private bool _canShowAds = true;
    
    private void Start()
    {
        Advertisement.Initialize("4472617");
        
        if(PlayerPrefs.HasKey("DeathsCount"))
            if (PlayerPrefs.GetInt("DeathsCount") >= _deathsToAd)
            {
                TryShowBanner();
                PlayerPrefs.SetInt("DeathsCount", 0);
            }
    }
    
    public void OnRewardButtonClick()
    {
        if(_canShowAds)
            TryShowRewardedVideo();
    }
    
    private void SetRewardButton(bool canShowAds)
    {
        _canShowAds = canShowAds;
        _rewardButtonCross.SetActive(!_canShowAds);
    }

    private void TryShowRewardedVideo()
    {
        if (Advertisement.IsReady("Rewarded_Android"))
        {
            Advertisement.Show("Rewarded_Android");
            SetRewardButton(false);
            _playerMoney.ChangeMoney(5);
        }
    }

    private void TryShowBanner()
    {
        if (Advertisement.IsReady("Banner_Android"))
        {
            Advertisement.Show("Banner_Android");
        }
    }
}
