using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Text textoDePontuacaoAtual;

    public int pontuacaoAtual;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        pontuacaoAtual = 0;
        textoDePontuacaoAtual.text = "SCORE: " + pontuacaoAtual;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AumentarPontuacao(int pontosParaReceber)
    {
        pontuacaoAtual += pontosParaReceber;
        textoDePontuacaoAtual.text = "SCORE: " + pontuacaoAtual;
    }
}
