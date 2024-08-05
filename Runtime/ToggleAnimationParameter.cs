using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleAnimationParameter : MonoBehaviour
{
    [SerializeField]
    Animator _Animator = null;



    public void ToggleBool(string name)
    {
        bool value = _Animator.GetBool(name);
        Debug.Log($"{name} - {value} to {!value}");
        _Animator.SetBool(name, !value);
    }

    public void SetBool(string name, bool value)
    {
        _Animator.SetBool(name, value);
    }
}
