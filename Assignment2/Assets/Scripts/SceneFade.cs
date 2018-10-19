using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneFade: Event {

    public static SceneFade instance;

	[SerializeField] private Texture2D fadeOutText;
    [SerializeField] private float fadeSpeed = 0.8f;

	private float alpha = 1f;
	private int fadeDir = -1;

    // There is only one instance of this and will appear in every scene
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance == null)
        {
            instance = this;
        }
    }

    // when the player wants to load a level
    public void StartLevel(int level)
    {
        StartCoroutine(LoadLevel(level));
    }

    // it will fade in first and wait till the level is ready to be loaded, afterwards it will fade out
    private IEnumerator LoadLevel(int index)
    {
        fadeDir = 1;
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);
        while (!operation.isDone)
        {
            yield return null;
        }
        fadeDir = -1;
        yield return new WaitForSeconds(2);
    }

    // assign alpha to either render or unrender the black texture
    private void OnGUI()
	{
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        // Restrict values from 0 to 1 only
        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutText);
	}

    // used if the player wants to reset the level
    public override bool TriggerEvent()
    {
        StartLevel(SceneManager.GetActiveScene().buildIndex);
        return true;
    }
}
