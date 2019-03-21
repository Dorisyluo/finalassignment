using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTransition : MonoBehaviour
{
    public Animator transitionAnimation;
    public string [] text = { "text" };
    public float [] duration = { 2.0f };
    public Text textUI;
    public SceneTransition sceneTransition;

    public float initialWaitTime = 2f;

    private int nextTextIndex = -1;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void nextText()
    {
        nextTextIndex++;
        if (nextTextIndex >= text.Length)
        {
            textUI.text = "";
            //sceneTransition.nextScene();
        }
        else
        {
            textUI.text = this.text[nextTextIndex];
            Debug.Log(text[nextTextIndex]);
            transitionAnimation.SetTrigger("textIn");
            StartCoroutine(DisplayText());
        }
    }
    IEnumerator DisplayText()
    {
        
        

        yield return new WaitForSeconds(duration[nextTextIndex]-.6f);

        transitionAnimation.SetTrigger("textOut");
        yield return new WaitForSeconds(.6f);
        nextText();
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(initialWaitTime);
        nextText();
    }
}
