using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{
    public Arrow arrow;

    public void UseArrow()
    {
        arrow.transform.parent = null;
        arrow.Move();
    }
}


