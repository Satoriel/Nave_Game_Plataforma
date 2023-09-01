using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D oRigidbody2d;
    public float velocidade;
    public GameObject laser;
    public Transform canhaoDeDisparoUnico;
    public bool laserDuplo;
    private Vector2 controle;

    // Start is called before the first frame update
    void Start()
    {
      laserDuplo = false;  
    }

    // Update is called once per frame
    void Update()
    {
      Movimentar();
      AtirarLaser();  
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
        if(laserDuplo == false)
        {
          Instantiate(laser, canhaoDeDisparoUnico.position, canhaoDeDisparoUnico.rotation);
        }
      }
    }
}
