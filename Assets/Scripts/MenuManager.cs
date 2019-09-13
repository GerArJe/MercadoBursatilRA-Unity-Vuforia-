using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager sharedInstance;

    public Canvas mainCanvas;
    public Canvas operationCanvas;

    private void Awake()
    {
        if(sharedInstance == null)
        {
            sharedInstance = this;
        }
    }

    private void Start()
    {
        ShowMainCanvas();
        HideOperationCanvas();
    }

    //Metodos para mostrar y ocultar los diferentes canvas
    public void ShowMainCanvas() => mainCanvas.enabled = true;

    public void HideMainCanvas() => mainCanvas.enabled = false;

    public void ShowOperationCanvas() => operationCanvas.enabled = true;

    public void HideOperationCanvas() => operationCanvas.enabled = false;
}
