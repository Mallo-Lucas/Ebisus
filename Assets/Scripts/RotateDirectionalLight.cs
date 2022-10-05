using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDirectionalLight : MonoBehaviour
{
    public float speed;
 
    void Update()
    {
        transform.Rotate(speed * Time.deltaTime, 0, 0);
    }
}
