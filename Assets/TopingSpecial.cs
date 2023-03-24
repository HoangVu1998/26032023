using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopingSpecial : MonoBehaviour
{
    Button button;
    void Start()
    {
       button= GetComponent<Button>();
        button.onClick.AddListener(() => onClickButtonSpecial());
       
    }
    void onClickButtonSpecial()
    {
        MainGameController.instance.isChangeBot = true;
    }

}
