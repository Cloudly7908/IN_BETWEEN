using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float UpForce = 2000f;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("UpFocre Appled");
        GameObject block = collision.gameObject;
        Rigidbody rb = block.GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * UpForce);
    }
}
