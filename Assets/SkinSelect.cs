using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SkinSelect : MonoBehaviour
{
    public List<GameObject> skins = new List<GameObject>();
    private Vector3 startPosition = Vector3.zero; // Starting position for spawning
    [SerializeField] float xOffset = 20f; // Distance between each skin
    [SerializeField] Button leftBtn;
    [SerializeField] Button rightBtn;
    [SerializeField] Button setSkinBtn;
    [SerializeField] SharedData data;
    public int num = 0;


    private void Start()
    {
        SpawnSkins();
        leftBtn.onClick.AddListener(LeftBtn);
        rightBtn.onClick.AddListener(RightBtn);
        setSkinBtn.onClick.AddListener(SetSkinBtn);
    }

    // Update is called once per frame
    void Update()
    {
        BtnUpdater();
    }

    private void SpawnSkins()
    {
        Vector3 spawnPosition = startPosition;

        foreach (GameObject skin in skins)
        {
            if (skin != null) // Ensure the skin is not null
            {
                Instantiate(skin, spawnPosition, Quaternion.Euler(90, 0, 0));
                spawnPosition.x += xOffset; // Move to the next x position
            }
        }
    }

    private void BtnUpdater()
    {
        if (num < 0 || num >= skins.Count - 1)
        {
            leftBtn.gameObject.SetActive(false);
        }
        else leftBtn.gameObject.SetActive(true);
        if (num <= 0 || num > skins.Count)
        {
            rightBtn.gameObject.SetActive(false);
        }
        else rightBtn.gameObject.SetActive(true);
    }

    public void LeftBtn()
    {
        Vector3 pos = Camera.main.transform.position;
        Vector3 nextPos = new Vector3(pos.x + 20, pos.y, pos.z);
        Camera.main.transform.position = nextPos;
        num++;
    }

    public void RightBtn()
    {
        Vector3 pos = Camera.main.transform.position;
        Vector3 nextPos = new Vector3(pos.x - 20, pos.y, pos.z);
        Camera.main.transform.position = nextPos;
        num--;
    }

    public void SetSkinBtn()
    {
        data.savedObject = skins[num];
        SceneManager.LoadScene(1);
    }
}
