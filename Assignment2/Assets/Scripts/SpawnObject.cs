using UnityEngine;
using UnityEngine.UI;

public class SpawnObject : MonoBehaviour {

    [SerializeField] private GameObject colourObject;
    [SerializeField] private int counter = 3;
    [SerializeField] private Text displayText;

    private void Start()
    {
        displayText.text = counter.ToString();
    }

    // Update is called once per frame
    public void Spawn()
    {
        if (counter != 0)
        {
            Instantiate(colourObject, transform.position, Quaternion.identity);
            displayText.text = (--counter).ToString();
        }
    }
}
