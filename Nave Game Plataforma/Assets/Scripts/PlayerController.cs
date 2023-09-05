using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject superTiro;
    public Rigidbody2D oRigidbody2d;
    public float velocidade;
    public GameObject laser;
    public Transform canhaoDeDisparoUnico;
    public bool laserDuplo;
    private Vector2 controle;
    public float tempoAtualDosLasersDuplos;
    public float tempoMaximoDosLasersDuplos;
    public Transform canhaoDuploJogador;
    public Transform canhaoDuploJogador2;
    public bool temSuperTiro;
    public float tempoAtualDoSuperTiro;
    public float tempoMaxDoSuperTiro;
    

    // Start is called before the first frame update
    void Start()
    {
      laserDuplo = false; 
      temSuperTiro = false;
      tempoAtualDosLasersDuplos = tempoMaximoDosLasersDuplos; 
      tempoAtualDoSuperTiro = tempoMaxDoSuperTiro;
    }

    // Update is called once per frame
    void Update()
    {
      Movimentar();
      AtirarLaser();
      if(laserDuplo == true)
      {
        tempoAtualDosLasersDuplos -= Time.deltaTime;

        if(tempoAtualDosLasersDuplos <= 0)
        {
          DesativarTiroDuplo();
        }
      }
       if(superTiro == true)
      {
        
        AtivarSuperTiro();
        tempoAtualDoSuperTiro -= Time.deltaTime;
      }
      if(tempoAtualDoSuperTiro <= 0)
      {
        DesativarSuperTiro();
      } 
    }
    
    private void Movimentar()
    {
        controle = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));  
        oRigidbody2d.velocity = controle.normalized * velocidade;
    }
    private void AtirarLaser()
    {
      if(Input.GetKeyDown(KeyCode.Space))
      {
        if(laserDuplo == false && temSuperTiro == false)
        {
          Instantiate(laser, canhaoDeDisparoUnico.position, canhaoDeDisparoUnico.rotation);
        }
      
      if(laserDuplo == true)
      {
        DesativarSuperTiro();
        Instantiate(laser, canhaoDuploJogador.position, canhaoDuploJogador.rotation);
        Instantiate(laser, canhaoDuploJogador2.position, canhaoDuploJogador2.rotation);
      }
      }
    }
    private void AtivarSuperTiro()
    {
      if(Input.GetKeyDown(KeyCode.Space))
      {
        if(temSuperTiro == true)
        {
          DesativarTiroDuplo();
          Instantiate(superTiro, canhaoDeDisparoUnico.position, canhaoDeDisparoUnico.rotation);
        }
      }
    }
    private void DesativarTiroDuplo()
    { 
      laserDuplo = false;
      tempoAtualDosLasersDuplos = tempoMaximoDosLasersDuplos;
    }
    private void DesativarSuperTiro()
    {
      temSuperTiro = false;
      tempoAtualDoSuperTiro = tempoMaxDoSuperTiro;
    }
  
}
