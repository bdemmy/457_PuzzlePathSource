using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class torchScript : MonoBehaviour
{

    // Local SpriteRenderer
    SpriteRenderer spriteRenderer;

    public Sprite offLight;
    public Sprite onLight;
    


    // Private state
    public Light2D lightSource;

    public bool isLit = false;

    private void Awake()
    {
        lightSource = GetComponent<Light2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        

        UpdateLighting();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }


    public void Toggle()
    {

        isLit = !isLit;

        UpdateLighting();
    }

    void UpdateLighting()
    {
        if (isLit)
        {
            lightSource.enabled = true;
            spriteRenderer.sprite = onLight;
        }
        else
        {
            lightSource.enabled = false;
            spriteRenderer.sprite = offLight;
        }
    }
}
