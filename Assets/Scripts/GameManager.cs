using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int coin = 500;
    private int diamond = 500;
    public bool onClick = false;
    public bool isPlaying;

    public Text coinText;
    public Text diamondText;

    public Text coinTextShopPanel;
    public Text diamondTextShopPanel;

    public Image shopPanel;

    public Image gameOverPanel;
    public Image winPanel;

    void Start()
    {
        if(instance == null)
        {
            instance = this;
            isPlaying = true;
        }
    }

    void Update()
    {
        coinText.text = coin.ToString();
        diamondText.text = diamond.ToString();

        coinTextShopPanel.text = coin.ToString();
        diamondTextShopPanel.text = diamond.ToString();

        if (onClick)
        {
            GamePause();
        }
        else
        {
            GamePlay();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void BuyItem(string name)
    {
        onClick = true;

        if(name == "FastPower")
        {
            coin -= 300;
        }

        if(name == "Health")
        {
            coin -= 250;
        }

        if(coin <= 0)
        {
            coin = 0;
        }
    }

    public void ShopBtn()
    {
        onClick = true;
        shopPanel.gameObject.SetActive(true);
    }

    public void ExitBtn()
    {
        onClick = false;
        shopPanel.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        gameOverPanel.gameObject.SetActive(true);
        isPlaying = false;
    }

    public void Win()
    {
        winPanel.gameObject.SetActive(true);
        isPlaying = false;
    }

    void GamePause()
    {
        Time.timeScale = 0;
    }

    void GamePlay()
    {
        Time.timeScale = 1;
    }
}
