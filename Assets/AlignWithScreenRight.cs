using UnityEngine;

public class AlignWithScreen : MonoBehaviour
{
    public BoxCollider2D boxCollider;
    private float screenWidth;
    public float Align;

    void Start()
    {
        // Lấy BoxCollider2D của đối tượng
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        float screenWidth = Camera.main.ViewportToWorldPoint(new Vector3(Align, 0f, 0f)).x;
        float newPosX = screenWidth - boxCollider.size.x / 2f;
        transform.position = new Vector3(newPosX, transform.position.y, transform.position.z);
    }
}
