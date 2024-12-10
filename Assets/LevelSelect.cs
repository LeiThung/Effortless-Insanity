using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public Button[] levelButtons; // Array of level buttons
    public Sprite lockedImage;    // Image for locked levels
    public Sprite unlockedImage;  // Image for unlocked levels
    public Sprite completedImage; // Image for completed levels

    private int currentLevelUnlocked;

    private void Start()
    {
        // Load the unlocked level from PlayerPrefs, defaults to level 1 if not found
        currentLevelUnlocked = PlayerPrefs.GetInt("CurrentLevelUnlocked", 1);

        // Initialize buttons based on the current level unlocked
        UpdateButtonStates();
    }

    public void LevelCompleted(int level)
    {
        // Check if the completed level is the current one and unlock the next
        if (level == currentLevelUnlocked && currentLevelUnlocked < levelButtons.Length)
        {
            currentLevelUnlocked++;
            PlayerPrefs.SetInt("CurrentLevelUnlocked", currentLevelUnlocked); // Save progress
            UpdateButtonStates();
        }
    }

    private void UpdateButtonStates()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 < currentLevelUnlocked) // Levels already completed
            {
                levelButtons[i].interactable = true;
                levelButtons[i].GetComponent<Image>().sprite = completedImage; // Use completed image
                levelButtons[i].GetComponentInChildren<TextMeshProUGUI>(true).gameObject.SetActive(true);
            }
            else if (i + 1 == currentLevelUnlocked) // Current level unlocked
            {
                levelButtons[i].interactable = true;
                levelButtons[i].GetComponent<Image>().sprite = unlockedImage; // Use unlocked image#
                levelButtons[i].GetComponentInChildren<TextMeshProUGUI>(true).gameObject.SetActive(true);
            }
            else // Future levels locked
            {
                levelButtons[i].interactable = false;
                levelButtons[i].GetComponent<Image>().sprite = lockedImage; // Use locked image
                levelButtons[i].GetComponentInChildren<TextMeshProUGUI>().gameObject.SetActive(false);
            }
        }
    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
}
