using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;

    public float runSpeed = 2.0f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update() {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        if (!UISystem.isInputLocked) {
            body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        } else {
            body.velocity = new Vector2(0f, 0f);
        }
    }
}
