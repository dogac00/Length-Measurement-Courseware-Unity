using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderObject : MonoBehaviour
{
    private int _inside;

    public bool IsFull => _inside > 1;

    void OnTriggerEnter2D(Collider2D collider)
    {
        _inside++;

        print($"Inside : { _inside }");
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        _inside--;

        print($"Inside : { _inside }");
    }
}
