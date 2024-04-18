using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.XR;

public class ShopManager : MonoBehaviour
{
    public static int coins;
    public TMP_Text coinsText;
    public ShopItemSD[] shopitemSO;
    public GameObject[] shopPanelsGO, weaponsArray;
    public ShopTemplate[] shopPanels;
    public Button[] myPurchaseButtons;
    public TextMeshProUGUI[] myEquipTexts;
    private bool gekocht = false;
    private int btnEQ;
    // Start is called before the first frame update
    void Start()
    {
        coins = 0;
        for (int i = 0; i < shopitemSO.Length; i++)
            shopPanelsGO[i].gameObject.SetActive(true);
        coinsText.text = "Coins: " + coins.ToString();
        LoadPanels();
        CheckPurchaseable();
    }

    // Update is called once per frame
    void Update()
    {
        AddCoins();
    }

    public void CheckPurchaseable()
    {
        for (int i = 0; i < shopitemSO.Length; i++)
        {
            if (!gekocht)
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
            else myPurchaseButtons[btnEQ].interactable = false;
        }
    }
    public void PurchaseItem(int btnNo)
    {
        if (coins >= shopitemSO[btnNo].basecost)
        {
            btnEQ = btnNo;
            coins = coins - shopitemSO[btnNo].basecost;
            coinsText.text = "Coins: " + coins.ToString();
            myEquipTexts[btnEQ].text = ("Bought");
            for (int i = 0; i < weaponsArray.Length; i++)
            {
               //weaponsArray[i].
            }
            CheckPurchaseable();
        }
    }

    private void AddCoins()
    {
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
