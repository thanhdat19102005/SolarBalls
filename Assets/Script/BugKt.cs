using System.Collections;
using UnityEngine;

public class BugKt : Bug 
{
    public GameObject  ps;
    public override void hitBug()
    {
        base.hitBug();    
       if   (ps  !=    null){
            StartCoroutine(CallBack());


            }
        }      

      public   IEnumerator     CallBack  ()
    {
        yield return new WaitForSeconds(0f);
        GameObject colone = Instantiate(ps, transform.position, Quaternion.identity);
        Destroy(colone, 0.4f);
    }


}


