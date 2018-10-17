﻿using System.Collections;
using UnityEngine;
public class ShrinkEffect : ColourEffect {

    private Vector3 minSize = new Vector3(0.5f,0.5f,0.5f);
    private float minMass = 2f;
    private Vector3 incrementScale = new Vector3(0.5f, 0.5f, 0.5f);
    private Vector3 baseScale;
    private float baseMass;
    private Vector3 newScale;

    private bool isEnlarge = false;

    private void Update()
    {
        if (isEnlarge)
            transform.localScale = Vector3.Lerp(transform.localScale, newScale, Time.deltaTime);
    }

    public override void ApplyEffect()
    {
        if (!isEnlarge)
        {
            isEnlarge = true;
            baseScale = transform.localScale;
            newScale = baseScale;
            baseMass = GetComponent<Rigidbody>().mass;
        }

        newScale = Vector3.Max(minSize, newScale - incrementScale);
        GetComponent<Rigidbody>().mass = Mathf.Max(minMass, GetComponent<Rigidbody>().mass - 2f);

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

        if (GetComponent<Rigidbody>().mass > 4f)
        {
            gameObject.tag = "Colourable";
        }

        Destroy(this);
    }
}
