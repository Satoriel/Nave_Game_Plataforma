using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float laserVel;
    public int danoParaDar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LaserMov();
    }
    private void LaserMov()
    {
        transform.Translate(Vector3.up * laserVel * Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {   
            other.gameObject.GetComponent<PlayerVida>().MachucarJogador(danoParaDar);
            Destroy(this.gameObject);
        }
    }
}
