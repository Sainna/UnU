using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsColliderTriggered : MonoBehaviour
{
    public bool IsTriggered {get; private set;} = false;

    [SerializeField]
    string _TagLimit = null;


    void OnTriggerEnter(Collider other)
    {
        if(string.IsNullOrEmpty(_TagLimit) || _TagLimit == other.tag)
            IsTriggered = true;
    }


    void OnTriggerExit(Collider other)
    {
        if(string.IsNullOrEmpty(_TagLimit) || _TagLimit == other.tag)
            IsTriggered = false;
    }
}
