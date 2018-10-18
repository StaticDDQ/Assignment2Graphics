using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintballCollision : MonoBehaviour
{

    public GameObject paintScatterPrefab;
    private ParticleSystem currentPS;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // When paintball has made contact with another collider
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected");
        GameObject collided = collision.gameObject;
        Debug.Log(collided.ToString());
        if (collided.tag == "PickUp" || collided.tag == "Colourable")
        {
            Debug.Log("Object colourable");

            // Match the paintball color to the splatter
            paintScatterPrefab.GetComponent<Renderer>().sharedMaterial.SetColor("_Color", Camera.main.GetComponent<ColorPickerRayCasting>().colorPreview);

            // Generates a paint splatter particle system on the collision point
            ContactPoint collisionContact = collision.contacts[0];
            var paintsplatter = (GameObject)Instantiate(paintScatterPrefab,
                collisionContact.point,
                Quaternion.identity);

            ParticleSystem paintSplatterPS = paintsplatter.GetComponent<ParticleSystem>();
            paintSplatterPS.Emit(10);
            Destroy(paintSplatterPS, 5f);

            Color c = GetComponent<Renderer>().material.color;
            collided.GetComponent<ColourDecider>().SetEffect(c);
            Destroy(this.gameObject);
        }
        Destroy(gameObject);
    }
}
