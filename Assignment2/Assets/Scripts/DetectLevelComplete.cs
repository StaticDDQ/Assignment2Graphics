using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectLevelComplete : PlacementDetect {

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        Debug.Log("Player on elevator");
        GetComponent<Animator>().Play("ElevatorRise");

        SceneFade.instance.StartLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    protected override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);

        Debug.Log("Player off elevator");
    }
}
