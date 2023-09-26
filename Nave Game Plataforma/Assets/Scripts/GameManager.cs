using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Transform posicaoDoPlayer;

    public Text textoDePontuacaoAtual;
    public GameObject Player;

    public int pontuacaoAtual;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
             instance = this;
             DontDestroyOnLoad(transform);
        }
        else
        {
            Destroy(this.gameObject);
        }
           
        
        
    }
    void Start()
    {
        SceneManager.LoadScene("Menu");
        pontuacaoAtual = 0;
        textoDePontuacaoAtual.text = "SCORE: " + pontuacaoAtual;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Sair();
        }
        
    }
    public void AumentarPontuacao(int pontosParaReceber)
    {
        pontuacaoAtual += pontosParaReceber;
        textoDePontuacaoAtual.text = "SCORE: " + pontuacaoAtual;
    }
    public void Sair()
    {
        Application.Quit();
    }
    public void LoadScene()
    {
        
        SceneManager.LoadScene("Interface");
        SceneManager.LoadSceneAsync("SampleScene", LoadSceneMode.Additive).completed += Operation =>
        {
        Vector2 posicaoDoPlayer = (Vector2)GameObject.FindWithTag("Posicao").transform.position;
        
            Instantiate(Player, (Vector3)posicaoDoPlayer, Quaternion.Euler(0f,0f,-90f));  
        }; 
      
        

    }
}
