using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtDice : MonoBehaviour
{
    [SerializeField] Transform target;
    void Update() {
        if (target != null) {
            transform.LookAt(target);
        }
    }
}
