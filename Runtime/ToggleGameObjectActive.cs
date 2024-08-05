using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ToggleGameObjectActive : MonoBehaviour
{
    public void ToggleActive()
    {
        if (SceneManager.GetActiveScene().name == "Intro")
        {
            gameObject.SetActive(false);
            return;
        }
        gameObject.SetActive(!gameObject.activeSelf);
    }


    public void ToggleActive(InputAction.CallbackContext ctx)
    {
        ToggleActive();
    }
}
