using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum Company
{
    Ecopetrol,
    Bancolombia,
    CementosArgos
}

public class ChangeScene : MonoBehaviour
{
    public Company currentCompany = Company.CementosArgos;

    public static ChangeScene sharedInstance;

    public Dropdown dropdown;

    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
    }

    //Ir a nueva scena dependiendo del valor(indice) del Dropdown
    public void GoToNewScene()
    {
        switch (dropdown.value)
        {
            case 0: SceneManager.LoadScene("ARScene Cementos Argos");
                currentCompany = Company.Ecopetrol;
                break;
            case 1: SceneManager.LoadScene("ARScene Bancolombia");
                currentCompany = Company.Bancolombia;
                break;
            case 2: SceneManager.LoadScene("ARScene Ecopetrol");
                currentCompany = Company.CementosArgos;
                break;
        }
    }
}

