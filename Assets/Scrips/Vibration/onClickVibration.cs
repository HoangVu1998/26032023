using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class onClickVibration : MonoBehaviour
{
    Button button;
    private void Start()
    {
        button= GetComponent<Button>();
       
        button.onClick.AddListener(() => onclick());
    }
    void onclick()
    {
        VibrationManager.instance.Vibrate(80);
        TestMusic.Instance.Play("TapSound");
    }
}
