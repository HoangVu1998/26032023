using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickContent : MonoBehaviour
{
    List<Button> ListButton = new List<Button>();

    private void Start()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Button button = gameObject.transform.GetChild(i).GetComponent<Button>();
            if (button != null)
            {
                ListButton.Add(button);
            }
        }
        foreach(Button button in ListButton)
        {
            button.onClick.AddListener(() => activeVibration());
        }
    }
    void activeVibration()
    {
        VibrationManager.instance.Vibrate(80);    
    }
}

