using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollDice : MonoBehaviour
{
    Rigidbody rb;
    bool hasLanded;
    bool thrown;
    Vector3 initPos;

    public int DiceValue;
    public Tile[] diceTiles;

    // Start is called before the first frame update
    void Start()
    {
        AssignSides();
        rb = GetComponentInChildren<Rigidbody>();
        initPos = transform.position;
        rb.useGravity = false;
    }

    private void AssignSides() {
        for (int i = 0; i < diceTiles.Length; i++) {
            //todo DO this automatically
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Utilities.CurrentMode == Utilities.GameModes.ROLLING) {

            if (Input.GetKeyDown(KeyCode.Space)) {
                //Utilities.CurrentMode = Utilities.GameModes.ROLLING;
                RollTheDice();
            }

            if (rb.IsSleeping() && !hasLanded && thrown) {
                hasLanded = true;
                rb.useGravity = false;

                //TODO value check the sides to get value
                CheckSides();

            }
            else if (rb.IsSleeping() && hasLanded && DiceValue == 0) {
                RollAgain();
            }
        }
        
    }

    public void RollAgain() {
        Reset();
        thrown = true;
        rb.useGravity = true;
        rb.AddTorque(UnityEngine.Random.Range(0, 500), UnityEngine.Random.Range(0, 500), UnityEngine.Random.Range(0, 500));
    }

    private void RollTheDice() {
        if (!thrown && ! hasLanded) {
            thrown = true;
            rb.useGravity = true;
            rb.AddTorque(UnityEngine.Random.Range(0, 500), UnityEngine.Random.Range(0, 500), UnityEngine.Random.Range(0, 500));
        }
        else if (thrown && hasLanded) {
            Reset();
        }
    }

    public  void Reset() {
        transform.position = initPos;
        thrown = false;
        hasLanded = false;
        rb.useGravity = false;
    }

    void CheckSides() {
        DiceValue = 0;
        foreach (Tile tile in diceTiles) {
            if (tile.IsGrounded()) {
                DiceValue = tile.TileValue;
                Debug.Log($"Rolled a {DiceValue} to {tile.Type}");
                Utilities.NextAction();
                PlayerInventory.Instance.CollectResource(tile.Type, DiceValue);
            }
        }
    }
}
