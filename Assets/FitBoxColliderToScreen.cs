using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public class FitBoxColliderToScreen : MonoBehaviour
{
    BoxCollider2D box;
    private void Awake()
    {
        box = GetComponent<BoxCollider2D>();
    }
    void Start()
    {
        Vector2 size = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        box.size = new Vector2((size.x+0.7f) * 2f, size.y * 2f);
        box.offset = Vector2.zero;
    }
}
