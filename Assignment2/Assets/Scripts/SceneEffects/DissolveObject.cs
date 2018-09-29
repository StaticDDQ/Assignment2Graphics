using UnityEngine;

public class DissolveObject : MonoBehaviour {

    private Material mat;
    [SerializeField] private float max, currVal;
    [SerializeField] private float speed = 1;

    private float val;
    private bool isOn = false;
    private bool dissolving = true;

    private void Awake()
    {
        mat = GetComponent<Renderer>().material;
        val = currVal;
    }

    // Update is called once per frame
    void Update () {
        if (isOn)
        {
            if(!dissolving && val < max)
            {
                mat.SetFloat("_DissolveY", val);
                val += Time.deltaTime * speed;
            }
            else if(dissolving && val > max)
            {
                mat.SetFloat("_DissolveY", val);
                val -= Time.deltaTime * speed;
            }
            else
            {
                isOn = false;
                if(!dissolving)
                    GetComponent<Collider>().enabled = false;
            }
        }
	}

    public void DissolveOn()
    {
        if (!isOn)
        {
            isOn = true;
            dissolving = !dissolving;

            float temp = currVal;
            currVal = max;
            max = temp;

            val = currVal;

            if (dissolving)
                GetComponent<Collider>().enabled = true;
        }
    }
}
