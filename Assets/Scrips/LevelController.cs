using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public Transform gameOrigannalPosition;
    public static bool isShake;
    public GameObject[] modalType;
    private int numberColor;
    private void Update()
    {
        if (isShake == true)
        {
            var a = Instantiate(modalType[numberColor], gameOrigannalPosition.position, Quaternion.identity);
            isShake = false;
            if (DetectShake.instance.uonghet == true)
            {
                Destroy(a);
            }
            Debug.Log("HOang00");
        }
    }
    public void chooseModalType(int color)
    {
        var b= Instantiate(modalType[color], gameOrigannalPosition.position, Quaternion.identity);
        numberColor = color;
        if (DetectShake.instance.uonghet == true)
        {
            Destroy(b);
            Debug.Log(DetectShake.instance .uonghet);
        }
        Debug.Log("HOang01");

    }
}
