using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Vector2 move; 
    private Rigidbody rb;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       
        
    }

    public void onmove(InputAction.CallbackContext value)
    {
        move = value.ReadValue<Vector2>();
    
    }

    



    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(move.x,0,move.y );
        rb.AddForce(movement*speed);
        
    }

}
