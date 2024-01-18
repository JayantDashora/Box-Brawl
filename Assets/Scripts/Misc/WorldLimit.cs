using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldLimit : MonoBehaviour
{
    // Destroy anything that touches it

    private void OnCollisionEnter(Collision other) {
        Destroy(other.gameObject);
    }
}
