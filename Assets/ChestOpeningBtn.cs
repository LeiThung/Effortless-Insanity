using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChestOpeningBtn : MonoBehaviour
{
    [SerializeField] int sceneNum;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ChestOpeningbtn);
    }
    
    private void ChestOpeningbtn()
    {
        SceneManager.LoadScene(sceneNum);
    }
}
