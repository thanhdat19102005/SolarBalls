using System;
using UnityEngine;
using UnityEngine.Rendering;

public class BowBullet : MonoBehaviour
{
    public WeaponHpData dataHp;
     
    public float moveSpeed = 15f;
    public GameObject blood;

    //       boolean     dùng   để   check      addforce    cho   bug    
    public Boolean check = true;
    public Vector2 direction;
     //    gamObject  dung  de  gan 
    public GameObject contain;
    //    luc  danh 
    public float knockbackForce = 20f;
    public GameObject smoke;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
     
     }

    // Update is called once per frame
    void Update()  {

              transform.Translate(moveSpeed * Time.deltaTime ,0,0);
            if   (check    == true) {
              if (contain != null) {
                direction = transform.position - contain.transform.position;
                contain.GetComponent<Rigidbody2D>().AddForce(direction * knockbackForce, ForceMode2D.Impulse);
                
                


            }  

    }   
            

    }

    private void OnTriggerEnter2D(Collider2D collision){
                  if  (collision   .gameObject   .CompareTag  ("bug") ) {
                  GameObject     bloodClone   =     Instantiate(blood, transform.position, transform.rotation);
                   Destroy(bloodClone,  0.5f ); 
                 // set  check  
                  check   =  true;

             
                GameObject bugColone = collision.gameObject;
            if (bugColone != null) {  bugColone.GetComponent<Bug>().TakeDamage(dataHp.damage);
                contain = bugColone;
            } 
            }  
                if  (collision   .gameObject  .CompareTag    ("Ghost")  ){
                  GameObject smokeColone= Instantiate( smoke, transform.position, transform.rotation);
                  check = true;
                  Destroy(smokeColone, 0.5f);


               GameObject   ghostColone = collision.gameObject;
            if (ghostColone != null)  {
                 ghostColone.GetComponent<Ghost>().TakeDamage(dataHp.damage);
                contain = ghostColone;
            }
        }  
                if   (collision   .gameObject   .CompareTag   ("Clown"))   {
            GameObject bloodClone = Instantiate(blood, transform.position, transform.rotation);
            check = true;
            Destroy(bloodClone, 0.5f);
          GameObject clownColone  = collision.gameObject;

            if (clownColone != null)
            {
                clownColone.GetComponent<Clown>().TakeDamage(dataHp.damage);
            
            }

        }


    }

}
