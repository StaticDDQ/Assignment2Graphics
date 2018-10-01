using System.Collections;
using UnityEngine;
public class EnlargeEffect : ColourEffect {

    private Vector3 maxSize = new Vector3(10, 10, 10);
    private Vector3 incrementScale = new Vector3(2, 2, 2);
    private Vector3 baseScale;
    private bool isEnlarge = false;
    private Vector3 newScale;

    private void Start()
    {
        baseScale = transform.localScale;
    }

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
            newScale = baseScale;
        }
        newScale = Vector3.Min(maxSize, newScale + incrementScale);
    }

    public override void RevertEffect()
    {
        isEnlarge = false;
        StartCoroutine(Reverting());
    }

    private IEnumerator Reverting()
    {
        float elapsedTime = 0;
        while(elapsedTime < 2)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, baseScale, elapsedTime/2);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        Destroy(this);
    }
}
