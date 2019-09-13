using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetUpOperationCanvas : MonoBehaviour
{
    public Text cashBalanceText, unitValueText, totalValueText;
    public InputField inputField;
    public Button buttonBuy, buttonSell;
    private int totalValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        totalValueText.text = "El valor total de las acciones es:" + totalValue + " COP";
    }

    // Update is called once per frame
    void Update()
    {
        cashBalanceText.text = SetUpMainCanvas.sharedInstance.cashBalanceText.text;
        unitValueText.text = "Valor unitario: " + SetUpMainCanvas.sharedInstance.lastPriceText.text;
        totalValueText.text = "El valor total de las acciones es:" + totalValue + " COP";
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

            //ShowToast(true);
            
            MenuManager.sharedInstance.HideOperationCanvas();
            MenuManager.sharedInstance.ShowMainCanvas();
        }
        else
        {
            //ShowToast(false);
        }
    }

    public void Sell()
    {
        SetUpMainCanvas.sharedInstance.UpdateCashBalance(totalValue, true);
        SetUpMainCanvas.sharedInstance.UpdateSharesMarket(int.Parse(inputField.text), false);
        SetUpMainCanvas.sharedInstance.UpdateTotalBalance();

        //ShowToast(true);

        MenuManager.sharedInstance.HideOperationCanvas();
        MenuManager.sharedInstance.ShowMainCanvas();
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
            toastParams[1] = "Saldo insuficiente";
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
