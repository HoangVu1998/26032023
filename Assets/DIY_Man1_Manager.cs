using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DIY_Man1_Manager : MonoBehaviour
{
    public static DIY_Man1_Manager instance;

    public GameObject objectToClone;
    public Transform SaveclonedObject;

    public int PositionInList;
    public int numberButtonDrink;
    public string NameDrink;
    public int IndexerCharacterType;

    public int countTopping;
    private GameObject clonedObject;
    Button Buttonbutton;
}
