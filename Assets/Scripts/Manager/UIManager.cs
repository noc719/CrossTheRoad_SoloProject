using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class UIManager : Manager<UIManager>
{
    public TextMeshProUGUI coinScoreTxt;
    public TextMeshProUGUI distanceScoreTxt;
    public GameObject gameOverUI;

    
    public void UpdateScoreText()
    {
        coinScoreTxt.text = GameManager.Instance.CoinScore.ToString();
        distanceScoreTxt.text =GameManager.Instance.DistanceScore.ToString();
    }
}
