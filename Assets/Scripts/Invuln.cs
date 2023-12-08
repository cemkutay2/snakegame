using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invuln : MonoBehaviour
{
    Renderer rend;
    Color c;
    float normal_color;
    float normal_color_r;

    void Start()
    {
        rend = GetComponent<Renderer>();
        c = rend.material.color;
        normal_color = c.b;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && col.gameObject.layer != this.gameObject.layer)
            StartCoroutine("GetInvulnerable");
        
    }
    IEnumerator GetInvulnerable()
    {
        Physics2D.IgnoreLayerCollision(6, 7, true);
        c.b = 2f;
        rend.material.color = c;
        yield return new WaitForSeconds(2f);
        Physics2D.IgnoreLayerCollision(6, 7, false);
        c.b = normal_color;
        rend.material.color = c;
    }
}
