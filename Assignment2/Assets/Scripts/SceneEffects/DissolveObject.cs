using UnityEngine;

public class DissolveObject : MonoBehaviour {

    private Material mat;
    private float max, speed = 1;
    private float currVal;

    private bool isOn = false;
    private bool dissolving = false;

    private void Awake()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update () {
        if (isOn)
        {
            if(dissolving && currVal < max)
            {
                mat.SetFloat("_DissolveY", currVal);
                currVal += Time.deltaTime * speed;
            }
            else if(!dissolving && currVal > max)
            {
                mat.SetFloat("_DissolveY", currVal);
                currVal -= Time.deltaTime * speed;
            }
            else
            {
                isOn = false;
            }
        }
	}

    public void DissolveOn()
    {
        isOn = true;
        dissolving = true;
        currVal = -5;
        max = 3;
    }

    public void DissolveOff()
    {
        isOn = true;
        dissolving = false;
        currVal = 3;
        max = -5;
    }
}
