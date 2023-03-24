using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public int CharacterType;
    public int IndexerCharacterType;
    public bool MainGameIsPlay;
    public bool isDIY;


    public int numberTypeDIY;
    public GameObject UI;
    public GameObject Maingame;
    private void Awake()
    {
        Instance = this;
        MainGameIsPlay = false;
    }
    private void Start()
    {
        isDIY= false;
        numberTypeDIY= 0;   
    }
    public void OffUiOnMainGame()
    {
        UI.SetActive(false);
        CharacterUIManager.instance.onClickCharacter();
        MainGameController.instance.StartMainGame();
    }
    public void OnUiOffmainGame()
    {
        UI.SetActive(true);
    }
    public void OnClickDIY()
    {
        UI.SetActive(false);
        DIYController.instance.startDIY();
    }
}
