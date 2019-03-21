using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P3displaytext : MonoBehaviour
{
    public GameObject texts;
    public SceneTransition transition;

    // Start is called before the first frame update
    void Start()
    {
        texts.SetActive(false);
        SlideBar.dragtimes = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (SlideBar.dragtimes >= 8)
        {
            texts.SetActive(true);
        }
        if (texts.active == true)
        {
            StartJane.p3fin = true;
            transition.nextScene();
        }
    }
}
