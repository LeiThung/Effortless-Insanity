using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playerhealth : MonoBehaviour
{
    [SerializeField] int health;
    [Range(0f, 1f)] public float invincibleAfterHitTime;

    private float timer;

    [Header("UI")]
    [SerializeField] Transform healthDisplay;
    [SerializeField] Image healthImg;
    [Range(0f, 200f)] public float offset;
    private List<Image> healthImgs = new List<Image>();
    [SerializeField] GameObject gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        SethealthDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I) && timer <= 0) TakeDamage();

        if(timer > 0f)
        {
            timer -= Time.deltaTime;
        }
    }

    private void SethealthDisplay()
    {
        // Spawn health images
        for (int i = 0; i < health; i++)
        {
            // Calculate the position for each health image
            Vector3 position = new Vector3(i * offset, 0, 0);

            // Instantiate the health image at the calculated position
            Image healthInstance = Instantiate(healthImg, healthDisplay);
            healthImgs.Add(healthInstance);

            // Set the local position to the calculated position
            healthInstance.transform.localPosition = position;
        }
    }

    public void TakeDamage()
    {
        timer = invincibleAfterHitTime;
        if(health > 0) health--;
        if(health <= 0)
        {
            Time.timeScale = 0f;
            gameOverScreen.SetActive(true);
        }
        UpdateHealthDisplay();
    }

    private void UpdateHealthDisplay()
    {
        int i = healthImgs.Count - 1;
        Image img = healthImgs[i];
        healthImgs.Remove(img);
        Destroy(img);
    }
}
