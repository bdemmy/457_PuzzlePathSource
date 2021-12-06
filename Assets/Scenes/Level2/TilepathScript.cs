using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilepathScript : MonoBehaviour
{
    public GameObject telepoint;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.GetComponent<PlayerController>()) {
            collision.gameObject.transform.position = telepoint.transform.position;
        }
    }
}
