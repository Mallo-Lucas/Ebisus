using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Transform blanco;
    public float speed;

    public void Move()
    {
        StartCoroutine(MoveCorrutine());
    }

    IEnumerator MoveCorrutine()
    {
        yield return new WaitForSeconds(0.2f);

        Vector3 dir = (blanco.position - transform.position).normalized;
        transform.rotation = Quaternion.FromToRotation(-dir, Vector3.up);
        while (true)
        {
            transform.position += dir * speed * Time.deltaTime;
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Blanco")
        {
            StopAllCoroutines();
            transform.parent = other.transform;
            other.GetComponent<Rigidbody>().AddForce(-other.transform.forward * Time.deltaTime * 400, ForceMode.Impulse);
        }
    }
}
