using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
    [SerializeField]
    Collider _ThisCollider = null;

    [SerializeField, Tooltip("Collider to ignore")]
    Collider[] _ToIgnore = null;
    void Start()
    {
        foreach(var col in _ToIgnore)
        {
            Physics.IgnoreCollision(_ThisCollider, col, true);
        }
    }
}
