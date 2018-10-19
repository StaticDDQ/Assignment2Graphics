using UnityEngine;

public class PaintballCollision : MonoBehaviour
{

    public GameObject paintScatterPrefab;
    private ParticleSystem currentPS;

    // When paintball has made contact with another collider
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected");
        GameObject collided = collision.gameObject;
        Debug.Log(collided.ToString());

        if (collided.tag == "PickUp" || collided.tag == "Colourable")
        {
            Debug.Log("Object colourable");

            // Generates a paint splatter particle system on the collision point
            ContactPoint collisionContact = collision.contacts[0];
            var paintsplatter = (GameObject)Instantiate(paintScatterPrefab,
                collisionContact.point,
                Quaternion.identity);

            paintsplatter.GetComponent<Renderer>().material.SetColor("_Color", Camera.main.GetComponent<ColorPickerRayCasting>().colorPreview);

            ParticleSystem paintSplatterPS = paintsplatter.GetComponent<ParticleSystem>();
            paintSplatterPS.Emit(8);

            Color c = GetComponent<Renderer>().material.color;
            collided.GetComponent<ColourDecider>().SetEffect(c);
        }

        Destroy(gameObject);
    }
}
