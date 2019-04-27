using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDice : MonoBehaviour
{
    [SerializeField] float rotSpeed = 50f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Utilities.CurrentMode == Utilities.GameModes.ROLLING) {
            ManageRolling();
        }
        else {
            ManageSelecting();
        }
    }

    private void ManageRolling() {
        throw new NotImplementedException();
    }

    private void ManageSelecting() {
        float h = -Input.GetAxis(Utilities.Horizontal);
        float v = -Input.GetAxis(Utilities.Vertical);
        Vector3 rotation = new Vector3(v, h);

        transform.Rotate(rotation * Time.deltaTime * rotSpeed);
    }
}
