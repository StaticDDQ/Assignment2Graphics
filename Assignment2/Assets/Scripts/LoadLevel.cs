using UnityEngine;

public class LoadLevel : MonoBehaviour {

    [SerializeField] private readonly int level;

    private void OnTriggerEnter(Collider other)
    {
        SceneFade.instance.StartLevel(level);
    }
}
