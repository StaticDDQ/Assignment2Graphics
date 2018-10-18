using System.Collections;
using System.Collections.Generic;
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

    // Update is called once per frame
    void Update()
    {

    }

    private void OnParticleCollision(GameObject other)
    {
        int collCount = currentPS.GetSafeCollisionEventSize();

        paintSplatterCollisions = new ParticleCollisionEvent[collCount];

        int eventCount = currentPS.GetCollisionEvents(other, paintSplatterCollisions);

        onePaintSplatterPrefab.GetComponent<Renderer>().sharedMaterial.SetColor("_Color", Camera.main.GetComponent<ColorPickerRayCasting>().colorPreview);

        for (int i = 0; i < eventCount; i++)
        {
            Vector3 paintSplatterPos = paintSplatterCollisions[i].intersection;
            var rotation = Quaternion.LookRotation(paintSplatterCollisions[i].normal);
            Collider collider = (Collider)paintSplatterCollisions[i].colliderComponent;
            if (other.tag == "PickUp" || other.tag == "Colourable") { }
            else
            {
                Instantiate(onePaintSplatterPrefab, paintSplatterPos, rotation);
            }
        }

    }
}
