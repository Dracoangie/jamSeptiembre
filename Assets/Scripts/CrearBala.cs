using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearBala : MonoBehaviour
{
    public GameObject Bala;
    public Transform firePoint;
    bool IsHolding;
    public float velocidad = 15f;
    public float frecuenciaBalas = 0.25f;
    float frecuencia = 0.25f;



    void Start()
    {
        
    }

    //Input.GetButtonDown("Fire1")
    void Update()
    {
        frecuencia -= Time.deltaTime;
        if (Input.GetMouseButton(0) && frecuencia<=0)
        {
            GameObject BalaClone = Instantiate(Bala, firePoint.position, firePoint.rotation);
            Rigidbody2D rb2d = BalaClone.GetComponent<Rigidbody2D>();
            rb2d.AddForce(firePoint.up * velocidad, ForceMode2D.Impulse);
            frecuencia = frecuenciaBalas;
        }

    }

}
