using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Manager<GameManager>
{
    [SerializeField]
    private int coinScore = 0;
    public int CoinScore { get { return coinScore; } set { coinScore = value; } }
    [SerializeField]
    private int distanceScore = 0;
    public int DistanceScore { get { return distanceScore; } set{ distanceScore = value; } }

    public void GetCoinScore(int value)
    {
        coinScore += value;
        UIManager.Instance.UpdateScoreText();
    }

    public void GetDistanceScore(int value)
    {
        distanceScore += value;
        UIManager.Instance.UpdateScoreText();
    }


    public void GameOver()
    {
        UIManager.Instance.gameOverUI.SetActive(true);
    }

    public void Quit()
    {
        SceneManager.LoadScene("MainScene");
    }
}
