using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItensColetaveis : MonoBehaviour
{
    public bool tiroDuplo;
    public bool itemEscudo;
    public bool itemSuperTiro;

    void OnTriggerEnter2D (Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(itemEscudo == true)
            {   
                other.GetComponent<PlayerVida>().escudo = false;
                other.GetComponent<PlayerVida>().tempoAtualDoEscudo = other.GetComponent<PlayerVida>().tempoMaxDoEscudo;
                other.GetComponent<PlayerVida>().AtivarEscudo();
            }
        }
        if(tiroDuplo == true)
        {
            other.GetComponent<PlayerController>().laserDuplo = false;
            other.GetComponent<PlayerController>().tempoAtualDosLasersDuplos = other.GetComponent<PlayerController>().tempoMaximoDosLasersDuplos;
            other.GetComponent<PlayerController>().laserDuplo = true;
        }

        if(itemSuperTiro == true)
        {
            other.GetComponent<PlayerController>().temSuperTiro = false;
            other.GetComponent<PlayerController>().tempoAtualDoSuperTiro = other.GetComponent<PlayerController>().tempoMaxDoSuperTiro;
            other.GetComponent<PlayerController>().temSuperTiro = true;
        }
        Destroy(this.gameObject);
    }
   
}
