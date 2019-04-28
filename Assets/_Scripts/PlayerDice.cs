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
     
        switch (Utilities.CurrentMode) {
            case Utilities.GameModes.SELECTING:
                ManageSelecting();
                break;
            case Utilities.GameModes.ROLLING:
                ManageRolling();
                break;
            default:
                break;
        }
 
    }

    private void ManageRolling() {
        Debug.Log("MODE: Rolling");
    }

    private void ManageSelecting() {
        float h = -Input.GetAxis(Utilities.Horizontal);
        float v = -Input.GetAxis(Utilities.Vertical);
        Vector3 rotation = new Vector3(v, h);

        transform.Rotate(rotation * Time.deltaTime * rotSpeed);
    }
}
