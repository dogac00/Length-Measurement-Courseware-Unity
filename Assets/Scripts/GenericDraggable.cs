using UnityEngine;

public class GenericDraggable : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;

        if (!this.gameObject.HasComponent<Rigidbody2D>())
        {
            var rb = this.gameObject.AddComponent<Rigidbody2D>();

            rb.gravityScale = 0;
        }
        if (!this.gameObject.HasComponent<BoxCollider2D>())
        {
            this.gameObject.AddComponent<BoxCollider2D>();
        }
    }

    void OnMouseDrag()
    {
        var mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        this.transform.position = new Vector3(mousePos.x, mousePos.y);
    }
}
