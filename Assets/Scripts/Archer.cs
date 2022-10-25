using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{
    public Transform arrow;
    public float arrowSpeed;

    public void UseArrow()
    {
        StartCoroutine(ArrowCorrutine());
    }

    IEnumerator ArrowCorrutine()
    {
        float timer = 2;

        arrow.parent = null;
        
        while(timer > 0)
        {
            arrow.transform.position += transform.forward * arrowSpeed * Time.deltaTime;
            timer -= Time.deltaTime;
            yield return null;
        }
    }
}


