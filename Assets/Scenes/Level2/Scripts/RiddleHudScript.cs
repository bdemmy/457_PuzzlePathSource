using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddleHudScript : MonoBehaviour
{
    public List<GameObject> pedestals;
    public GameObject player;
    public GameObject container;

    private void Start() {
        container.SetActive(false);
    }

    private void Update() {
        foreach(GameObject ped in pedestals) {
            if (Vector2.Distance(player.transform.position, ped.transform.position) < ped.GetComponent<PedestalScript>().interactDistance) {
                container.SetActive(true);
                return;
            }
        }

        container.SetActive(false);
    }
}
