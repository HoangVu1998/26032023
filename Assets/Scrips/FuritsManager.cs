using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuritsManager : MonoBehaviour
{
    public static FuritsManager instance;   
    public List<characterUI> characterUIList;
    public Transform[] FutirsPointThrow;
    public Transform Save;
    private void Awake()
    {
        instance= this; 
    }
}
