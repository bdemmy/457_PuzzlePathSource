using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TorchManager : MonoBehaviour
{
    public List<GameObject> torches;
    public bool puzzleComplete = false;
    public GameObject barrier;

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject torch in torches) {
            TorchScript torchScript = torch.GetComponent<TorchScript>();
            if (!torchScript.isLit) {
                barrier.GetComponent<Collider2D>().enabled = true;
                barrier.GetComponent<TilemapRenderer>().enabled = true;
                return;
            }
        }

        barrier.GetComponent<Collider2D>().enabled = false;
        barrier.GetComponent<TilemapRenderer>().enabled = false;
    }
}
