﻿using UnityEngine;
using System.Collections;

public class EnemyRotator : MonoBehaviour
{


    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);
    }
}
