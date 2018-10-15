using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneFade: MonoBehaviour {

    public static SceneFade instance;

	[SerializeField] private readonly Texture2D fadeOutText;
	[SerializeField] private readonly float fadeSpeed = 0.8f;

	private float alpha = 1.0f;
	private int fadeDir = -1;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance == null)
            instance = this;
    }

    public void StartLevel(int level)
    {
        StartCoroutine(LoadLevel(level));
    }

    private void OnGUI()
	{
		alpha += fadeDir * fadeSpeed * Time.deltaTime;
		alpha = Mathf.Clamp01 (alpha);

		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeOutText);
	}

	private float BeginFade (int direction){
		fadeDir = direction;
		return(fadeSpeed);
	}

    private IEnumerator LoadLevel(int index)
    {
        BeginFade(-1);
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);
        while (!operation.isDone)
        {
            yield return null;
        }
        BeginFade(1);
    }
}
