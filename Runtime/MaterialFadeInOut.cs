using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MaterialFadeInOut : MonoBehaviour
{
    [SerializeField]
    Renderer _Renderer = null;

    private int ColorShaderId = -1;
    private int OpacityShaderId = -1;

    [SerializeField]
    bool _StartInvisible = true;

    [SerializeField, Tooltip("Custom property to directly change the material opacity")]
    string _OpacityProperty = string.Empty;

    bool IsLWRP()
    {
        return GraphicsSettings.renderPipelineAsset != null;
    }
 

    void Awake()
    {
        if(!string.IsNullOrEmpty(_OpacityProperty))
        {
            OpacityShaderId = Shader.PropertyToID(_OpacityProperty);
        }  
        else
        {
            // no property to directly use the material opacity, default to use the color
            if(IsLWRP())
            {
                _Renderer.material.doubleSidedGI = true;
                _Renderer.material.SetShaderPassEnabled("ShadowCaster", true);
                ColorShaderId = Shader.PropertyToID("_BaseColor");
            }
            else
            {
                ColorShaderId = Shader.PropertyToID("_Color");
            }
        }
    }

    void Start()
    {
        if(_StartInvisible)
        {
            SetMaterialAlpha(0);
            gameObject.SetActive(false);
        }
    }


    public void Appear(bool visible, float second = 0.5f)
    {
        
        if(visible)
        {
            gameObject.SetActive(true);
            StopAllCoroutines();
            if(Mathf.Approximately(0, second))
            {
                SetMaterialAlpha(1.0f);
            }
            else
            {
                StartCoroutine(FadeIn(second));
            }
        }
        else
        {
            if(Mathf.Approximately(0, second))
            {
                SetMaterialAlpha(0.0f);
                gameObject.SetActive(false);
            }
            else
            {
                StartCoroutine(FadeOut(second));
            }
        }
    }



    private float GetMaterialAlpha()
    {
        return OpacityShaderId == -1 ? _Renderer.material.GetColor(ColorShaderId).a : _Renderer.material.GetFloat(OpacityShaderId);
    }


    private void SetMaterialAlpha(float ft)
    {
        if(OpacityShaderId == -1)
        {
            Color c = _Renderer.material.GetColor(ColorShaderId);
            c.a = ft;
            _Renderer.material.SetColor(ColorShaderId, c);
        }
        else
        {
            _Renderer.material.SetFloat(OpacityShaderId, ft);
        }
        
    }


    private IEnumerator FadeOut(float second)
    {
        float startTime = Time.time;
        float startAlpha = GetMaterialAlpha();
        float alpha = 1.0f;

        while(alpha > 0)
        {
            alpha = Mathf.Lerp(startAlpha, 0, (Time.time - startTime) / second);
            SetMaterialAlpha(alpha);
            yield return null;
        }

        // for (float ft = GetMaterialAlpha(); ft >= 0; ft -= 0.1f) 
        // {
        //     SetMaterialAlpha(ft);
        //     yield return null;
        // }
        gameObject.SetActive(false);
    }

    private IEnumerator FadeIn(float second)
    {
        float startTime = Time.time;
        float startAlpha = GetMaterialAlpha();
        float alpha = 0.0f;

        while(alpha < 1)
        {
            alpha = Mathf.Lerp(startAlpha, 1, (Time.time - startTime) / second);
            SetMaterialAlpha(alpha);
            yield return null;
        }
        // for (float ft = GetMaterialAlpha(); ft <= 1; ft += 0.1f) 
        // {
        //     SetMaterialAlpha(ft);
        //     yield return null;
        // }
    }
}
