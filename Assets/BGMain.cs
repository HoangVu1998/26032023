using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMain : MonoBehaviour
{
    Image image;
    public List<Sprite> sprites;
    private void Awake()
    {
        image = GetComponent<Image>();
    }
    private void OnEnable()
    {
        if (!DIYController.instance.isBG)
        {
            image.sprite = sprites[5];
        }
        if (DIYController.instance.isBG)
        {
            int index = PlayerPrefs.HasKey(DIYController.instance.buttonname + "BG") ? PlayerPrefs.GetInt(DIYController.instance.buttonname + "BG") : 5;
            image.sprite = sprites[index];
        }
    }
}

