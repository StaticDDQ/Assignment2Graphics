using UnityEngine;

public class ButtonDetect : TriggerDetection{

    [SerializeField] private Event target;

    // Play animation when it trigger an event successfully and button animation is done playing
    public void ButtonPressed()
    {
        if (target.TriggerEvent())
        {
            GetComponent<AudioSource>().Play();
            
            GetComponent<Animator>().Play("ButtonPressed");
            isTriggered = !isTriggered;

            StopAllCoroutines();

            if (isTriggered)
                TransitionEffect(Color.black);
            else
                TransitionEffect(Color.white);
        }
    }
}
