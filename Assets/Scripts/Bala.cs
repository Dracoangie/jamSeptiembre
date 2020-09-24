using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float tiempoDestroy =3f;
    public static int daño;
    public int dañoRef = 1;

    void Start()
    {
        daño = dañoRef;
    }
    void Update()
    {
        tiempoDestroy -= Time.deltaTime;
        if (tiempoDestroy < 0)
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="Enemigo" )
        Destroy(this.gameObject);
    }
}
