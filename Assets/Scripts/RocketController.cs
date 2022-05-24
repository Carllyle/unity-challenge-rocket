using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{  
    [Header("Rigidbody")]
    public Rigidbody proRB;
    public Rigidbody parachuteRB;
    public Rigidbody narizRB;
    [Header("FixedJoint")]
    public FixedJoint proFJ;
    [Header("Info")]
    public float fuelTime;
    public float fuelTime2;
    public float speed;   
    [Header("Game Object")]
    public GameObject fireRocket;
    public GameObject fireRocket2;
    [Header("Buttons")]
    public ButtonsControl buttons;
    private bool parachute = false; //controle de ativação // acontecer apenas 1x
    private bool parachuteDisappear = false; // controle para sumir definitivamente com o paraquedas
    [Header("Event")]
    public NarizEvent narizEvent;
    public PriEstagioEvent priEstagioEvent;
    float scaleParachute = 1.0f; //variavel para controlas escala do paraquedas

    // Update is called once per frame
    void Update()
    {
        ///metodo pra acelerar o foguete
        if (buttons.gameBegin == true && fuelTime > 0)
        {
            proRB.AddForce(proRB.transform.forward * speed * Time.deltaTime); // add força para frente do foguete
            fuelTime -= Time.deltaTime; //contador do "fuel"
            fireRocket.SetActive(true);
            if (fuelTime < 0)
            {
                fuelTime = 0; // setar como 0, evitar numero negativo
                speed = 500; //diminuir velocidade usada para o nariz
            }
        }
        else
        {
            fireRocket.SetActive(false); //desligar animacao do fogo do "primeiro estagio"
        }

        ///separar primeira parte do foguete "primeiro estagio"
        if (buttons.gameBegin == true && fuelTime == 0 && fuelTime2 > 0)
        {
            Destroy(proFJ); //destruir "primeiro estagio", desconectar ele do resto do foguete
            narizRB.AddForce(narizRB.transform.forward * speed * Time.deltaTime); // add força para frente do foguete
            fuelTime2 -= Time.deltaTime; //contador do "fuel"
            fireRocket2.SetActive(true);
            if (fuelTime2 < 0)
            {
                fuelTime2 = 0; // setar como 0, evitar numero negativo
            }
        }
        else
        {
            fireRocket2.SetActive(false); //desligar animacao do fogo do "primeiro estagio"
        }

        ///ativar o paraquedas
        if (fuelTime2 == 0 && narizRB.velocity.y < 0 && parachute == false)
        {
            parachuteRB.gameObject.SetActive(true); //ativar paraquedas
            parachute = true;
        }

        //verificar se primeiro estagio esta dentro da area de vento
        if (priEstagioEvent.inWindZone)
        {
            proRB.AddForce(priEstagioEvent.windZone.GetComponent<WindArea>().direction * priEstagioEvent.windZone.GetComponent<WindArea>().strengh); //aplicar força do vento no "primeiro estagio"
        }

        //verificar se nariz esta dentro da area de vento
        if (narizEvent.inWindZone)
        {
            narizRB.AddForce(narizEvent.windZone.GetComponent<WindArea>().direction * narizEvent.windZone.GetComponent<WindArea>().strengh); //aplicar força do vento no "corpo nariz"
        }

        //verificar se chegou no chão depois de decolar
        if (narizEvent.inTerrain == true && fuelTime2 == 0)
        {
            //verificar se o paraquedas sumiu
            if(parachuteDisappear == false)
            {
                ///metodo pra diminuir o paraquedas
                scaleParachute = scaleParachute - 0.1f;
                parachuteRB.transform.localScale = new Vector3(scaleParachute, scaleParachute, scaleParachute);
                //verificar se ja chegou ao tamanho 0 e sumir com o objeto paraquedas
                if (parachuteRB.transform.localScale.x <= 0.0f)
                {
                    parachuteRB.gameObject.SetActive(false);
                    parachuteDisappear = true;
                }
            }
        }
    }
}
