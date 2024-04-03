using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public int coins;
    public TMP_Text cointText;
    public ShopItemSD[] shopitemSD;
    public ShopTemplate[] shopPanels;
     
    // Start is called before the first frame update
    void Start()
    {
        cointText.text = "Coins: " + coins.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCoins()
    {
        coins++;
        cointText.text = "Coins: " + coins.ToString();
        
    }

    public void LoadPanels()
    {
        for (int i = 0; i < shopitemSD.Length; i++)
        {
            shopPanels[i].titleText.text = shopitemSD[i].title;
            shopPanels[i].descriptionText.text = shopitemSD[i].description;
            shopPanels[i].priceText.text = "Coins" + shopitemSD[i].basecost.ToString();
        }
    }
}
