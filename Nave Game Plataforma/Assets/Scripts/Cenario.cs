using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cenario : MonoBehaviour
{
    public float velocidadeDeCenario;
    

    // Update is called once per frame
    void Update()
    {
       MovimentarCenario(); 
    }
    private void MovimentarCenario()
    {
        Vector2 deslocamento = new Vector2(Time.time * velocidadeDeCenario, 0f);
        GetComponent<Renderer>().material.mainTextureOffset = deslocamento;
    }
}
