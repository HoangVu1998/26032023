using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ModalCollision : MonoBehaviour
{
    public GameObject ModalDefult;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (ModalMove.isFiling == true)
        {
            if (collision.gameObject.CompareTag("1"))
            {
                TestMusic.Instance.Play("DrinkSip");
                
                DetectShake.instance.uonghet = true;
                MainGameController.instance.destroyNow= true;
                Destroy(ModalDefult);
               
            }
        }
        if (MainGameController.instance.destroyNow)
        {
            Destroy(ModalDefult);   
            DIYController.instance.DeleteSave();    
        }
    }
}
