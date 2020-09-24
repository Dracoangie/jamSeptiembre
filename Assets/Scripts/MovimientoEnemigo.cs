using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
    GameObject Jugador;
    Vector3 posicion1;
    Vector3 posicion2;
    Vector3 posicion3;
    public float Speed = 3f;
    float pausa ;
    float Spawn1X; float Spawn1y; float Spawn2X; float Spawn2y; float Spawn3X; float Spawn3y; float Spawn4X; float Spawn4y;
    string identificador;
    bool primerMovimiento;
    void Start()
    {
        Spawn1X = Random.Range(-6f, -8f);
        Spawn1y = Random.Range(4f, -1f);
        Spawn2X = Random.Range(-6f, 0f);
        Spawn2y = Random.Range(4f, 2f);
        Spawn3X = Random.Range(6f, 0f);
        Spawn3y = Random.Range(4f, 2f);
        Spawn4X = Random.Range(6f, 8f);
        Spawn4y = Random.Range(4f, -1f);
        Jugador = GameObject.FindGameObjectWithTag("Player");
        posicion2 = Jugador.transform.position;
    }
        public void setidentificador(string spawn)
    {
        identificador = spawn;  
    }
    void Update()
    {
        
        PrimerMovimiento();
        SeguirJugador();
    }

    void PrimerMovimiento()
    {
        if(primerMovimiento == false)
        {
            if (identificador == "Spawn1")
            {
                float step = Speed * Time.deltaTime;
                posicion1.x = Spawn1X;
                posicion1.y = Spawn1y;
                transform.position = Vector3.MoveTowards(transform.position, posicion1, step);
                if (transform.position == posicion1) primerMovimiento = true;
            }
            if (identificador == "Spawn2")
            {
                float step = Speed * Time.deltaTime;
                posicion1.x = Spawn2X;
                posicion1.y = Spawn2y;
                transform.position = Vector3.MoveTowards(transform.position, posicion1, step);
                if (transform.position == posicion1) primerMovimiento = true;
            }
            if (identificador == "Spawn3")
            {
                float step = Speed * Time.deltaTime;
                posicion1.x = Spawn3X;
                posicion1.y = Spawn3y;
                transform.position = Vector3.MoveTowards(transform.position, posicion1, step);
                if (transform.position == posicion1) primerMovimiento = true;
            }
            if (identificador == "Spawn4")
            {
                float step = Speed * Time.deltaTime;
                posicion1.x = Spawn4X;
                posicion1.y = Spawn4y;
                transform.position = Vector3.MoveTowards(transform.position, posicion1, step);
                if (transform.position == posicion1) primerMovimiento = true;
            }
            pausa = 1.5f;
            posicion2 = Jugador.transform.position;
            posicion2.x += Random.Range(-0.5f, 0.5f);
            posicion2.y += Random.Range(-0.2f, -1.5f);
        }

    }

    void SeguirJugador()
    {
        
        pausa -= Time.deltaTime;
        if (primerMovimiento==true ) 
        {
            if (pausa <= 0) 
            {
                float step = Speed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, posicion2, step);
                if (transform.position == posicion2) { pausa = 1f; posicion2 = Jugador.transform.position; }
            }
            if(pausa>0)
            {
                float step = 0.2f * Time.deltaTime;
                posicion3.x = posicion2.x + Random.Range(-0.5f, 0.5f); 
                posicion3.y = posicion2.y + Random.Range(-0.4f, -1.5f); 
                transform.position = Vector2.MoveTowards(transform.position, posicion3, step);
            }
        }
        
        
    }
    
}