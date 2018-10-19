using System.Collections;
using UnityEngine;
public class ShrinkEffect : ColourEffect {

    // there is a minimum size so object will not shrink to oblivion
    private readonly Vector3 minSize = new Vector3(0.5f,0.5f,0.5f);
    private readonly Vector3 incrementScale = new Vector3(0.5f, 0.5f, 0.5f);
    private readonly float minMass = 2f;
    
    // the original scale, and mass of the object before applying the effect
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

        // increasing scale will increase the mass as well
        newScale = Vector3.Max(minSize, newScale - incrementScale);
        GetComponent<Rigidbody>().mass = Mathf.Max(minMass, GetComponent<Rigidbody>().mass - 2f);

        // if the object is small enough, it can be picked up
        if (GetComponent<Rigidbody>().mass <= 4f)
        {
            gameObject.tag = "PickUp";
        }
    }

    public override void RevertEffect()
    {
        isEnlarge = false;
        StartCoroutine(Reverting());
    }

    // will need to revert the scale and mass back to original before removing this script
    private IEnumerator Reverting()
    {
        float elapsedTime = 0;
        while (elapsedTime < 1f)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, baseScale, elapsedTime * 0.75f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = baseScale;
        GetComponent<Rigidbody>().mass = baseMass;

        // if the object was initially big, make it unabled to be picked up
        if (GetComponent<Rigidbody>().mass > 4f)
        {
            gameObject.tag = "Colourable";
        }

        Destroy(this);
    }

    // smooth transition effect of the scale getting smaller
    private void Update()
    {
        if (isEnlarge)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, newScale, Time.deltaTime * 0.9f);
        }
    }
}
