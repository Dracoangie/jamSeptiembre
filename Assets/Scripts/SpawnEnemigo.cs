using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemigo : MonoBehaviour
{
    public GameObject MovimientoEnemigo;
    public Transform Spawn;
    public float frecuencia = 4f;
    //private Random rnd = new Random();
    //int aleatorio = rnd.Next();

    // Update is called once per frame
    void Update()
    {
        frecuencia -= Time.deltaTime;
        if (frecuencia <= 0)
        {
            GameObject EnemigoClone = Instantiate(MovimientoEnemigo, Spawn.position, Spawn.rotation);
            EnemigoClone.GetComponent<MovimientoEnemigo>().setidentificador(gameObject.tag);
            frecuencia = 4f;
        }
    }
}
