using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverMovement : MonoBehaviour
{
    [SerializeField, Range(0.0f, 1.0f)]
    float _MovementRange = 0.0f;

    [SerializeField, Range(0.0f, 2.0f)]
    float _Speed = 1.0f;
    AnimationCurve curve = null;
    
    void Start()
    {
        curve = AnimationCurve.EaseInOut(0, -_MovementRange, 1, _MovementRange);
    }

    void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, 
                                    curve.Evaluate(Mathf.PingPong(Time.time * _Speed, 1)), 
                                    transform.localPosition.z);
    }
}
