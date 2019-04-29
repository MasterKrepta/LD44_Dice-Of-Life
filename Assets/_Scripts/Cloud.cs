using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    private float cloudSpeed = 5f;

    private void Update() {
        transform.position += Vector3.forward * cloudSpeed * Time.deltaTime;
        Destroy(this.gameObject, 60f);
    }
}
