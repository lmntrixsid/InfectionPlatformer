using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformeHealth : MonoBehaviour
{
    public float disappearTime = 3.0f;
    private float timer;
    private bool playerIsOnPlatform = false;
    private PlayerController playerController;

    void Start()
    {
        timer = disappearTime;
    }

    void Update()
    {
        if (playerIsOnPlatform)
        {
            if (playerController != null && Mathf.Approximately(playerController.CurrentSpeed, 0f))
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    Debug.Log(this.gameObject.name);
                    Destroy(this.gameObject);
                }
            }
            else
            {
                timer = disappearTime; // Reset the timer.
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsOnPlatform = true;
            playerController = other.GetComponent<PlayerController>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsOnPlatform = false;
            timer = disappearTime; // Reset the timer.
            playerController = null; // Nullify the reference.
        }
    }
}
