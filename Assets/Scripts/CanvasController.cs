using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    [Header("Text")]
    public Text velocityTX;
    public Text heightTX;
    public Text fuelTX;
    public Text fuelTX2;
    public Text heightTXMax;
    [Header("Rocket")]
    public RocketController rocket;
    bool verificadorDe1x = false; //verificador pra garantir a execução de apenas 1x

    // Update is called once per frame
    void Update()
    {
        velocityTX.text = "Velocity: " + rocket.narizRB.velocity.magnitude.ToString("0.00"); //mostrar velocidade na tela
        heightTX.text = "Height: " + rocket.narizRB.transform.position.y.ToString("0.00"); //mostrar altura na tela
        fuelTX.text = "Fuel: " + rocket.fuelTime.ToString("0.00"); //mostrar combustivel da primeira etapa na tela
        fuelTX2.text = "Fuel 2: " + rocket.fuelTime2.ToString("0.00"); //mostrar combustivel da segunda etapa na tela

        ///metodo para salvar a altura maxima, apenas 1x
        if (rocket.narizRB.velocity.y < 0 && rocket.fuelTime2 == 0 && verificadorDe1x == false)
        {
            heightTXMax.text = "Height Max: " + rocket.narizRB.transform.position.y.ToString("0.00");
            verificadorDe1x = true;
        }      
    }
}
