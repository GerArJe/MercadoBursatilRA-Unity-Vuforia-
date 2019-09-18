using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SetUpMainCanvas : MonoBehaviour
{
    public static SetUpMainCanvas sharedInstance;

    public Button buttonNext;

    public Text totalBalanceText, balanceDifferenceText, lastPriceText, cashBalanceText;

    private int totalBalance;
    private int previousTotalBalance = 0;
    private int balanceDifference = 0;
    private int lastPrice;
    private int previousLastPrice;
    private int cashBalance = 200000000;
    private int sharesMarket = 0;

    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateTotalBalance();
    }

    private void Update()
    {
        lastPriceText.text = lastPrice + " COP";
        if (lastPrice >= previousLastPrice)
        {
            lastPriceText.color = Color.green;
        }
        else
        {
            lastPriceText.color = Color.red;
        }

        totalBalanceText.text = "Saldo Total: " + totalBalance + " COP";

        balanceDifferenceText.text = "Diferencia de Saldo: " + balanceDifference + " COP";
        if (balanceDifference >= 0)
        {  
            balanceDifferenceText.color = Color.green;
        }
        else
        {
            balanceDifferenceText.color = Color.red;
        }

        cashBalanceText.text = "Saldo en efectivo: " + cashBalance + " COP";
    }

    //actualizar el valor del Last Price
    public void UpdateLastPrice(int position)
    {
        previousLastPrice = lastPrice;
        if (ChangeScene.sharedInstance.currentCompany.Equals(Company.CementosArgos)){
            lastPrice = DataGraphics.sharedInstance.ValueDataArgosForPosition(position);
            if(position+1 == DataGraphics.sharedInstance.GetSizeDataCementosArgos())
            {
                buttonNext.enabled = false;
            }
        }else if (ChangeScene.sharedInstance.currentCompany.Equals(Company.Bancolombia))
        {
            lastPrice = DataGraphics.sharedInstance.ValueBancolombiaForPosition(position);
            if (position + 1 == DataGraphics.sharedInstance.GetSizeDataBancolombia())
            {
                buttonNext.enabled = false;
            }
        }
        else if (ChangeScene.sharedInstance.currentCompany.Equals(Company.Ecopetrol))
        {
            lastPrice = DataGraphics.sharedInstance.ValueDataEcopetrolForPosition(position);
            if (position + 1 == DataGraphics.sharedInstance.GetSizeDataEcopetrol())
            {
                buttonNext.enabled = false;
            }
        }
    }

    //actualizar el valor del Total Balance
    public void UpdateTotalBalance()
    {
        previousTotalBalance = totalBalance;
        totalBalance = cashBalance + (lastPrice * sharesMarket);
    }

    //actualizar el valor del Balance Difference
    public void UpdateBalanceDifference()
    {
        balanceDifference = totalBalance - previousTotalBalance;
    }

    //actualizar el valor del Cash Balance, sumar o restar de acuerdo a la operación
    public void UpdateCashBalance(int cash, bool operation)
    {
        if (operation)
        {
            this.cashBalance = this.cashBalance + cash;
        }
        else
        {
            this.cashBalance = this.cashBalance - cash;
        }
        
    }

    //actulizar el valor del Shares Market, sumar o restar de acuerdo a la operación
    public void UpdateSharesMarket(int sharesMarket, bool operation)
    {
        if (operation)
        {
            this.sharesMarket = this.sharesMarket + sharesMarket;
        }
        else
        {
            this.sharesMarket = this.sharesMarket - sharesMarket;
        }
        
    }
    
    //Salir del modulo de AR
    public void ExitARScene()
    {
        Application.Quit();
    }

    //Gutters
    public int GetLastPrice() => lastPrice;
    public int GetCashBalance() => cashBalance;  
}
