using UnityEngine;

public class SafePoint : MonoBehaviour
{
    public float healthRegenRate = 1.0f; // Amount of health regenerated per second

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.StartRegeneratingHealth(healthRegenRate);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.StopRegeneratingHealth();
            }
        }
    }
}
