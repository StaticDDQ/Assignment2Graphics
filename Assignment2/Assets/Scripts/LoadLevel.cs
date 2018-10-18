using UnityEngine;

public class LoadLevel : MonoBehaviour {

    [SerializeField] private int level;

    private void OnTriggerEnter(Collider other)
    {
        SceneFade.instance.StartLevel(level);
    }
}
