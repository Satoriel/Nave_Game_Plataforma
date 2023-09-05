using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemyVel;

    public GameObject escudoInimigo;

    public bool temEscudo;

    public GameObject itemPraDroppar;

    public int vidaMaxEscInimigo;
    public int vidaAtualEscInimigo;

    public Transform canhaoDeDisparoInimigo;
    public Transform canhaoDuplo;
    public Transform canhaoDuplo2;

    public bool atiradorDuplo;

    public float tempoAtualDosLasers;

    public float TempoMaxDosLasers;

    public GameObject laserInimigo;

    public int chanceDeDrop;

    public bool inimigoAtirador;

    public int vidaAtualInimiga;
    public int vidaMaximaInimiga;

    public int danoFisico;

    public int pontosParaDar;

    

    // Start is called before the first frame update
    void Start()
    {
        vidaAtualInimiga = vidaMaximaInimiga;
        if(temEscudo == true)
        {
            vidaAtualEscInimigo = vidaMaxEscInimigo;
        }
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

    public void MachucarInimigo(int danoParaReceber)
    {
        if(temEscudo == false)
        {
             vidaAtualInimiga -= danoParaReceber;

        if(vidaAtualInimiga <= 0)
        {
            GameManager.instance.AumentarPontuacao(pontosParaDar);


            int numeroAleatorio = Random.Range(0, 100);
            if(numeroAleatorio <= chanceDeDrop)
            {
                Instantiate(itemPraDroppar, transform.position, Quaternion.Euler(0f, 0f, 0f));
            }

            Destroy(this.gameObject);
        }

        }
        else
        {
            vidaAtualEscInimigo -= danoParaReceber;

            if(vidaAtualEscInimigo <= 0)
            {
                escudoInimigo.SetActive(false);
                temEscudo = false;
            }
        }
       
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

     void OnTriggerEnter2D (Collider2D other)
    {
      if(other.gameObject.CompareTag("Player"))
      {
        other.gameObject.GetComponent<PlayerVida>().MachucarJogador(danoFisico);
      }
    }
    public void AtivarEscudoInimigo()
    {
        vidaAtualEscInimigo = vidaMaxEscInimigo;
        escudoInimigo.SetActive(true);
        temEscudo = true;
    }
    
}
