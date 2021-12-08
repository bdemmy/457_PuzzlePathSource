using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public GameObject player;
    public float hitRadius = 1.0f;
    public int hitDamage = 1;
    public float hitDelay = 1.0f;
    public float detectionRadius = 7.5f;

    public List<GameObject> Drops;

    public int health = 2;
    public bool alive = true;

    NavMeshAgent agent;
    float lastTime = 0.0f;
    Rigidbody2D body;

    void Awake() {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        body = GetComponent<Rigidbody2D>();
    }

    void Update() {
        // Hit the player if within range
        var distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance <= hitRadius && Time.time > lastTime + hitDelay) {
            // TODO
            // Take damage
            player.GetComponent<PlayerController>().TakeDamage(hitDamage);
            lastTime = Time.time + hitDelay;
        }
        if (alive == false)
        {

            foreach (GameObject drop in Drops)
            {
                Instantiate(drop, this.transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }

    private void FixedUpdate() {
        // Tell the agent to keep following the player if within range
        var distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance <= detectionRadius) {
            agent.isStopped = false;
            agent.SetDestination(player.transform.position);
        } else {
            agent.isStopped = true;
        }


        if (agent.velocity.x < 0) {
            GetComponent<Animator>().SetBool("FacingLeft", true);
        }
        else if (agent.velocity.x > 0) {
            GetComponent<Animator>().SetBool("FacingLeft", false);
        }

        GetComponent<Animator>().SetFloat("XVelocity", agent.velocity.x);
        GetComponent<Animator>().SetFloat("YVelocity", agent.velocity.y);
    }


    public void TakeDamage(int damage)
    {
        // Apply the damage
        health -= damage;
        if (health < 0)
        {
            health = 0;
        }

        // Are we dead?
        if (health == 0)
        {
            alive = false;
        }
    }
}
