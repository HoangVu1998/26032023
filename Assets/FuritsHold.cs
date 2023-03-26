using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuritsHold : MonoBehaviour
{
    BuoyancyEffector2D effector;
    BoxCollider2D box;
    private void Awake()
    {
        effector = GetComponent<BuoyancyEffector2D>();
        box = GetComponent<BoxCollider2D>();
    }
    void Start()
    {
        Vector2 size = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        box.size = new Vector2((size.x + 0.7f) * 2f, size.y);
        box.transform.position =new Vector2( gameObject.transform.position.x, gameObject.transform.position.x + 10); 
        box.offset = Vector2.zero;
        effector.surfaceLevel = size.y;
    }
}


   
