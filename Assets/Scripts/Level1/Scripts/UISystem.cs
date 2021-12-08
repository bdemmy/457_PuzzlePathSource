using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISystem : MonoBehaviour
{
    public static bool isInputLocked = false;
    public static GameObject focusedGameObject = null;

    public static bool LockInput(GameObject go) {
        if (isInputLocked) {
            return false;
        }

        isInputLocked = true;
        focusedGameObject = go;

        return true;
    }

    public static void UnlockInput() {
        isInputLocked = false;
        focusedGameObject = null;
    }
}
