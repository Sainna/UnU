using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// FOR DEBUG USE ONLY
public class EventOnKeyPress : MonoBehaviour
{
    [SerializeField]
    KeyCode[] _Keys = null;

    [SerializeField]
    UnityEvent[] _Events = null;


    #if UNITY_EDITOR
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < _Keys.Length; i++)
        {
            if(Input.GetKeyDown(_Keys[i]))
            {
                _Events[i].Invoke();
            }
        }
    }
    #endif
}
