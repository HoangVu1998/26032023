using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGameController : MonoBehaviour
{
    public static MainGameController instance;
    public GameObject MainGame;
    public GameObject ModalDefult;
    //hình ảnh của modal và bọt
    protected SpriteRenderer spriteRendererMain;
    public SpriteRenderer spriteRendererBot;
    public List<characterUI> characterUI;
    public bool isDIY;
    public Transform saveMainGame;
    GameObject modaldefult;
    public Transform Content;
    public Transform Save;
    public bool destroyNow;
    //Manager bọt
    public bool isChangeBot;

    private void Awake()
    {
        instance = this;
        // Tìm đối tượng con có tên là Modal
        Transform childTransformMain = ModalDefult.transform.GetChild(0).Find("Modal");
        //thay bọt
        Transform childTransformMain1 = ModalDefult.transform.GetChild(0).GetChild(0).Find("BotOriganal");
        // thay sprite của đối tượng modalDufalt của modal nguyên thủy
        spriteRendererMain = childTransformMain.GetComponent<SpriteRenderer>();
        spriteRendererBot = childTransformMain1.GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        isChangeBot = false;
        isDIY = false;
        destroyNow = false;
    }
    private void Update()
    {
        if (DetectShake.instance.uonghet == true || MainGameController.instance.destroyNow)
        {
            Destroy(modaldefult);
            foreach (Transform a in saveMainGame)
            {
                Destroy(a.gameObject);

            }
            MainGameController.instance.destroyNow = false;
        }
    }
    public void StartMainGame()
    {

        isChangeBot = false;
        MainGame.SetActive(true);
        spriteRendererMain.sprite = characterUI[UIManager.Instance.CharacterType].CharacterModal[UIManager.Instance.IndexerCharacterType];

        spriteRendererBot.sprite = characterUI[UIManager.Instance.CharacterType].Characterbot[UIManager.Instance.IndexerCharacterType];

        // tạo ra các button bấm chọn topping beer - nằm dưới content
        foreach (var topping in characterUI[UIManager.Instance.CharacterType].ImageButtonTopping)
        {
            if (topping == null)
            {
                continue;
            }

            GameObject toppingSpawn = Instantiate(topping, Content);
            toppingSpawn.transform.SetParent(Content);
        }
        modaldefult = Instantiate(ModalDefult);
    }
    public void BackToStartGame()
    {
        // gọi từ modaldefult, phá hủy ngay lập tức
        MainGameController.instance.destroyNow = true;
        foreach (Transform child in Content.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        MainGame.SetActive(false);
        UIManager.Instance.OnUiOffmainGame();
        for (int i = 0; i < Save.childCount; i++)
        {
            Destroy(Save.GetChild(i).gameObject);
        }
    }
    public void ResetGameModalMain()
    {
        LevelController.isShake = true;
        DetectShake.instance.uonghet = false;
        destroyNow = true;
    }
}
