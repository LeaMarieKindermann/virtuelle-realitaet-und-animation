using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartBtn()
    {
        SceneManager.LoadScene("cyberBot");

        Debug.Log(" wurde gedrückt");
    }

    public void BeendenBtn()
    {
        Application.Quit();
    }
}
