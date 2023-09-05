using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int municaoMax;
    public int municaoAtual;
    public Text textoDaMunicao;

    public GameObject tiroRapido;
    public bool tiroRapidoAtivo;
   public Text tipoDeArma;
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
      municaoAtual = municaoMax;
      
    }

    // Update is called once per frame
    void Update()
    {
      
      Movimentar();
     

      if(municaoAtual > 0)
      {

       if(tiroRapidoAtivo == false)
      {
      tipoDeArma.text = "Tipo de Tiro: Único"; 
      AtirarLaser();
      
      }
      else 
      {
        tipoDeArma.text = "Tipo de Tiro: Tiro Rápido";
         AtirarLaserRapido();
      }
    
      if(laserDuplo == true)
      {
        tipoDeArma.text = "Tipo de Tiro: Tiro Duplo";
        tempoAtualDosLasersDuplos -= Time.deltaTime;
        AtirarLaserDuplo();

        if(tempoAtualDosLasersDuplos <= 0)
        { 
          DesativarTiroDuplo();  
        }
      }
       if(temSuperTiro == true)
      {
        tipoDeArma.text = "Tipo de Tiro: Super Tiro";
        AtivarSuperTiro();
        tempoAtualDoSuperTiro -= Time.deltaTime;
      }
      if(tempoAtualDoSuperTiro <= 0)
      {
        
        DesativarSuperTiro();
      
      }
     if(temSuperTiro == false && laserDuplo == false)
     {
      if(Input.GetKeyDown(KeyCode.Z))
      {
        if(tiroRapidoAtivo == true)
        {
          tiroRapidoAtivo = false;
        }
        else
        {
          tiroRapidoAtivo = true;
        }
      }
     }
    }
      textoDaMunicao.text = "Munição: " + municaoAtual;
      if(municaoAtual <= 0)
      {
        textoDaMunicao.text = "Munição: 0 ";
        tipoDeArma.text = "Tipo de Tiro: Nulo";
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
        if(laserDuplo == false && temSuperTiro == false && tiroRapidoAtivo == false)
        {
          Instantiate(laser, canhaoDeDisparoUnico.position, canhaoDeDisparoUnico.rotation);
          municaoAtual -= 1;
        }
      }
      
    }
     private void AtirarLaserDuplo()
     { 
      if(laserDuplo == true)
      {
        if(Input.GetKeyDown(KeyCode.Space))
        {
          DesativarSuperTiro();
        Instantiate(laser, canhaoDuploJogador.position, canhaoDuploJogador.rotation);
        Instantiate(laser, canhaoDuploJogador2.position, canhaoDuploJogador2.rotation);
        municaoAtual -= 2;
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
          municaoAtual -= 3;
         
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
    private void AtirarLaserRapido()
    {
      
       if(Input.GetKeyDown(KeyCode.Space))
       {
         if(laserDuplo == false && temSuperTiro == false)
        {
          Instantiate(tiroRapido, canhaoDeDisparoUnico.position, canhaoDeDisparoUnico.rotation);
          municaoAtual -= 1;
        }
       }
       
    }
  
    
    
  
}
