using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingerScript : MonoBehaviour
{
    public SceneTransition transition;
    public int time = 0;
    public GameObject phonetime0;
    public GameObject phonetime1;
    public GameObject phonetime2;
    public GameObject phonetime3;
    public GameObject phonetime4;
    public GameObject phonetime5;

    // Start is called before the first frame update
    void Start()
    {
        phonetime0.SetActive(true);
        phonetime1.SetActive(false);
        phonetime2.SetActive(false);
        phonetime3.SetActive(false);
        phonetime4.SetActive(false);
        phonetime5.SetActive(false);

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
                Animator anim = GetComponent<Animator>();
                anim.SetBool("snoozeIsHit", true);
                Debug.Log("done");
            }
            time++;
        }
        Updatetime(time);
        if (time >= 5)
        {
            transition.nextScene();
        }
    }

    private void Updatetime(int time)
    {
        if (time == 0)
        {
            phonetime0.SetActive(true);
        }
        else if (time == 1)
        {
            phonetime0.SetActive(false);
            phonetime1.SetActive(true);
        }
        else if (time == 2)
        {
            phonetime1.SetActive(false);
            phonetime2.SetActive(true);
        }
        else if (time == 3)
        {
            phonetime2.SetActive(false);
            phonetime3.SetActive(true);
        }
        else if (time == 4)
        {
            phonetime3.SetActive(false);
            phonetime4.SetActive(true);
        }
        else if (time == 5)
        {
            phonetime4.SetActive(false);
            phonetime5.SetActive(true);
        }
    }
}
