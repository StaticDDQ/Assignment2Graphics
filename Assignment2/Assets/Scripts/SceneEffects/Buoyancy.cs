using UnityEngine;
using System.Collections;

public class Buoyancy : MonoBehaviour {

    public float speed;
    private bool isCollide = false;
    private Vector3 basePos;
    private Vector3 newPos;

    private void Start()
    {
        basePos = transform.position;
        newPos = basePos + Vector3.down * 0.25f; 
    }

    // Update is called once per frame
    void Update () {
        if(!isCollide)
            transform.position = Vector3.Lerp(transform.position, basePos, Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isCollide)
        {
            isCollide = true;
            StartCoroutine(PushDown());
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    private IEnumerator PushDown()
    { 

        float elapsedTime = 0;
        while (elapsedTime < 0.15f)
        {
            transform.position = Vector3.Lerp(transform.position, newPos, elapsedTime*3);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        isCollide = false;
    }
}
