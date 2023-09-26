using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuPrincipalMenager : MonoBehaviour
{
  [SerializeField]  private string nomeDoLevelDeJogo;
  [SerializeField] private GameObject painelDeMenuInicial;
  void Update()
  {
    if(Input.GetKeyDown(KeyCode.Escape))
    {
        Sair();
    }
  }
   public void Jogar()
   {
    GameManager.instance.LoadScene();

   }

   public void Sair()
   {
        Application.Quit();
   }
}
