using UnityEngine;

public class PaintShooting : MonoBehaviour {

    public GameObject paintballPrefab;
    public float paintballSpeed = 10.0f;
    public float fireRate = 0.5f;
    private float fireNow;
    private Transform paintballSpawn;

	// Use this for initialization
	void Start () {
        paintballSpawn = Camera.main.transform;
    }
	
	// Update is called once per frame
	void Update () {


        //Debug.Log(paintballSpawn.forward);
        //paintballSpawn.localPosition += new Vector3(0.0f, -0.5f, 0.5f);

		if (Input.GetMouseButtonDown(0) && Time.time > fireNow)
        {
            Color eyedrop = this.GetComponent<ColorPickerRayCasting>().colorPreview;
            var paintball = (GameObject)Instantiate(paintballPrefab,
                paintballSpawn.position + paintballSpawn.forward,
                paintballSpawn.rotation);
            paintball.GetComponent<Rigidbody>().velocity = paintballSpawn.forward * paintballSpeed;
            paintball.GetComponent<Renderer>().material.SetColor("_Color", eyedrop);
            fireNow = Time.time + fireRate;
        }
	}
}
