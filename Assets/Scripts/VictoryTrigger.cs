using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class VictoryTrigger : MonoBehaviour
{
    public GameObject Victory;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ShowVictoryTextAndReload());
        }
    }

    IEnumerator ShowVictoryTextAndReload()
    {
        Victory.SetActive(true);
        yield return new WaitForSeconds(3);  // Show for 3 seconds
        SceneManager.LoadScene(0);  // Reload the scene after 3 seconds
    }
}
