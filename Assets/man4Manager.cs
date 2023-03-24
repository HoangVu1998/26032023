using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class man4Manager : MonoBehaviour
{
    public List<GameObject> furitsScroll;
    public void offFuritsScroll()
    {
        foreach(var item in furitsScroll)
        {
            item.SetActive(false);
        }
    }
    public void onFuritsScroll()
    {
        foreach (var item in furitsScroll)
        {
            item.SetActive(true);
        }
    }
}
