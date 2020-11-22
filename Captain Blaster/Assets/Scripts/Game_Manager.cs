using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    bool gameHasEnded = false;
    public GameObject gameOverText;
    private AudioSource gameOverAudio;

     void Awake() {
       gameOverAudio = GetComponent<AudioSource>();
    }

   public void EndGame()
   {
     if (gameHasEnded == false)
     {
        gameHasEnded = true;
        Invoke ("Restart", 3f);
     }
   }

   void Restart()
   {
      gameOverText.SetActive(true);
      gameOverAudio.Play();
   }
}
