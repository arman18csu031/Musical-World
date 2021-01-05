using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
   public void ChangeToScene (int sceneToChangeTo)
    {
        SceneManager.LoadScene(sceneToChangeTo);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void home()
    {
        SceneManager.LoadScene(0);
    }
}
