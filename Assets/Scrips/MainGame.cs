using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour
{
    public Transform Content;
    public Transform Save;
    GameObject gameOBJ;
    private void Awake()
    {
        MainGameController.instance.Content = Content;
    }
    private void Update()
    {
        if (LevelController.isShake == true)
        {
            MainGameController.instance.isChangeBot = false;
            gameOBJ = Instantiate(MainGameController.instance.ModalDefult);
            Debug.Log("Hoang");
            LevelController.isShake = false;
         
        }
        if (MainGameController.instance.destroyNow)
        {
            Destroy(gameOBJ);
        }
        if (DetectShake.instance.uonghet)
        {
            Destroy(gameOBJ);
        }
    }
    public void backTomenu()
    {
       // musicManager.instance.isPlayingSFX= false;  
        DetectShake.instance.uonghet = false;
        DetectShake.instance.meunuIsShake.SetActive(false); 
    }
}
