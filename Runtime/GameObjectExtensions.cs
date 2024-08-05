using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Sainna.Utils
{
    public static class GameObjectExtensions
    {
        public static GameObject ToggleActive(this GameObject go)
        {
            go.SetActive(!go.activeSelf);
            return go;
        }
    }
}