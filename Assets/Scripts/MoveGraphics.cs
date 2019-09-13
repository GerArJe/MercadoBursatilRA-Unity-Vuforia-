using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGraphics : MonoBehaviour
{
    int countPosition = 0;

    Vector3 destination = new Vector3(-50, 0, 0);

    //Deplazar el grafico a razon de la variable destination
    public void MoveGraphicPosition()
    {
        this.transform.position = this.transform.position + destination;
        countPosition++;
        SetUpMainCanvas.sharedInstance.UpdateLastPrice(countPosition);
        SetUpMainCanvas.sharedInstance.UpdateTotalBalance();
        SetUpMainCanvas.sharedInstance.UpdateBalanceDifference();
    }
}
