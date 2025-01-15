using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDcontroller : MonoBehaviour
{
    public static HUDcontroller instance;
    [SerializeField] TMP_Text interactionText;

    private void Awake()
    {
        instance = this;
    }

    public void EnableInteractionText(string text)
    {
        interactionText.text = text /*+ "(F)"*/;
        interactionText.gameObject.SetActive(true);
    }

    public void DisableInteractionText()
    {
        interactionText.gameObject.SetActive(false);
    }
}
