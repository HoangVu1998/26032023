using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButonOnOff : MonoBehaviour
{
    public void ToggleButton(GameObject button)
    {
        button.SetActive(!button.activeSelf);
    }
}
