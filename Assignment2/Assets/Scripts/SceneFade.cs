using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneFade: MonoBehaviour {

    public static SceneFade instance;

	[SerializeField] private Texture2D fadeOutText;
	private readonly float fadeSpeed = 0.8f;

	private float alpha = 1.0f;
	private int fadeDir = -1;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance == null)
        {
            instance = this;
        }
    }

    public void StartLevel(int level)
    {
        StartCoroutine(LoadLevel(level));
    }

    private IEnumerator LoadLevel(int index)
    {
        fadeDir = -1;
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);
        while (!operation.isDone)
        {
            yield return null;
        }
        fadeDir = 1;
    }

    private void OnGUI()
	{
		alpha += fadeDir * fadeSpeed * Time.deltaTime;
        // Restrict values from 0 to 1 only
		alpha = Mathf.Clamp01 (alpha);

		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeOutText);
	}
}
