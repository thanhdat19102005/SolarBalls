using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountGhost : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        GameObject[] ghostArr = GameObject.FindGameObjectsWithTag("Ghost");
        

        if (ghostArr.Length == 0) {
          StartCoroutine   ( CallBack());
       }






    }

       public  IEnumerator    CallBack  ()
    {
       yield return new WaitForSeconds(10f);
        SceneManager.LoadScene("End");
    }
}
