using UnityEngine;
using UnityEngine.UI;

public class SpawnObject : Event {

    [SerializeField] private GameObject colourObject;
    [SerializeField] private int counter = 3;
    [SerializeField] private Text displayText;

    private void Start()
    {
        displayText.text = counter.ToString();
    }

    public override bool TriggerEvent()
    {
        if(counter != 0)
        {
            Instantiate(colourObject, transform.position, Quaternion.identity);
            displayText.text = (--counter).ToString();
            return true;
        }
        return false;
    }
}
