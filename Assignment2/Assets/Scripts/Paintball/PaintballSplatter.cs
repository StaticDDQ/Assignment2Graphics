using System.Collections.Generic;
using UnityEngine;

public class PaintballSplatter : MonoBehaviour
{

    private ParticleSystem currentPS;
    public GameObject onePaintSplatterPrefab;
    private List<ParticleCollisionEvent> paintSplatterCollisions;

    private float elapsedTime = 0;
    [SerializeField] private float lifetime = 3f;

    // Use this for initialization
    void Start()
    {
        currentPS = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime > lifetime)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag != "Player")
        {
            paintSplatterCollisions = new List<ParticleCollisionEvent>();

            int eventCount = currentPS.GetCollisionEvents(other, paintSplatterCollisions);

            if (!(other.tag == "PickUp" || other.tag == "Colourable"))
            {
                for (int i = 0; i < eventCount; i++)
                {
                    Vector3 paintSplatterPos = paintSplatterCollisions[i].intersection;
                    var rotation = Quaternion.LookRotation(paintSplatterCollisions[i].normal);

                    var splatter = Instantiate(onePaintSplatterPrefab, paintSplatterPos, rotation);
                    splatter.GetComponent<Renderer>().material.SetColor("_Color", Camera.main.GetComponent<ColorPickerRayCasting>().colorPreview);
                }
            }
        }
        Destroy(this.gameObject,1.0f);
    }
}
