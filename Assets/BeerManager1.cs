using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class BeerManager1 : MonoBehaviour
{
    public bool isMan3;
    public bool isMan5;
    public bool isTutorial;
    public GameObject buttonBackMan1;
    public static BeerManager1 instance;
    //  public Transform listFutitsMan3;
    public GameObject man1;
    public GameObject man11;
    public GameObject man12;
    public GameObject man3;
    public GameObject man4;
    public GameObject man5;
    public GameObject man6;
    //image Man6
    public Image ImageMan6DIY;
    //list Màn Step 8 màn sau drink
    public List<GameObject> ListDrinkAfterManDinkMan4;
    //nut Touch
    public GameObject Touch;
    // nút button reset
    public Transform Panel_Man1;
    //list tranform scroll beer
    // public Transform Save;
    public GameObject ModalDIY;
    //vị trí ấn nút modal..vị trí trong list luôn ấy.
    // ẢNH
    public SpriteRenderer spriteRendererDIY;
    public SpriteRenderer spriteRendererBotDIY;

    // đối tượng để clone
    public GameObject cocToClone;
    // số lượng topping Beer
    public int countTopingBeer;
    // loại bia
    public int IndexerCharacterType;
    private GameObject clonedObject;
    // số lần ấn button để quản lý bao nhiêu quả được rơi
    // Modal Main
    public GameObject ModalDefult;

    //Shake
    public bool isMan7;
    float accelerometerUpdateInterval = 1.0f / 60.0f;
    float lowPassKernelWidthInSeconds = 1.0f;
    float shakeDetectionThreshold = 2.0f;
    float lowPassFilterFactor;
    Vector3 lowPassValue;
    public GameObject menuIsShakeDIY;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        isMan7 = false;
        isTutorial = true;
        //Shake
        lowPassFilterFactor = accelerometerUpdateInterval / lowPassKernelWidthInSeconds;
        shakeDetectionThreshold *= shakeDetectionThreshold;
        lowPassValue = Input.acceleration;
    }
    private void Update()
    {
        nextMan4();
        nextMan5();
        nextMan7();
    }
    public void nextMan1()
    {
        isMan7 = false;
        DetectShake.instance.uonghet = false;
        TestMusic.Instance.stop("WaterUp");
        isMan5 = false;
        DIYController.instance.isMan4 = false;
        man1.SetActive(true); man4.SetActive(false); man5.SetActive(false); man3.SetActive(false);
        man11.SetActive(true); man12.SetActive(false);
        isMan3 = false;
        DetectShake.instance.meunuIsShake.SetActive(false);
        buttonBackMan1.SetActive(true);
        menuIsShakeDIY.SetActive(false);

    }
    public void nextMan3()
    {

        string buttonName = DIYController.instance.characterDIY[UIManager.Instance.CharacterType].CharacterUI[DIYController.instance.buttonseLect].name;
        Transform oldObject = BeerManager1.instance.Panel_Man1.Find(buttonName);
        if (oldObject != null)
        {
            PlayerPrefs.SetInt(oldObject.name + "BG", 5);
            for (int i = 0; i < 20; i++)
            {
                PlayerPrefs.SetInt(buttonName + i, 0);
            }
        }
        Touch.SetActive(true);
        DIYController.instance.isStep = true;
        isTutorial = true;
        spriteRendererDIY = ModalDIY.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>();
        spriteRendererBotDIY = ModalDIY.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<SpriteRenderer>();
        spriteRendererDIY.sprite = DIYController.instance.characterDIY[UIManager.Instance.CharacterType].CharacterModal[DIYController.instance.buttonseLect];
        spriteRendererBotDIY.sprite = DIYController.instance.characterDIY[UIManager.Instance.CharacterType].Characterbot[DIYController.instance.buttonseLect];
        var a = Instantiate(ModalDIY);
        a.transform.SetParent(DIYController.instance.Save);
        man1.SetActive(false);
        man3.SetActive(true);
    }
    public void nextMan4()
    {
        if (DIYController.instance.isMan4)
        {
            man4.SetActive(true);
            Touch.SetActive(false);
        }
    }
    public void Man4BackToBack1()
    {
        TestMusic.Instance.stop("WaterUp");
        DetectShake.instance.uonghet = false;
        buttonBackMan1.SetActive(true);
        man11.SetActive(true);
        man12.SetActive(false);
        man4.SetActive(false);
        man1.SetActive(true);
        man3.SetActive(false);
        isMan5 = false;
        DIYController.instance.isMan4 = false;
        DetectShake.instance.meunuIsShake.SetActive(false);
    }
    void nextMan5()
    {
        if (DIYController.instance.countPressButtonFurits > 14)
        {
            menuIsShakeDIY.SetActive(true);
            DIYController.instance.countPressButtonFurits = 0;
            isMan5 = true;
            man5.SetActive(true);
            DIYController.instance.DeleteSave();
            man4.SetActive(false);
            isMan7 = true;
        }
    }
    public void nextMan6()
    {
        man3.SetActive(false);
        man6.SetActive(false);
        isMan5 = false;
        man5.SetActive(false);
        man4.SetActive(true);
        // tạo ra gamePlay mới
        spriteRendererDIY = ModalDefult.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>();
        spriteRendererBotDIY = ModalDefult.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<SpriteRenderer>();
        spriteRendererBotDIY.sprite = DIYController.instance.characterDIY[UIManager.Instance.CharacterType].Characterbot[DIYController.instance.buttonseLect];
        spriteRendererDIY.sprite = DIYController.instance.characterDIY[UIManager.Instance.CharacterType].CharacterModal[DIYController.instance.buttonseLect];
        var a = Instantiate(ModalDefult);
        a.transform.SetParent(DIYController.instance.Save);
        if (isTutorial)
        {
            DIYController.instance.isStep = false;
            isTutorial = false;
            creatFuritsClone();
            creatModalClone();
        }
        foreach (var item in ListDrinkAfterManDinkMan4)
        {
            item.SetActive(true);
        }
    }
    public void nextMan7()
    {
        if (isMan7)
        {
            Vector3 acceleration = Input.acceleration;
            lowPassValue = Vector3.Lerp(lowPassValue, acceleration, lowPassFilterFactor);
            Vector3 deltaAcceleration = acceleration - lowPassValue;
            if (deltaAcceleration.sqrMagnitude >= shakeDetectionThreshold)
            {
                isMan7 = false;
                menuIsShakeDIY.SetActive(false);
                man6.SetActive(true);
                ImageMan6DIY.sprite = DIYController.instance.characterDIY[UIManager.Instance.CharacterType].CharacterUI[DIYController.instance.buttonseLect];
            }
        }
    }
    public void creatModalClone()
    {
        // Kiểm tra xem có đối tượng giống với đối tượng clone không
        string buttonName = DIYController.instance.characterDIY[UIManager.Instance.CharacterType].CharacterUI[DIYController.instance.buttonseLect].name;
        Transform oldObject = Panel_Man1.Find(buttonName);
        if (oldObject != null)
        {
            Destroy(oldObject.gameObject);
        }
        clonedObject = Instantiate(cocToClone, Panel_Man1);
        clonedObject.name = buttonName;
        // Set image and position of cloned object
        Image clonedObjectImage = clonedObject.GetComponent<Image>();
        clonedObjectImage.sprite = DIYController.instance.characterDIY[IndexerCharacterType].CharacterUI[DIYController.instance.buttonseLect];
        string clonedObjectImageJson = JsonUtility.ToJson(clonedObjectImage);
        Vector3 position = clonedObject.transform.position;
        PlayerPrefs.SetString(buttonName + "image", clonedObjectImageJson);
        PlayerPrefs.SetString(buttonName + "position", JsonUtility.ToJson(position));
        PlayerPrefs.SetInt(buttonName + "IndexerCharacterType", IndexerCharacterType);
        PlayerPrefs.Save();

    }
    public void creatFuritsClone()
    {
        var position = new Vector2(UnityEngine.Random.Range(FuritsManager.instance.FutirsPointThrow[2].position.x, FuritsManager.instance.FutirsPointThrow[3].position.x), UnityEngine.Random.Range(FuritsManager.instance.FutirsPointThrow[2].position.y + 2, FuritsManager.instance.FutirsPointThrow[3].position.y));
        // Tạo ra một đối tượng mới từ mảng FruitsPrefabsBeer ở vị trí position
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < PlayerPrefs.GetInt(DIYController.instance.characterDIY[UIManager.Instance.CharacterType].CharacterUI[DIYController.instance.buttonseLect].name + i); j++)
            {
                var a = Instantiate(FuritsManager.instance.characterUIList[UIManager.Instance.CharacterType].FrutisList[Return(2 * i, 2 * i + 1)], position, Quaternion.identity);
                a.transform.SetParent(DIYController.instance.Save);
            }
        }
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
    public void OffListDrinkAfterManDinkMan4()
    {
        DIYController.instance.isBG = false;
        foreach (var item in ListDrinkAfterManDinkMan4)
            item.SetActive(false);
    }
    public void testShake()
    {
        isMan7 = false;
        menuIsShakeDIY.SetActive(false);
        man6.SetActive(true);
        ImageMan6DIY.sprite = DIYController.instance.characterDIY[UIManager.Instance.CharacterType].CharacterUI[DIYController.instance.buttonseLect];
    }
}

