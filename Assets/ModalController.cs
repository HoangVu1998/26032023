using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModalController : MonoBehaviour
{
    // quan ly bot
    public GameObject BotSpecial;
    private void Update()
    {
        ActiveBotSpecial();
    }
    private void ActiveBotSpecial()
    {
        if (MainGameController.instance.isChangeBot)
        {
            BotSpecial.SetActive(true);
        }
        else
        {
            BotSpecial.SetActive(false);    
        }
    }
}
