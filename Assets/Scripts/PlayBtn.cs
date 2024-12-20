using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayBtn : MonoBehaviour
{
    [SerializeField] int scenenumber;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(Btn);
    }

    private void Btn()
    {
        SceneManager.LoadScene(scenenumber);
    }
}
