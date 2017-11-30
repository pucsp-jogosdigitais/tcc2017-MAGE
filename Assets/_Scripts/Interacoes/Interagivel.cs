using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interagivel : MonoBehaviour
{
    public float radius = 3f;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public virtual void Interact()
    {
        Debug.Log("Interacting with " + transform.name);
    }
}
