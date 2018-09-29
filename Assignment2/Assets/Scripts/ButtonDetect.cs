using UnityEngine;

public class ButtonDetect : MonoBehaviour {

    [SerializeField] private Renderer indicator;
    private bool isPressed = false;

    private void Awake()
    {
        indicator.material.SetColor("_EmissionColor", new Color(1, 1, 1));
    }

    public void ButtonPressed()
    {
        if (!GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsTag("1"))
        {
            GetComponent<Animator>().Play("ButtonPressed");
            isPressed = !isPressed;
            if (isPressed)
                indicator.material.SetColor("_EmissionColor", new Color(0, 0, 0));
            else
                indicator.material.SetColor("_EmissionColor", new Color(1, 1, 1));
            
            //Do Something
        }
    }
}
