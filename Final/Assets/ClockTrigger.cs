using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockTrigger : MonoBehaviour
{

    public bool hourIsSet;
    public bool minutesIsSet;
    public SceneTransition transition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        minutesIsSet = true;
        if (hourIsSet && minutesIsSet)
        {
            transition.nextScene();
        }
    }
}
