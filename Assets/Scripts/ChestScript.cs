using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChestScript : MonoBehaviour {
    // Local SpriteRenderer
    SpriteRenderer spriteRenderer;

    // variables to detect player interaction
    public GameObject player;
    public float interactionRadius;

    // Sprite rendering stuff
    public Sprite OpenChest;
    public Sprite LockedChest;

    // variable to track chest UI
    public GameObject chestUI;
    public GameObject TextLock1, TextLock2, TextLock3;

    // Key stuff
    public GameObject keyPrefab;
    public GameObject keySpawnpos;

    // all text outputs
    Text lock1Text;
    Text lock2Text;
    Text lock3Text;

    // See if chest has already been unlocked
    bool unlocked = false;

    private void Awake() {
        chestUI.SetActive(false);
        spriteRenderer = GetComponent<SpriteRenderer>();

        lock1Text = TextLock1.GetComponent<Text>();
        lock2Text = TextLock2.GetComponent<Text>();
        lock3Text = TextLock3.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update() {
        if (!UISystem.isInputLocked && !unlocked) {
            float dist = Vector3.Distance(player.transform.position, transform.position); //distance to painting from player

            if (dist < interactionRadius) { // if player is within interaction circle
                if (Input.GetKeyDown("e")) {  //if e is pressed
                    chestUI.SetActive(true); //pull up chest lock UI
                    UISystem.LockInput(gameObject);   //stops all movement
                }
            }
        }
        else if (UISystem.isInputLocked && UISystem.focusedGameObject == gameObject && !unlocked) {
            //if code is correct
            if (((lock1Text.text == "H") && (lock2Text.text == "B") && (lock3Text.text == "R"))) {
                UISystem.UnlockInput(); //unlock movement
                chestUI.SetActive(false); //close chest lock UI
                unlocked = true;

                Instantiate(keyPrefab, keySpawnpos.transform.position, Quaternion.identity);
            }

            //back out manually
            else if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("e")) 
            {
                UISystem.UnlockInput(); //open movement
                chestUI.SetActive(false); //close chest lock UI
            }
        }

        if (unlocked == true) {
            spriteRenderer.sprite = OpenChest; //open chest if unlocked
        }
    }
}



