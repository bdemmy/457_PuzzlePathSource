using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerTorchScript : MonoBehaviour
{

    public List<GameObject> torches;
    public bool puzzleComplete = false;

    public GameObject torchTwo;
    torchScript torchScriptTwo;

    // Start is called before the first frame update
    void Start()
    {
        torchScriptTwo = torchTwo.GetComponent<torchScript>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject torch in torches)
        {
            TorchPuzzleScript2 torchScript = torch.GetComponent<TorchPuzzleScript2>();
            if (!torchScript.isLit)
            {
                
                return;
            }
        }

        if (!torchScriptTwo.isLit)
        {
            torchScriptTwo.Toggle();
        }
    }

    void OnFinish(int i)
    {

        
    }
}
