using UnityEngine;

public class ButtonDetect : TriggerDetection{

    [SerializeField] private Event target;
    [SerializeField] private bool resetButton = false;

    // Play animation when it trigger an event successfully
    public void ButtonPressed()
    {

        // check if an event is called successfully
        if (target.TriggerEvent() || resetButton)
        {
            GetComponent<AudioSource>().Play();

            // another button that uses this doesnt have an animation
            if(GetComponent<Animator>() != null)
            {
                GetComponent<Animator>().Play("ButtonPressed");
            }

            if (resetButton)
            {
                SceneFade.instance.TriggerEvent();
            }

            isTriggered = !isTriggered;

            // indicate if the button is on or off
            if (isTriggered)
            {
                TransitionEffect(Color.black);
            }
            else
            {
                TransitionEffect(Color.white);
            }
        }
    }
}
