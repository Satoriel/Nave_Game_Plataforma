using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemyVel;

    public Transform canhaoDeDisparoInimigo;
    public Transform canhaoDuplo;
    public Transform canhaoDuplo2;

    public bool atiradorDuplo;

    public float tempoAtualDosLasers;

    public float TempoMaxDosLasers;

    public GameObject laserInimigo;

    public bool inimigoAtirador;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovimentarInimigo();

        if(inimigoAtirador == true)
        {
            AtirarLaserInimigo();
        }

        if(atiradorDuplo == true)
        {
            TiroDuploInimigo();
        }
    }
    private void MovimentarInimigo()
    {
        transform.Translate(Vector3.up * enemyVel * Time.deltaTime);
    }

    private void AtirarLaserInimigo()
    {
        tempoAtualDosLasers -= Time.deltaTime;
        if(tempoAtualDosLasers <= 0)
        {
            Instantiate(laserInimigo, canhaoDeDisparoInimigo.position, Quaternion.Euler(0f, 0f, 90f));
            tempoAtualDosLasers = TempoMaxDosLasers;
        }
    }

   private void TiroDuploInimigo()
    {
        tempoAtualDosLasers -= Time.deltaTime;
        if(tempoAtualDosLasers <= 0) 
        {
            Instantiate(laserInimigo, canhaoDuplo.position, Quaternion.Euler(0f, 0f, 110f));
            Instantiate(laserInimigo, canhaoDuplo2.position, Quaternion.Euler(0f,0f, 70f));
            tempoAtualDosLasers = TempoMaxDosLasers;
        }
    }
}