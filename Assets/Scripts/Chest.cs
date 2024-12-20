using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] float viewItemTimer;

    [Header("LootTable")]
    public List<GameObject> commonLoot = new List<GameObject>();
    public List<GameObject> rareLoot = new List<GameObject>();
    public List<GameObject> epicLoot = new List<GameObject>();
    public List<GameObject> legendaryLoot = new List<GameObject>();

    [Header("Loot %")]
    [SerializeField] int commonpercentage;
    [SerializeField] int rarepercentage;
    [SerializeField] int epicpercentage;
    [SerializeField] int legendarypercentage;

    private Vector3 spawnPos;

    private float timer;

    void Start()
    {
        spawnPos = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        // Handle mouse click input
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            PerformRaycast(Input.mousePosition);
        }

        // Handle touch input for mobile
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            PerformRaycast(Input.GetTouch(0).position);
        }
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    private void PerformRaycast(Vector2 screenPosition)
    {
        if(timer <= 0)
        {
            // Cast a ray from the screen position to the world
            Ray ray = Camera.main.ScreenPointToRay(screenPosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Check if the object has the correct tag
                if (hit.collider.CompareTag("Chest"))
                {
                    OpenChest();
                }
            }
        }   
    }

    private void OpenChest()
    {
        int i = Random.Range(0, 100);

        // Define thresholds for loot rarity
        int legendaryThreshold = 100 - legendarypercentage;
        int epicThreshold = legendaryThreshold - epicpercentage;
        int rareThreshold = epicThreshold - rarepercentage;
        int commonThreshold = rareThreshold - commonpercentage;

        // Determine loot based on thresholds
        if (i >= legendaryThreshold)
        {
            SpawnObj(legendaryLoot[Random.Range(0, legendaryLoot.Count)]);
        }
        else if (i >= epicThreshold)
        {
            SpawnObj(epicLoot[Random.Range(0, epicLoot.Count)]);
        }
        else if (i >= rareThreshold)
        {
            SpawnObj(rareLoot[Random.Range(0, rareLoot.Count)]);
        }
        else
        {
            SpawnObj(commonLoot[Random.Range(0, commonLoot.Count)]);
        }
    }

    private void SpawnObj(GameObject obj)
    {
        GameObject spawned = Instantiate(obj, spawnPos, Quaternion.identity);
        Skin skin = obj.GetComponent<Skin>();
        if (!inventory.skins.Contains(skin))
        {
            inventory.skins.Add(skin);
#if UNITY_EDITOR
            UnityEditor.EditorUtility.SetDirty(inventory);
#endif
        }
        StartCoroutine(DestroyObj(spawned));
    }

    private IEnumerator DestroyObj(GameObject obj)
    {
        timer = viewItemTimer;
        yield return new WaitForSeconds(viewItemTimer);
        Destroy(obj);
    }
}
