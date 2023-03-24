using UnityEngine;

public class FitBoxColliderToScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        //float sizeY = Camera.main.orthographicSize;
        //float aspect = Camera.main.aspect;
        //float sizeX = aspect * sizeY;

        Vector2 size = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        GetComponent<BoxCollider2D>().size = new Vector2(size.x * 2f, size.y * 2f);
        GetComponent<BoxCollider2D>().offset = Vector2.zero;
        //top.position = new Vector2(0, size.y + 0.5f);
        //bottom.position = new Vector2(0, -size.y - 0.5f);
        //left.position = new Vector2(-size.x - 0.5f, 0);
        //right.position = new Vector2(size.x + 0.5f, 0);
    }
}
