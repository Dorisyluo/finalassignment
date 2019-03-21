using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideBar : MonoBehaviour
{
    private bool isDragging;
    private Vector3 mousePos;
    private Vector3 offset;
    public static int dragtimes = 0;
    // Start is called before the first frame update
    void Start()
    {
        isDragging = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse down");
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log("Target Position: " + hit.collider.gameObject.transform.position);

                isDragging = true;
                mousePos = Input.mousePosition;
                offset = transform.position -
                            Camera.main.ScreenToWorldPoint(
                                new Vector3(Input.mousePosition.x,
                                Input.mousePosition.y, 10.0f));
            }
            dragtimes++;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
        else if (!isDragging)
        {
            transform.position = Vector3.zero;
        }
    }
    private void OnMouseDrag()
    {
        Debug.Log("Dragging");
        Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);

        Vector3 newWorldPosition = Camera.main.ScreenToWorldPoint(newPosition) + offset;
        Debug.Log("new x = " + newWorldPosition.x);
        if (newWorldPosition.x > 1) newWorldPosition = new Vector3(1f, 0, 0);
        else if (newWorldPosition.x < 0) newWorldPosition = Vector3.zero;
        else newWorldPosition = new Vector3(newWorldPosition.x, 0, 0);
        transform.position = newWorldPosition;
    }
}
