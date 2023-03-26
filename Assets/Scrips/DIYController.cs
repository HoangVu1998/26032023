using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DIYController : MonoBehaviour
{
    public static DIYController instance;
    public List<GameObject> Man1;
    public List<GameObject> Man4;
    public GameObject DIY;
    // quản lý việc có chạy DIY nữa không--
    public bool isStep;
    public SpriteRenderer spriteRendererDIY;
    public SpriteRenderer spriteRendererBotDIY;
    public int countPressButtonFurits;

    public SpriteRenderer spriteRenderer;
    public Transform Save;

    public List<characterUI> characterDIY;
    public GameObject UI;
    public bool DIYMove;
    public bool DIYRotate;
    public bool isMan4;
    public bool isMan5;
    public bool isMan7;
    public GameObject CocDefult;

    public string buttonname;
    public GameObject ModalDefult;
    public bool isDIY;
    public int buttonseLect;

    //lưu BG cho game.
    public int numberOfImage;
    public string buttonNameDrink;
    public bool isBG;

    public List<GameObject> ListDIY;
    
    //list man 4 bg and icon
    public List<GameObject> man4;
    public List<GameObject> man4Total;
    private void Start()
    {
        isStep = false;
        isMan4 = false;  
        countPressButtonFurits= 0;
        buttonseLect = 0;
        isBG= false;    
    }
    private void Awake()
    {
        instance = this;
        DIYMove = false;
        DIYRotate = false;
        isMan4 = false;
        isMan5 = false;
        isMan7 = false;
        spriteRenderer = ModalDefult.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>();
        spriteRendererBotDIY = ModalDefult.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (MainGameController.instance.destroyNow && ModalMove.isFiling)
        {
            foreach (Transform a in Save)
            {
                Destroy(a.gameObject);
            }
            MainGameController.instance.destroyNow = false;
        }
    }
    public void startDIY()
    {
        isDIY = true;
        DIY.SetActive(true);
        foreach (var DIY in ListDIY)
        {
            DIY.SetActive(false);
        }
        foreach(var item in man4Total)
        {
            item.SetActive(false);
        }
        ListDIY[UIManager.Instance.numberTypeDIY].SetActive(true);
    }
    public void creatModalManin(string nameOBj)
    {
        
        BeerManager1.instance.man4.SetActive(true);
        foreach (var item in man4)
        {
            item.SetActive(true);
        }
        spriteRenderer.sprite = DIYController.instance.characterDIY[UIManager.Instance.CharacterType].CharacterModal[PlayerPrefs.GetInt(nameOBj + "CharacterType")];
        spriteRendererBotDIY.sprite = DIYController.instance.characterDIY[UIManager.Instance.CharacterType].Characterbot[PlayerPrefs.GetInt(nameOBj + "CharacterType")];
        Man4[UIManager.Instance.CharacterType].SetActive(true);
        var a = Instantiate(ModalDefult);
        a.transform.SetParent(Save);
    }
    public void backToUigame()
    {
        DIY.SetActive(false);
        UI.SetActive(true);
        isDIY = false;
    }
    public void nextMan8()
    {
        if (isDIY)
        {
            Debug.Log("isman8");
            spriteRendererDIY = ModalDefult.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>();
            spriteRendererDIY.sprite = characterDIY[UIManager.Instance.CharacterType].CharacterModal[PlayerPrefs.GetInt(buttonname + "CharacterType")];
            var a = Instantiate(ModalDefult);
            a.transform.SetParent(DIYController.instance.Save);
            isStep = false;
        }
        else
        {
            Debug.Log("gameNotDIY");
        }
    }
    public void isman4()
    {
        BeerManager1.instance.man4.SetActive(false);
    }
    public void DeleteSave()
    {
        isBG= false;
        for (int i = 0; i < Save.transform.childCount; i++)
        {
            Destroy(Save.transform.GetChild(i).gameObject);
        }
        countPressButtonFurits = 0;
    }
    public void ResetButtonSelect()
    {
        buttonseLect = 0;
    }
}

