using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIY2_Manager : MonoBehaviour
{
    public bool isMan3;
    public bool isMan5;
    public static DIY2_Manager instance;
    //  public Transform listFutitsMan3;
    public GameObject man1;
    public GameObject man4;
    //list tranform scroll beer
    public Transform Beer;
    public int butonSelect;
    public bool isMan4;


    private void Awake()
    {
        instance = this;
        isMan4 = false;
    }
    public void nextMan4()
    {
        man1.SetActive(false);
        man4.SetActive(true);
    }
    public void nextMan1()
    {
        isMan3 = false; man1.SetActive(true); man4.SetActive(false);
    }
}
