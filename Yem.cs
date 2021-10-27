using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yem : MonoBehaviour
{
    public BoxCollider2D OrtaAlan;

    private void Start()
    {
        RastgeleUret();
    }

    private void RastgeleUret()
    {
        Bounds bounds= this.OrtaAlan.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            RastgeleUret();
        }
    }
}
