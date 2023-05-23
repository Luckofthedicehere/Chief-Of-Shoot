using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCollision : MonoBehaviour
{

    public float damage;
    // Start is called before the first frame update
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Target target = GameObject.FindGameObjectWithTag("Player").GetComponent<Target>();
            target.TakeDamage(damage);
        }
    }
}
