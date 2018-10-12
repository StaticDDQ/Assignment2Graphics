﻿using System.Collections;
using UnityEngine;
public class ShrinkEffect : ColourEffect {

    private Vector3 minSize = new Vector3(0.5f,0.5f,0.5f);
    private Vector3 incrementScale = new Vector3(0.25f, 0.25f, 0.25f);
    private Vector3 baseScale;
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
        }
        newScale = Vector3.Max(minSize, newScale - incrementScale);
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
        Destroy(this);
    }
}
