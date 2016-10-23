using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
