using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayGameScript : MonoBehaviour
{
    //Text ButtonText;

    // Start is called before the first frame update
    void Start()
    {
       // ButtonText = GetComponent<Text>();
        //ButtonText.text = "Play";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        SceneManager.LoadScene("Level1");
    }
}
