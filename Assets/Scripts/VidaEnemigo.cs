using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    int Vida = 3;
    public int VidaRef = 3;
    public static int daño;
    public int dañoRef = 1;

    void Start()
    {
        Vida = VidaRef;
        daño = dañoRef;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bala")
        {
            Vida -= Bala.daño;
            if (Vida <= 0) { Destroy(this.gameObject); }
        }
        if (collision.tag == "Player") { Destroy(this.gameObject); }


    }
}
