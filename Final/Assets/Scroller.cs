using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    private bool isClicked;
    private Vector3 mousePos;
    private Vector3 offset;
    public int target = 7;
    public int startNumber = 6;
    public GameObject numbers1;
    public GameObject numbers2;
    public ClockTrigger clockTrigger;

    // Start is called before the first frame update
    void Start()
    {
        isClicked = false;
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
                
                isClicked = true;
                mousePos = Input.mousePosition;
                offset = numbers1.transform.position -
                            Camera.main.ScreenToWorldPoint(
                                new Vector3(Input.mousePosition.x, 
                                Input.mousePosition.y, 10.0f));
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isClicked = false;
        }
        else
        {
            float yPos = numbers1.transform.position.y;
 
            float distance = yPos - (Mathf.Floor((yPos) / 3)) * 3f-1.5f;
            numbers1.transform.position -= new Vector3(0f, distance * .1f, 0f);
            numbers2.transform.position -= new Vector3(0f, distance * .1f, 0f);

            float currentNumber = (yPos / 3.0f) + startNumber - 0.5f;
            Debug.Log(distance + "and " + currentNumber);
            if (Mathf.Abs(currentNumber - (float)target) < 0.05)
            {
                //trigger something to happen.
                Debug.Log("target hit");
                clockTrigger.hourIsSet = true;
            }
            else
            {
                clockTrigger.hourIsSet = false;
            }
        }

    }
    private void OnMouseDrag()
    {
        Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);

        Vector3 newWorldPosition = Camera.main.ScreenToWorldPoint(newPosition) + offset;
        if (newWorldPosition.y > 36)
        {
            newWorldPosition -= new Vector3(0, 36f);
        }
        else if (newWorldPosition.y < -36)
        {
            newWorldPosition += new Vector3(0, 36f);
        }
            numbers1.transform.position = new Vector3(numbers1.transform.position.x, newWorldPosition.y, newWorldPosition.z);
        if (newWorldPosition.y > 0)
            numbers2.transform.position = new Vector3(numbers2.transform.position.x, newWorldPosition.y - 36, newWorldPosition.z);
        else
            numbers2.transform.position = new Vector3(numbers2.transform.position.x, newWorldPosition.y + 36, newWorldPosition.z);

        //clone.transform.position = transform.position + new Vector3(0, 36);
        /*float deltaY = Input.mousePosition.y - mousePos.y;
        this.transform.position += new Vector3(0f, deltaY, 0f);
        mousePos = Input.mousePosition;*/
        /*Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;*/
    }


}
