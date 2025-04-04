using System.Collections;
using UnityEngine;

public class Item : MonoBehaviour{
    public GameObject itemVFX;
    public GameObject item1VFX;
   




    //     danh  vao   thung 
 public     void    HitItem     () {
        if (itemVFX != null) {
            StartCoroutine(CallBack());

        }


    }
        public  IEnumerator   CallBack   () {
        yield return new WaitForSeconds(0f);
        GameObject colone = Instantiate(itemVFX, transform.position, Quaternion.identity);
        Destroy(colone, 0.5f);
         
       
    }
     //    danh  vao  3   hop    

    public   void     HitItem1 ()
    {
        if (item1VFX != null)
        {
            StartCoroutine(CallBack1());

        }

    }

    public     IEnumerator   CallBack1()
    {
        yield return new WaitForSeconds(0f);
        GameObject colone = Instantiate(item1VFX, transform.position, Quaternion.identity);
     

    }

   


}
