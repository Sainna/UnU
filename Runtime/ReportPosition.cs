using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportPosition : MonoBehaviour
{
    new Transform transform;
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Debug.LogWarning($"{name} - {transform.position}");
    }
}
