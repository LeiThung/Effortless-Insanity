using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SkinsBtn : MonoBehaviour
{
    [SerializeField] int sceneNum;
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(Skinsbtn);
    }

    private void Skinsbtn()
    {
        SceneManager.LoadScene(sceneNum);
    }
}
