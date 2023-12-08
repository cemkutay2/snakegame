using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetColor2 : MonoBehaviour
{
    private Renderer rend;
    public static Color c;

    void Start()
    {
        rend = GetComponent<Renderer>();
        c = rend.material.color;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rend.material.color = c;
    }
}
