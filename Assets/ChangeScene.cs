using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
   void Start()
   {
      
   }

   void Update()
   {
      
   }

   public void GoToAsteroidEscape()
   {
      SceneManager.LoadScene(1);
   }

   public void QuitGame()
   {
      Debug.Log("In Quit Game");
      SceneManager.LoadScene(0);
   }

   public void RestartGame()
   {
      Time.timeScale = 1.0f;
      SceneManager.LoadScene(1);
      //Todo: Debug here
      print("Restart Button Is Working!");
   }
}
