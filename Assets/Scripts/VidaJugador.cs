using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaJugador : MonoBehaviour
{
    int Vida = 3;
    public int VidaRef = 3;
    // Start is called before the first frame update
    void Start()
    {
        Vida = VidaRef;
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemigo")
        {
            Vida -= VidaEnemigo.daño;
            if (Vida <= 0) { Destroy(this.gameObject); }
        }
    }
}
