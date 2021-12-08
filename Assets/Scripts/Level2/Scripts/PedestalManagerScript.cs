using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestalManagerScript : MonoBehaviour
{
    public List<GameObject> pedestal;

    public GameObject torchThree;
    torchScript torchScriptThree;

    // Start is called before the first frame update
    void Start()
    {
        torchScriptThree = torchThree.GetComponent<torchScript>();
    }


    // Update is called once per frame
    void Update()
    {
       foreach(GameObject p in pedestal)
        {
             PedestalScript pedScript = p.GetComponent<PedestalScript>();
            if (!pedScript.correct)
            {
                
                return;
            }

        }
        if (!torchScriptThree.isLit)
        {
            torchScriptThree.Toggle();
        }
    }
}
