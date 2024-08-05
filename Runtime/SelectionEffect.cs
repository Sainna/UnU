using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionEffect : MonoBehaviour
{

    [SerializeField]
    bool _UseHoverLayer = true;

    [SerializeField]
    int _HoverLayer = 0;


    [SerializeField]
    bool _UseSelectedLayer = true;

    [SerializeField]
    int _SelectedLayer = 0;

    [SerializeField]
    GameObject _GOToApply = null;

    int OriginalLayer;
    void Start()
    {
        OriginalLayer = gameObject.layer;
        
    }

    static void ApplyLayer(GameObject root, int layerId)
    {
        root.layer = layerId;
        foreach(Transform tra in root.transform)
        {
            tra.gameObject.layer = layerId;
        }
    }


    public void Hover(bool isHover)
    {
        if(_UseHoverLayer)
            ApplyLayer(_GOToApply, isHover ? _HoverLayer : OriginalLayer);
    }

    public void Select(bool isSelected)
    {
        if(_UseSelectedLayer)
            ApplyLayer(_GOToApply, isSelected ? _SelectedLayer : OriginalLayer);
    }
}
