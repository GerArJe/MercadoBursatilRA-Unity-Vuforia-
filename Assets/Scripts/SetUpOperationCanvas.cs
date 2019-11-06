using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetUpOperationCanvas : MonoBehaviour
{
    public Text cashBalanceText, unitValueText, totalValueText, sharesMarketText;
    public InputField inputField;
    public Button buttonBuy, buttonSell;
    private int totalValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        SetUpMainCanvas.sharedInstance.UpdateLastPrice(0);
        cashBalanceText.text = "Saldo en efectivo: " + 
            SetUpMainCanvas.sharedInstance.GetCashBalance() + " COP";
        unitValueText.text = "Valor unitario: " + 
            SetUpMainCanvas.sharedInstance.GetLastPrice() + " COP";
        sharesMarketText.text = "Tus acciones: " + SetUpMainCanvas.sharedInstance.GetSharesMarket();
        totalValueText.text = 
            "El valor total de las acciones es: $" + string.Format("{0:#,#}", totalValue) + " COP";
    }

    // Update is called once per frame
    void Update()
    {
        //totalValue = int.Parse(inputField.text) * SetUpMainCanvas.sharedInstance.GetLastPrice();

        cashBalanceText.text = SetUpMainCanvas.sharedInstance.cashBalanceText.text;
        unitValueText.text = "Valor unitario: " + SetUpMainCanvas.sharedInstance.lastPriceText.text;
        sharesMarketText.text = "Tus acciones: " + SetUpMainCanvas.sharedInstance.GetSharesMarket();
        totalValueText.text = 
            "El valor total de las acciones es: $" + string.Format("{0:#,#}", totalValue) + " COP";
    }

    //actualizar el totalValue
    public void UpdateTotalValue()
    {
        totalValue = int.Parse(inputField.text) * SetUpMainCanvas.sharedInstance.GetLastPrice();
    }

    //comprar acciones --> Este implica modificar una serie de variables
    public void Buy()
    {
        if (totalValue <= SetUpMainCanvas.sharedInstance.GetCashBalance())
        {
            SetUpMainCanvas.sharedInstance.UpdateCashBalance(totalValue, false);
            SetUpMainCanvas.sharedInstance.UpdateSharesMarket(int.Parse(inputField.text), true);
            SetUpMainCanvas.sharedInstance.UpdateTotalBalance();

            ShowToast(true);
            
            MenuManager.sharedInstance.HideOperationCanvas();
            MenuManager.sharedInstance.ShowMainCanvas();
            inputField.Select();
            inputField.text = "";
        }
        else
        {
            ShowToast(false);
        }
    }

    //vender acciones --> Este implica modificar una serie de variables
    public void Sell()
    {
        if (int.Parse(inputField.text) <= SetUpMainCanvas.sharedInstance.GetSharesMarket())
        {
            SetUpMainCanvas.sharedInstance.UpdateCashBalance(totalValue, true);
            SetUpMainCanvas.sharedInstance.UpdateSharesMarket(int.Parse(inputField.text), false);
            SetUpMainCanvas.sharedInstance.UpdateTotalBalance();

            ShowToast(true);

            MenuManager.sharedInstance.HideOperationCanvas();
            MenuManager.sharedInstance.ShowMainCanvas();
            inputField.Select();
            inputField.text = "";
        }
        else
        {
            ShowToast(false);
        }
        
    }

    //Mostar toast de la operación
    private void ShowToast(bool operationState)
    {
        #if UNITY_ANDROID

        AndroidJavaClass toastClass = 
                    new AndroidJavaClass("android.widget.Toast");
 
         object[] toastParams = new object[3];
         AndroidJavaClass unityActivity = 
           new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
         toastParams[0] = 
                      unityActivity.GetStatic<AndroidJavaObject>
                                ("currentActivity");
        if (operationState)
        {
            toastParams[1] = "Operación exitosa";
        }
        else
        {
            toastParams[1] = "Operación no valida";
        }
        
         toastParams[2] = toastClass.GetStatic<int>
                                ("LENGTH_LONG");
 
         AndroidJavaObject toastObject = 
                         toastClass.CallStatic<AndroidJavaObject>
                                       ("makeText", toastParams);
         toastObject.Call ("show");

         #endif
     }
}
