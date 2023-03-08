using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private string page;
  
    //cargamos el main
    public void LoadMain()
    {
        page = "main";
        SceneManager.LoadScene(page);
    }
}
