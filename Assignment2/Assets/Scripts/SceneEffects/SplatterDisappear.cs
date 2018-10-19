using System.Collections;
using UnityEngine;

public class SplatterDisappear : MonoBehaviour {

	// Use this for initialization
	private void Awake () {
        // immediately after the splatter is spawned
        StartCoroutine(ShowSplatter());
	}
	
    // will show a fade out effect where it will eventually remove the splatter from the scene
    private IEnumerator ShowSplatter()
    {
        yield return new WaitForSeconds(1);
        float elapsedTime = 0f;
        Color noAlpha = new Color(1, 1, 1, 0);
        
        // alpha fade effect
        while(elapsedTime < 1f)
        {
            GetComponent<SpriteRenderer>().color = Color.Lerp(GetComponent<SpriteRenderer>().color, noAlpha, elapsedTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        Destroy(this.gameObject);
    }
}
