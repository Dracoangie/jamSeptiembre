using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angulo : MonoBehaviour
{

    Vector2 movimiento;
    Vector2 mousePos;
    public Rigidbody2D rb;
    Camera cam;
    private void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        //rb2d.MovePosition(rb2d.position + movimiento);

        Vector2 direccion = mousePos - rb.position;
        float angulo = Mathf.Atan2(direccion.y, direccion.x) * 57f - 90f;
        rb.rotation = angulo;
    }
}
