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
        Destroy(this.gameObject);
    }
}
