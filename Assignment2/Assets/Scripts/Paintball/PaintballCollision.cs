using UnityEngine;

public class PaintballCollision : MonoBehaviour
{

    public GameObject paintScatterPrefab;
    private ParticleSystem currentPS;

    // When paintball has made contact with another collider
    void OnCollisionEnter(Collision collision)
    {
        GameObject collided = collision.gameObject;

        // Generates a paint splatter particle system on the collision point
        ContactPoint collisionContact = collision.contacts[0];
        var paintsplatter = (GameObject)Instantiate(paintScatterPrefab,
            collisionContact.point,
            Quaternion.identity);

        // Grabs color from paintball
        Color c = GetComponent<Renderer>().material.color;
        paintsplatter.GetComponent<Renderer>().material.SetColor("_Color", c);

        // Create 8 smaller paintballs as particle effect
        ParticleSystem paintSplatterPS = paintsplatter.GetComponent<ParticleSystem>();
        paintSplatterPS.Emit(8);

        // Apply color effect
        if (collided.tag == "PickUp" || collided.tag == "Colourable")
        {
            collided.GetComponent<ColourDecider>().SetEffect(c);
        }

        Destroy(gameObject);
    }
}
