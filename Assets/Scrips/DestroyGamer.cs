using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGamer : MonoBehaviour
{
    private void Update()
    {
        if (MainGameController.instance.destroyNow)
        {
            Destroy(gameObject);
            MainGameController.instance.destroyNow=false;
        }
    }
}
