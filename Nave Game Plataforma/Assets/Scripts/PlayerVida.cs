using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVida : MonoBehaviour
{
    public int vidaMaxima;
    public int vidaAtual;

    public bool escudo;
    // Start is called before the first frame update
    void Start()
    {
        vidaAtual = vidaMaxima;
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

            if(vidaAtual <= 0)
            {
                Debug.Log("Game Over");
            }
        }
    }
}
