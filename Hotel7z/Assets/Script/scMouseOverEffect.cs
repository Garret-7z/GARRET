using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scMouseOverEffect : MonoBehaviour
{
    public GameObject EffectImage;

    void OnMouseOver()
    {
        
    }

    void OnMouseExit()
    {
        EffectImage.SetActive(false);
    }
}
