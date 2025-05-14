using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject _panel;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Test()
    {
        SceneManager.LoadScene(1);
    }

    public void AfficherPanel()
    {
        _panel.SetActive(true); 
    }

    public void FermerPanel()
    {
        _panel.SetActive(false);
    }

    public void Quitter()
    {
        Application.Quit();
    }
}
