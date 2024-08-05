using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class StandardMaterialRandomColor : MonoBehaviour
{
    bool IsSRP()
    {
        return GraphicsSettings.defaultRenderPipeline != null;
    }
 

    // Start is called before the first frame update
    void Start()
    {
        var mr = GetComponent<MeshRenderer>();
        if (IsSRP())
        {
            //srp
            mr?.material.SetColor("_BaseColor", Random.ColorHSV());
        }
        else 
        {
            //standard
            mr.material.color = Random.ColorHSV();
        }
    }
}
