using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HudLife : MonoBehaviour
{
    public GameObject player;

    TextMeshProUGUI hudText;

    private void Awake() {
        hudText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        hudText.text = "Life: " + player.GetComponent<PlayerController>().health.ToString();
    }
}
