using System.Collections;
using UnityEngine;

public class SplatterDisappear : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        StartCoroutine(ShowSplatter());
	}
	
    private IEnumerator ShowSplatter()
    {
        yield return new WaitForSeconds(1);
        float elapsedTime = 0f;
        Color noAlpha = new Color(1, 1, 1, 0);
        while(elapsedTime < 1f)
        {
            GetComponent<SpriteRenderer>().color = Color.Lerp(GetComponent<SpriteRenderer>().color, noAlpha, elapsedTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        Destroy(this.gameObject);
    }
}
