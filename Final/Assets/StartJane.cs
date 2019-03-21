using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartJane : MonoBehaviour
{
    public GameObject Janes;
    public static bool p3fin = false;
    // Start is called before the first frame update
    void Start()
    {
        Janes.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (p3fin == true)
        {
            Janes.SetActive(true);
        }
    }
}
