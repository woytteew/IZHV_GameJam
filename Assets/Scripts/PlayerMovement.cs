using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] PlayerState player;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //currentstamina = player.stamina;
        //player.movementSpeed = player.walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * player.speed;
    }
    
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
    
}
