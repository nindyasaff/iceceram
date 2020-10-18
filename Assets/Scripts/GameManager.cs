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
    private string nameItem;

    public Text coinText;
    public Text diamondText;

    public Text coinTextShopPanel;
    public Text diamondTextShopPanel;

    public Image shopPanel;

    void Start()
    {
        if(instance != null)
        {
            instance = null;
        }
        else
        {
            instance = this;
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
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
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
}
