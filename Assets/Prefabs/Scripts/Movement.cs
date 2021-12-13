using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    public double dashCharge;
    private float maxCharge = 10f;
    public double chargeSpeed = 0.01;
    public double dashLength = 0.05;
    public bool isDashing;

    // Update is called once per frame
    void Update()
    {
        processInputs();
    }

    void FixedUpdate()
    {
        Move();

    }
    void processInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        float dash = Input.GetAxis("Dash");
        if (isDashing == false)
        {
            moveDirection = new Vector2(moveX, moveY).normalized;
        }
        

        if (dash == 1)
        {
            dashCharge = dashCharge + chargeSpeed;
            if (dashCharge >= maxCharge)
            {
                dashCharge = maxCharge;
            }
        }
        else
        {
            dashCharge = dashCharge - dashLength;
            if (dashCharge <= 0)
            {
                dashCharge = 0;
                isDashing = false;
            }
            if (dashCharge > 0)
            {
                isDashing = true;
            }
        }








    }

    void Move()
    {
        if (isDashing == false)
        {
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        }
        else
        {
            rb.velocity = new Vector2((float)(moveDirection.x * dashCharge * 10), (float)(moveDirection.y * dashCharge *10));
        }
    }

  



}
