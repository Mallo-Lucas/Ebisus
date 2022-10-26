using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shiba : MonoBehaviour
{
    private Rigidbody _rb;
    public float speed;
    private bool _executed;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();       
    }

    public void Move()
    {
        if (_executed)
            return;
        _executed = true;
        StartCoroutine(MoveCorrutine());
    }

    IEnumerator MoveCorrutine()
    {
        while (true)
        {
            _rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
            yield return null;
        }
    }
}
