using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserJogador : MonoBehaviour
{
    public int danoParaDar;
    public float laserVel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovimentarLaser();
    }
    private void MovimentarLaser()
    {
      transform.Translate(Vector3.up * laserVel * Time.deltaTime);
    }

     void OnTriggerEnter2D (Collider2D other)
    {
      if(other.gameObject.CompareTag("Inimigo"))
      {
        other.gameObject.GetComponent<Enemy>().MachucarInimigo(danoParaDar);
        Destroy(this.gameObject);
      }
    }
}
