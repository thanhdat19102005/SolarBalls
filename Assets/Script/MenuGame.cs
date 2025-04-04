using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGame : MonoBehaviour
{
    public void QuitGame()
    {
        StartCoroutine(CallBack1());

    }

  
    public IEnumerator CallBack1()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Start");

    }
}
