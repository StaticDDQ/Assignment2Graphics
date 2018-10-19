using UnityEngine;

public class DissolveObject : Event {
    
    private Material mat;
    [SerializeField] private float max, currVal;
    [SerializeField] private float speed = 1;
    [SerializeField] private bool dissolving = true;

    private float audioSpeed = 1;
    private float val;
    private bool isOn = false;

    private void Awake()
    {
        mat = GetComponent<Renderer>().material;
        val = currVal;
    }

    // Update is called once per frame, set the values for the object to dissolve. 
    // Completely dissolved object will have it's collider turned off
    private void Update () {
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
                if (!dissolving)
                {
                    GetComponent<Collider>().enabled = false;
                    GetComponent<MeshRenderer>().enabled = false;
                } 
            }
        }
	}

    // Call a dissolving effect on the object
    public override bool TriggerEvent()
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
            {
                GetComponent<Collider>().enabled = true;
                GetComponent<MeshRenderer>().enabled = true;
            }

            GetComponent<AudioSource>().pitch = audioSpeed;
            if(audioSpeed < 0)
            {
                GetComponent<AudioSource>().time = GetComponent<AudioSource>().clip.length - 0.01f;
            }
            else
            {
                GetComponent<AudioSource>().time = 0f;
            }

            audioSpeed = -audioSpeed;
            GetComponent<AudioSource>().Play();
            return true;
        }
        return false;
    }

    public bool GetIsOn()
    {
        return this.isOn;
    }
}
