using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "NewMan4SO", menuName = "Man4SO")]
public class Man4SO : ScriptableObject
{
    public List<GameObject> Man4Beer = new List<GameObject>() ;
    public List<GameObject> Man4Coctail = new List<GameObject>();
    public List<GameObject> Man4Alcohol = new List<GameObject>();
}