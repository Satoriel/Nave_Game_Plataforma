using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeObjetos : MonoBehaviour
{
    public GameObject[] objetosParaSpawnar;

    public Transform[] pontoDeSpawn;
    public float tempoMaxEntreSpawn;
    public float tempoAtualEntreSpawn;
    // Start is called before the first frame update
    void Start()
    {
        tempoAtualEntreSpawn = tempoMaxEntreSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        tempoAtualEntreSpawn -= Time.deltaTime;
        if(tempoAtualEntreSpawn <= 0)
        {
            SpawnarInimigo();
        }
    }
    private void SpawnarInimigo()
    {
        int objetoAleatorio = Random.Range(0, objetosParaSpawnar.Length);
        int pontoAleatorio = Random.Range(0, pontoDeSpawn.Length);

        Instantiate(objetosParaSpawnar[objetoAleatorio], pontoDeSpawn[pontoAleatorio]. position, Quaternion.Euler(0f, 0f, 90f));
        tempoAtualEntreSpawn = tempoMaxEntreSpawn;
    }
}
