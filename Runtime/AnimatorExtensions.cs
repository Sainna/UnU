using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Sainna.Utils
{
    public static class AnimatorExtensions
    {
        public static Animator ToggleBool(this Animator animator, string name)
        {
            bool value = animator.GetBool(name);
            //Debug.Log($"{name} - {value} to {!value}");
            animator.SetBool(name, !value);
            return animator;
        }
    }
}