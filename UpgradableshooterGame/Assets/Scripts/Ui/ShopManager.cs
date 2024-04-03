using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public int coins;
    public TMP_Text coinsText;
    public ShopItemSD[] shopitemSO;
    public GameObject[] shopPanelsGO;
    public ShopTemplate[] shopPanels;
    public Button[] myPurchaseButtons;
     
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < shopitemSO.Length; i++)
            shopPanelsGO[i].gameObject.SetActive(true);
        coinsText.text = "Coins: " + coins.ToString();
        LoadPanels();
        CheckPurchaseable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckPurchaseable()
    {
        for (int i = 0; i < shopitemSO.Length; i++)
        {
            if (coins >= shopitemSO[i].basecost)
            {
                myPurchaseButtons[i].interactable = true;
            }
            else
            {
                myPurchaseButtons[i].interactable = false;
            }
        }
    }
    public void PurchaseItem(int btnNo)
    {
        if (coins >= shopitemSO[btnNo].basecost)
        {
            coins =  coins - shopitemSO[btnNo].basecost;
            coinsText.text = "Coins: " + coins.ToString();
            CheckPurchaseable();
        }
    }

    public void AddCoins()
    {
        coins++;
        coinsText.text = "Coins: " + coins.ToString();
        CheckPurchaseable();
    }

    public void LoadPanels()
    {
        for (int i = 0; i < shopitemSO.Length; i++)
        {
            shopPanels[i].titleText.text = shopitemSO[i].title;
            shopPanels[i].descriptionText.text = shopitemSO[i].description;
            shopPanels[i].priceText.text = "Coins " + shopitemSO[i].basecost.ToString();
        }
    }
}
