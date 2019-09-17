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
    int[] dataBancolombia = {16939, 17139, 16840, 17238, 17019, 17059, 17936, 17736,
        17358, 17557, 17139, 17736, 17836, 17238, 17039, 17079, 17318, 17617, 17716,
        16840, 16740, 16581, 16441, 16800, 16401, 16541, 16082, 15285, 15544, 14926,
        15026, 15146, 14907, 15445, 15265, 14926, 14448, 14548, 13970, 13432, 13512,
        13571, 15146, 15186, 15564, 15445, 16541, 17537, 16979, 17537, 16820, 15763,
        16979, 17537, 17437, 16501, 16341, 17338, 17577, 17716, 16939, 17617, 18314,
        18733, 18932, 18733, 18773, 18474, 17537, 17437, 17358, 17637, 16740, 15285,
        15763, 16142, 15225, 15684, 15923, 15166, 15744, 16361, 15843, 16122, 16521,
        16879, 17398, 17039, 18454, 17238, 17657, 16142, 16541, 15943, 14926, 14548,
        14747, 13810, 13372, 13651, 14628, 14926, 14827, 14767, 14986, 15524, 16361,
        17657
};

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

    //Get de l tamaño de los vectores
    public int GetSizeDataCementosArgos() => dataCementosArgos.Length;

    public int GetSizeDataEcopetrol() => dataEcopetrol.Length;

    public int GetSizeDataBancolombia() => dataBancolombia.Length;
}
