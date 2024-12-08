using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCollectables : MonoBehaviour
{
    [SerializeField] int collectablesAmount;

    [Header("UI")]
    [SerializeField] TextMeshProUGUI collectablesTxt;

    public void AddCollectable()
    {
        collectablesAmount++;
        collectablesTxt.text = collectablesAmount.ToString();
    }

    public void RemoveCollectable(int amount)
    {
        collectablesAmount -= amount;   
        collectablesTxt.text = collectablesAmount.ToString();
    }
}
