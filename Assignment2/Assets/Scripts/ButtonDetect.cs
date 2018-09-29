using UnityEngine;
using System.Collections;

public class ButtonDetect : TriggerDetection{

    private void Awake()
    {
        currColor = Color.white;
    }

    public void ButtonPressed()
    {
        if (!GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsTag("1"))
        {
            GetComponent<Animator>().Play("ButtonPressed");
            isTriggered = !isTriggered;

            if (isTriggered)
                currColor = Color.black;
            else
                currColor = Color.white;

            StopAllCoroutines();
            StartCoroutine(TransitionEffect());
            //Do Something
        }
    }
}
