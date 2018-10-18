using System.Collections;
using UnityEngine;
public class EnlargeEffect : ColourEffect {

    private readonly Vector3 maxSize = new Vector3(6, 6, 6);
    private readonly Vector3 incrementScale = new Vector3(0.5f, 0.5f, 0.5f);
    private readonly float maxMass = 24f;

    private Vector3 baseScale;
    private Vector3 newScale;
    private float baseMass;

    private bool isEnlarge = false;

    public override void ApplyEffect()
    {
        if (!isEnlarge)
        {
            isEnlarge = true;
            baseScale = transform.localScale;
            newScale = baseScale;
            baseMass = GetComponent<Rigidbody>().mass;
        }
        
        newScale = Vector3.Min(maxSize, newScale + incrementScale);
        GetComponent<Rigidbody>().mass = Mathf.Min(maxMass, GetComponent<Rigidbody>().mass + 2f);

        if (GetComponent<Rigidbody>().mass > 4f)
        {
            gameObject.tag = "Colourable";
        }
    }

    public override void RevertEffect()
    {
        isEnlarge = false;
        StartCoroutine(Reverting());
    }

    private IEnumerator Reverting()
    {
        float elapsedTime = 0;
        while(elapsedTime < 1f)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, baseScale, elapsedTime * 0.75f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = baseScale;
        GetComponent<Rigidbody>().mass = baseMass;

        if (GetComponent<Rigidbody>().mass <= 4f)
        {
            gameObject.tag = "PickUp";
        }

        Destroy(this);
    }

    private void Update()
    {
        if (isEnlarge)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, newScale, Time.deltaTime * 0.9f);
        }
    }
}
