using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{
    public Image buttonImg = null;
    public GameObject onGameObject = null;

    private void Reset()
    {
        if( buttonImg == null )
        {
            buttonImg = GetComponent<Image>();
        }

        if( onGameObject == null && transform.childCount > 0)
        {
            onGameObject = transform.GetChild(0).gameObject;
        }
       
    }

}
