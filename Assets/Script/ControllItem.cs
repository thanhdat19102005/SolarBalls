using System.Collections.Generic;
using Unity.Properties;
using Unity.VisualScripting;
using UnityEngine;

public class ControllItem : MonoBehaviour
{
      
    public GameObject root; // Kéo thả đối tượng Canvas hoặc ActiveInventory vào đây
    public GameObject player;

    public int count = 0;
    List<GameObject> allGameObjects;
    public List<GameObject> gameObjectOfPlayer;
    public void Start()
    {
        
        Transform[] allTransforms = root.GetComponentsInChildren<Transform>(true); // true để lấy cả các đối tượng ẩn
        allGameObjects = new List<GameObject>();
        foreach   ( Transform   t    in      allTransforms   )    {
            if (t.tag.Equals("Active")) {
                allGameObjects.Add(t.gameObject);
              
            }
           
        }

        Transform[] allTransformPlayer   = player.GetComponentsInChildren<Transform>(true);
       gameObjectOfPlayer  = new List<GameObject>   ();    
       foreach    (Transform    t1     in allTransformPlayer){
               if   (t1  .tag   .Equals     ("Weapon")){
                gameObjectOfPlayer  .Add    (t1.gameObject);    
                }   
        }
        




    }
    public void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (count < allGameObjects.Count - 1)
            {
                allGameObjects[count].SetActive(false);
                gameObjectOfPlayer[count].SetActive(false);
                count++;
                allGameObjects[count].SetActive(true);
               
               gameObjectOfPlayer[count].SetActive(true);

            }
            else if (count == allGameObjects.Count - 1)
            {
                allGameObjects[count].SetActive(false);

                count = 0;
                allGameObjects[count].SetActive(true);
                gameObjectOfPlayer[count].SetActive(true);
            }
         }
        
    }

    


}
