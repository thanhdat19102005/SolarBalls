using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMusic : MonoBehaviour
{
    public GameObject audioManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioManager.GetComponent<ManagerAudio>().MusicBackGround();

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void PlayGame()
    {
        StartCoroutine(CallBack());

    }



    public IEnumerator CallBack()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Scene1");

    }
    public void QuitGame(){
        Application.Quit();
       
        
    }


}  