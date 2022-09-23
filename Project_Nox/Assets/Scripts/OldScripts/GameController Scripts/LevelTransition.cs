using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelTransition : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("PortalExit")) {
            SceneManager.LoadScene("LevelHub");
        }
        if (other.CompareTag("Level1")) {
            SceneManager.LoadScene("Level_01");
        }
        if (other.CompareTag("Level2")) {
            SceneManager.LoadScene("Level_02");
        }
        if (other.CompareTag("Level3")) {
            SceneManager.LoadScene("Level_03");
        }
    }
}
