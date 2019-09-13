using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataGraphics : MonoBehaviour
{
    public static DataGraphics sharedInstance;

    int[] dataCementosArgos = { 9000, 9150, 8870, 9400, 9130, 9000, 9110, 8990, 9400,
        9110, 9750, 10700, 10660, 10720, 11000, 10560, 11220,
        10800, 10960, 10400, 10980, 10800, 10780, 10960, 10980, 10880, 10640, 10560,
        10600, 10340, 9750, 9500, 10200, 9520, 8620, 8430, 8250, 8100, 8600, 8000,
        7700, 6500, 5800, 6030, 5850, 6700, 6600, 6550, 6600, 6100, 6250, 6450, 6400,
    };
    int[] dataEcopetrol = {0};
    int[] dataBancolombia = {0};

    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
    }

    //acceder a una posicion especifica del vector que 
    //contiene la data de cada uno de las empresas
    public int ValueDataArgosForPosition(int position) => dataCementosArgos[position];

    public int ValueDataEcopetrolForPosition(int position) => dataEcopetrol[position];

    public int ValueBancolombiaForPosition(int position) => dataBancolombia[position];

    //Getters
    public int GetSizeDataCementosArgos() => dataCementosArgos.Length;

    public int GetSizeDataEcopetrol() => dataEcopetrol.Length;

    public int GetSizeDataBancolombia() => dataBancolombia.Length;
}
