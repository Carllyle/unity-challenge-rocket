using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsControl : MonoBehaviour
{
    public bool gameBegin = false;
    public RocketController rocket;
    public Transform positionRocket;
    
    //botao pra resetar o jogo
    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //recarregar cena inicial
        gameBegin = false; //controlador pra ativar o game
    }

    //botao pra inicia o jogo/foguete
    public void StartGame()
    {
        rocket.proRB.isKinematic = false; //pra desativar o kinematic e soltar o foguete
        gameBegin = true; //controlador pra ativar o game
    }

    //botao pra fechar jogo
    public void ExitGame()
    {
        Application.Quit();
    }

    //botao pra virar o foguete pra esquerda
    public void LeftRocket()
    {
        positionRocket.transform.eulerAngles = new Vector3(
            positionRocket.transform.eulerAngles.x,
            positionRocket.transform.eulerAngles.y,
            positionRocket.transform.eulerAngles.z + 10
        );
    }

    //botao pra virar o foguete pra direita
    public void RightRocket()
    {
        positionRocket.transform.eulerAngles = new Vector3(
            positionRocket.transform.eulerAngles.x,
            positionRocket.transform.eulerAngles.y,
            positionRocket.transform.eulerAngles.z -10
        );
    }
}
