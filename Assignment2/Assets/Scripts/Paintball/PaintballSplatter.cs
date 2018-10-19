using UnityEngine;

public class PaintballSplatter : MonoBehaviour
{

    private ParticleSystem currentPS;
    public GameObject onePaintSplatterPrefab;
    private ParticleCollisionEvent[] paintSplatterCollisions;

    // Use this for initialization
    void Start()
    {
        currentPS = GetComponent<ParticleSystem>();
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag != "Player")
        {
            int collCount = currentPS.GetSafeCollisionEventSize();

            paintSplatterCollisions = new ParticleCollisionEvent[collCount];

            int eventCount = currentPS.GetCollisionEvents(other, paintSplatterCollisions);
            print(eventCount);
            if (!(other.tag == "PickUp" || other.tag == "Colourable"))
            {
                for (int i = 0; i < eventCount; i++)
                {
                    Vector3 paintSplatterPos = paintSplatterCollisions[i].intersection;
                    var rotation = Quaternion.LookRotation(paintSplatterCollisions[i].normal);
                    Collider collider = (Collider)paintSplatterCollisions[i].colliderComponent;
                    var splatter = Instantiate(onePaintSplatterPrefab, paintSplatterPos, rotation);
                    splatter.GetComponent<Renderer>().material.SetColor("_Color", Camera.main.GetComponent<ColorPickerRayCasting>().colorPreview);
                }
            }
        }
        Destroy(this.gameObject,1.0f);
    }
}
