using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour {
    // Movement information
    public float runSpeed = 2.0f;

    //enemy
    public GameObject enemy;

    public int attackRadius = 5;

    // Life information
    public int maxHealth = 5;
    public int health = 5;
    public bool alive = true;

    // Hud connection
    public GameObject deathHud;

    // Private state info
    Rigidbody2D body;
    float horizontal;
    float vertical;
    PlayerInventory inventory;

    void Start() {
        body = GetComponent<Rigidbody2D>();
        inventory = GetComponent<PlayerInventory>();
    }

    void Update() {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (enemy) {
            var distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance <= attackRadius && Input.GetKeyDown("e") && inventory.HasItem("Sword")) {
                // TODO
                // Take damage
                enemy.GetComponent<EnemyScript>().TakeDamage(2);
            }
        }
    }

    private void FixedUpdate() {
        if (!UISystem.isInputLocked) {
            if (body.velocity.x < 0) {
                GetComponent<Animator>().SetBool("FacingLeft", true);
            } else if (body.velocity.x > 0) {
                GetComponent<Animator>().SetBool("FacingLeft", false);
            }

            GetComponent<Animator>().SetFloat("XVelocity", body.velocity.x);
            GetComponent<Animator>().SetFloat("YVelocity", body.velocity.y);

            body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed).normalized * runSpeed;
        }
        else {
            body.velocity = new Vector2(0f, 0f);
        }
    }

    public void TakeDamage(int damage) {
        // Apply the damage
        health -= damage;
        if (health < 0) {
            health = 0;
        }

        // Are we dead?
        if (health == 0) {
            alive = false;
            deathHud.SetActive(true);
        }
    }
}
