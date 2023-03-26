using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DIY2_ButtonCLone : MonoBehaviour
{
    Button ButonClonel;
    private void Start()
    {
        ButonClonel = GetComponent<Button>();
        ButonClonel.onClick.AddListener(() => PrintCountButton());
    }
    public void PrintCountButton()
    {
       
        DIYController.instance.Man1[UIManager.Instance.CharacterType].SetActive(false);
        var position = new Vector2(UnityEngine.Random.Range(FuritsManager.instance.FutirsPointThrow[2].position.x, FuritsManager.instance.FutirsPointThrow[3].position.x), FuritsManager.instance.FutirsPointThrow[2].position.y+2);
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < PlayerPrefs.GetInt(gameObject.name + i); j++)
            {
                Instantiate(FuritsManager.instance.characterUIList[UIManager.Instance.CharacterType].FrutisList[Return(2 * i, 2 * i + 1)], position, Quaternion.identity).transform.SetParent(DIYController.instance.Save);
            }
        }
        DIYController.instance.buttonname = gameObject.name;
        DIYController.instance.isBG = true;
        DIYController.instance.creatModalManin(gameObject.name);
    }
    public void destroy()
    {
        PlayerPrefs.DeleteKey(gameObject.name + "image");
        PlayerPrefs.DeleteKey(gameObject.name + "position");
        PlayerPrefs.DeleteKey(gameObject.name + "IndexerCharacterType");
        PlayerPrefs.DeleteKey(gameObject.name + "BG");


        for (int i = 0; i < 20; i++)
        {
            PlayerPrefs.SetInt(gameObject.name + i, 0);
        }
        Destroy(gameObject);
    }
    int Return(int NUMBERA, int NUMBERB)
    {
        var a = UnityEngine.Random.Range(0, 2);
        if (a == 0)
        {
            return NUMBERA;
        }
        else
        {
            return NUMBERB;
        }
    }
}