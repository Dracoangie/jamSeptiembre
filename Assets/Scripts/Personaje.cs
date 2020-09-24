using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    bool salto_plataforma = false;
    bool idle = true;
    bool disparo = false;
    Animator anim;
    GameObject[] Plataformas;

    int id_de_plataforma = 0;

    float gravedad;
    float velociadad_de_salto;

    float TiempoDeSalto;
    float TiempoEnElAire;
    float velocidad_para_el_salto;
    float PosY;

    public float altura_de_salto=1;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        AnimationClip[] animaciones = anim.runtimeAnimatorController.animationClips;
        /*Consigo saber cuanto dura la animacion para que si alguien cambia el tiempo de la animacion desde unity 
        tambien cambie el tiempo en el que esta en el aire*/
        foreach (AnimationClip animacion in animaciones)
        {
            if(animacion.name== "SaltoPlataforma")
            {
                TiempoDeSalto = animacion.length;
            }
        }
        Plataformas = GameObject.FindGameObjectsWithTag("Plataforma");
        PosY = transform.position.y;
        transform.position = new Vector2(Plataformas[id_de_plataforma].transform.position.x, transform.position.y);
        CalcularVelocidadParaElSalto();
    }

    // Update is called once per frame
    void Update()
    {
        salto();
    }
    void salto()
    {
        if (!anim.GetBool("SaltoPlataforma"))
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("SaltoPlataforma", true);
                if (id_de_plataforma == 0)
                {
                    ++id_de_plataforma;
                }
                else
                {
                    --id_de_plataforma;
                }
            }
        }
        else
        {
            TiempoEnElAire += Time.deltaTime;
            if (TiempoEnElAire >= TiempoDeSalto)
            {
                TiempoEnElAire = 0;
                anim.SetBool("SaltoPlataforma", false);
                transform.position = new Vector2(Plataformas[id_de_plataforma].transform.position.x,PosY);
            }
            else
            {
                saltoVisual();
            }
        }
    }
    void CalcularVelocidadParaElSalto()
    {
        float distancia =Mathf.Abs(Plataformas[0].transform.position.x - Plataformas[1].transform.position.x);
        velocidad_para_el_salto = distancia / TiempoDeSalto;
        velociadad_de_salto = altura_de_salto / (TiempoDeSalto/2);
    }
    void saltoVisual()
    {
        float PosX;
        float posY;
        if (id_de_plataforma == 0)
        {
            PosX = Plataformas[1].transform.position.x - velocidad_para_el_salto * TiempoEnElAire;
        }
        else
        {
            PosX = Plataformas[0].transform.position.x + velocidad_para_el_salto * TiempoEnElAire;
        }
        posY = PosY + velociadad_de_salto * (TiempoDeSalto / 2-Mathf.Abs(TiempoDeSalto/2-TiempoEnElAire));
        Debug.Log(posY);
        transform.position = new Vector2(PosX,posY);
    }
}
