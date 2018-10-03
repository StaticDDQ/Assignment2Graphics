using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFade : MonoBehaviour {

	public Texture2D fadeOutText;
	public float fadeSpeed = 0.8f;

	private float alpha = 1.0f;
	private int fadeDir = -1;
    private bool isLoading = false;

	private void OnGUI()
	{
		alpha += fadeDir * fadeSpeed * Time.deltaTime;
		alpha = Mathf.Clamp01 (alpha);

		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeOutText);
	}

	public void BeginFade (int dir){
        if(!isLoading)
            StartCoroutine(LoadScene(dir));
	}

    private IEnumerator LoadScene(int index)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(index);
        isLoading = true;
        fadeDir = 1;
        while (!async.isDone)
        {
            yield return null;
        }
        fadeDir = -1;
        isLoading = false;
    }
}
