using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
   public void GoToAsteroidEscape()
   {
      SceneManager.LoadScene(1);
   }

   public void QuitGame()
   {
      Debug.Log("In Quit Game");
      Application.Quit();  // Quit the application
   }

   public void RestartGame()
   {
      Time.timeScale = 1.0f;
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }
}
