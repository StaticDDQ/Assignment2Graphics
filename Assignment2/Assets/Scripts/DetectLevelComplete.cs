using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectLevelComplete : PlacementDetect {

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        // Animate elevator while fading to black and loading next level
        GetComponent<Animator>().Play("ElevatorRise");
        SceneFade.instance.StartLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
