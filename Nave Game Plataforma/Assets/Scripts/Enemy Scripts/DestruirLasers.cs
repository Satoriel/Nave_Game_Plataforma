using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirLasers : MonoBehaviour
{
    public float tempoDeVidaDoLaser;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, tempoDeVidaDoLaser);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
