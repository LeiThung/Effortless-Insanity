using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsBtn : MonoBehaviour
{
    [SerializeField] GameObject settingsMenu;
    private bool settings;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(Btn);
    }

    private void Btn()
    {
        settings = !settings; 
        if(settings) settingsMenu.SetActive(true);
        else settingsMenu.SetActive(false);
    }
}
