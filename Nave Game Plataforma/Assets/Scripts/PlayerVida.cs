using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerVida : MonoBehaviour
{
    public Slider BarraDeVida;
    public int vidaMaxima;
    public int vidaAtual;

    public int vidaMaximaDoEscudo;
    public int vidaAtualDoEscudo;

    public GameObject escudoDoJogador;

    public bool escudo;
    // Start is called before the first frame update
    void Start()
    {
        vidaAtual = vidaMaxima;
        BarraDeVida.maxValue = vidaMaxima;
        BarraDeVida.value = vidaAtual;
        
        escudoDoJogador.SetActive(false);
        escudo = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MachucarJogador(int danoParaReceber)
    {
        if(escudo == false)
        {
            vidaAtual -= danoParaReceber;
            BarraDeVida.value = vidaAtual;

            if(vidaAtual <= 0)
            {
                Debug.Log("Game Over");
            }
        }
        else
        {
            vidaAtualDoEscudo -= danoParaReceber;

            if(vidaAtualDoEscudo <= 0)
            {
                escudoDoJogador.SetActive(false);
                escudo = false;
            }
        }
    }
    public void AtivarEscudo()
    {
        vidaAtualDoEscudo = vidaMaximaDoEscudo;
        escudoDoJogador.SetActive(true);
        escudo = true;
    }
}
