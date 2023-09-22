using System.Collections;
using UnityEngine;
using TMPro; // Import TextMeshPro namespace
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public float startingTime = 45f; // Time in seconds for the game
    private float currentTime;

    public TextMeshProUGUI timerText; // Reference to TextMeshPro text component

    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;

            // Style based on remaining time
            if (currentTime <= 30)
                timerText.color = new Color32(255, 0, 0, 255); // Red
            else
                timerText.color = new Color32(0, 255, 0, 255); // Green

            timerText.text = Mathf.CeilToInt(currentTime).ToString(); // Round up and display as an integer
        }
        else
        {
            ReloadCurrentScene();
        }
    }

    void ReloadCurrentScene()
    {
        SceneManager.LoadScene(0);
    }
}
