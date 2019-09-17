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
    public Company currentCompany;

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
    // Se utliza una serie de if para saber en que escena se encuetra para determinar
    // las opciones del dropdown
    public void GoToNewScene()
    {
        if (currentCompany.Equals(Company.CementosArgos))
        {
            switch (dropdown.value)
            {
                case 0:
                    SceneManager.LoadScene("ARScene Cementos Argos");
                    currentCompany = Company.CementosArgos;
                    break;
                case 1:
                    SceneManager.LoadScene("ARScene Bancolombia");
                    currentCompany = Company.Bancolombia;
                    break;
                case 2:
                    SceneManager.LoadScene("ARScene Ecopetrol");
                    currentCompany = Company.Ecopetrol;
                    break;
                default:
                    break;
            }
        }else if (currentCompany.Equals(Company.Bancolombia))
        {
            switch (dropdown.value)
            {
                case 0:
                    SceneManager.LoadScene("ARScene Bancolombia");
                    currentCompany = Company.Bancolombia;
                    break;
                case 1:
                    SceneManager.LoadScene("ARScene Cementos Argos");
                    currentCompany = Company.CementosArgos;
                    break;
                case 2:
                    SceneManager.LoadScene("ARScene Ecopetrol");
                    currentCompany = Company.Ecopetrol;
                    break;
                default:
                    break;
            }
        }else if (currentCompany.Equals(Company.Ecopetrol))
        {
            switch (dropdown.value)
            {
                case 0:
                    SceneManager.LoadScene("ARScene Ecopetrol");
                    currentCompany = Company.Ecopetrol;
                    break;
                case 1:
                    SceneManager.LoadScene("ARScene Cementos Argos");
                    currentCompany = Company.CementosArgos;
                    break;
                case 2:
                    SceneManager.LoadScene("ARScene Bancolombia");
                    currentCompany = Company.Bancolombia;
                    break;
                default:
                    break;
            }
        }
        
    }
}

