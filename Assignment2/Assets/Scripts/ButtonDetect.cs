using UnityEngine;

public class ButtonDetect : TriggerDetection{

    [SerializeField] private Event target;
    
    private void Awake()
    {
        currColor = Color.white;
    }

    // Play animation when it trigger an event successfully
    public void ButtonPressed()
    {
        if (target.TriggerEvent() && !GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsTag("1"))
        {
            GetComponent<Animator>().Play("ButtonPressed");
            isTriggered = !isTriggered;

            if (isTriggered)
                currColor = Color.black;
            else
                currColor = Color.white;

            StopAllCoroutines();
            StartCoroutine(TransitionEffect());
        }
    }
}
