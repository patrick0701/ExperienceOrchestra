using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowTrigger : MonoBehaviour
{
    private bool bowTouching;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bow"))
        {
            bowTouching = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bow"))
        {
            bowTouching = false;
        }
    }

    public bool BowIsTouching()
    {
        return bowTouching;
    }
}
