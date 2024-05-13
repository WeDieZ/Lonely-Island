using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_Enemies : MonoBehaviour
{
    public float hp_value = 30;
    void Update()
    {
        if (hp_value <= 0)
        {
            Destroy(gameObject);
        }
    }
}
