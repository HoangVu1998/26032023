using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Onclick : MonoBehaviour
{
    [SerializeField] Transform listDrink;
    private int nuumber;
    Button button;
    private void Start()
    {
        button = GetComponent<Button>();
        nuumber = 0;
        SetActiveDrink(nuumber);

        button.onClick.AddListener(() => onclick());

    }
    void onclick()
    {
        nuumber++;
        if (nuumber >= listDrink.childCount)
        {
            nuumber = 0;
        }
        SetActiveDrink(nuumber);
    }

    void SetActiveDrink(int index)
    {
        for (int i = 0; i < listDrink.childCount; i++)
        {
            if (i == index)
            {
                listDrink.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                listDrink.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
