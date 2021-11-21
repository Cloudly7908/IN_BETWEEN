using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mines : MonoBehaviour
{
    public float UpForce = 2000f;
    public ParticleSystem expoleshin;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("boom Exploed");
        GameObject block = collision.gameObject;
        Rigidbody rb = block.GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * UpForce);
        expoleshin.Play();

    }
}
