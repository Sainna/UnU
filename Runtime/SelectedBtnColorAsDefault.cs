using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedBtnColorAsDefault : MonoBehaviour
{
    [SerializeField]
    Button _thisBtn = null;


    Color BaseNormal;
    Color BaseSelected;

    void Awake()
    {
        BaseNormal = _thisBtn.colors.normalColor;
        BaseSelected = _thisBtn.colors.selectedColor;
    }


    public void Selected(bool value)
    {
        ColorBlock tmp = _thisBtn.colors;
        if(value)
        {
            tmp.normalColor = BaseSelected;
        }
        else
        {
            tmp.normalColor = BaseNormal;
        }
        _thisBtn.colors = tmp;
    }
}
