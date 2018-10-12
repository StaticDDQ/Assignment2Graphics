using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintballCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // When paintball has made contact with another collider
    void OnCollisionEnter (Collision collision)
    {
        Debug.Log("Collision detected");
        GameObject collided = collision.gameObject;
        Debug.Log(collided.ToString());
        if (collided.tag == "PickUp" || collided.tag == "Colourable")
        {
            Debug.Log("Object colourable");
            Color c = GetComponent<Renderer>().material.color;
            collided.GetComponent<ColourDecider>().SetEffect(c);
            Destroy(this.gameObject);
        }
    }
}
