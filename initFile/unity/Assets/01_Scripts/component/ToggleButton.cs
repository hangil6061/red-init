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
        buttonImg = GetComponent<Image>();
    }

}
