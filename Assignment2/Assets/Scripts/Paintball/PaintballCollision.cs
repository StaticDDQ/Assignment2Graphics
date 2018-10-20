using UnityEngine;

public class PaintballCollision : MonoBehaviour
{

    public GameObject paintScatterPrefab;
    public GameObject onePaintSplatterPrefab;
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

            // Create splatter texture
            Vector3 paintSplatterPos = collision.contacts[0].point;
            var rotation = Quaternion.LookRotation(collision.contacts[0].normal);
            var splatter = Instantiate(onePaintSplatterPrefab, paintSplatterPos, rotation);
            splatter.GetComponent<Renderer>().material.SetColor("_Color", Camera.main.GetComponent<ColorPickerRayCasting>().colorPreview);
        }

        Destroy(gameObject);
    }
}
