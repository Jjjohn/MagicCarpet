using UnityEngine;
using System.Collections;

public class Bottle : MonoBehaviour {

    Vector3 initPos;
    Quaternion initRot;

    void Awake()
    {
        initPos = transform.position;
        initRot = transform.rotation;
    }

    void OnCollisionEnter(Collision col)
    {
        //TODO: only register with ball collision

        StartCoroutine(BottleHit());
    }

    IEnumerator BottleHit()
    {
        yield return new WaitForSeconds(5);
        Reset();
    }

	void OnTriggerEnter(Collider other)
    {
        Reset();
    }

    public void Reset()
    {
        transform.position = initPos;
        transform.rotation = initRot;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

}
