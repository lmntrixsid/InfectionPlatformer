using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public GameObject player;
    public Vector3 startlocation;
    public CameraController camera;
    
    // Start is called before the first frame update
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            camera.player = Instantiate(player, startlocation, Quaternion.identity);
            

        }
        //if (rb.velocity.magnitude != 0
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
