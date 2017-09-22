using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SWing : MonoBehaviour {
    public float rotate = 3f;
    public float radius = 5.0F;
    public float power = 10.0F;
    // Update is called once per frame
    void Update () {
        transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime * rotate);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                    rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
            }
        }
    }
}
