using System;
using System.Collections;




using UnityEngine;

using UnityEngine.SceneManagement;

public class Sword : MonoBehaviour
{
    public WeaponHpData dataHp;

    public float knockbackForce = 50f;
    public GameObject Slash;
    //check   Attack    bug   
    public Boolean check =   false  ;
    public GameObject bugColone;
 

    public GameObject fadeTransition;
    public GameObject player;

    //     check    Attack  ghost;
    public Boolean checkGhost = false;
    public GameObject ghostColone;

    public  Vector2 knockbackDirection;
    void Start() {

    }
    // Update is called once per frame
    void Update()
    {    // nên goi   chi     1  frame  

        gameObject .transform.SetParent(player.transform);


        if (Input.GetMouseButtonDown(0)) {
       
            Controller();
        }

        //   Attack    bug    
        if (Input.GetMouseButtonDown(0) && check == true) {
            if (bugColone != null)
            {
                Rigidbody2D enemyRb = bugColone.GetComponent<Rigidbody2D>();
                if (enemyRb != null)
                {
                    knockbackDirection = (bugColone.transform.position - transform.position).normalized;
                    enemyRb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
                    bugColone.GetComponent<BugKt>().hitBug();

                }
            }
            else
            {
                
            }
            check = false;
        }

        if   (Input.GetMouseButtonDown(0)  &&  checkGhost == true &&     ghostColone  != null )   {
                knockbackDirection = (transform.position - ghostColone.transform.position).normalized;
                ghostColone.GetComponent<Rigidbody2D>().AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
            checkGhost = false;

           }

        //   test  call     class     ScreenShake  

      

    }

    public void Controller()
    {
        GetComponent<Animator>().SetTrigger("Attack");
        Slash.GetComponent<Animator>().SetTrigger("state");
        ManagerAudio.instance.MusicKnife();
    }
    //   Sword   va cham  voi    bug  

    private void OnTriggerEnter2D(UnityEngine.Collider2D collision) {
        // Kiểm tra xem đối tượng va chạm có Tag là "bug" không
        if (collision.gameObject.CompareTag("bug")) {
            bugColone = collision.gameObject;
            Rigidbody2D enemyRb = collision.gameObject.GetComponent<Rigidbody2D>();
                if (enemyRb != null){
                check = true;
            }
                bugColone.GetComponent<BugKt>().TakeDamage(dataHp.damage);
        }
        if   (collision   .gameObject    .CompareTag   ("Ghost"))  {
               GameObject ghost = collision.gameObject;
              ghostColone = collision.gameObject;
               if     (ghost    !=   null) {
                checkGhost = true;
                ghost.GetComponent<Ghost>().TakeDamage( dataHp .damage);
                ghost.GetComponent<Ghost>().HitGhost();


            }

        }    


        if (collision.gameObject.CompareTag("Gate") && SceneManager.GetActiveScene().name.Equals("Scene1")) {
            StartCoroutine(TransitionScene1());

             }
       if    (collision.gameObject.CompareTag("Gate") && SceneManager.GetActiveScene().name.Equals("Scene2")) {
                      StartCoroutine(TransitionScene2());    
        }
 }    // chuyen  animation  scene1
        public IEnumerator    TransitionScene1  ()  {
        fadeTransition.GetComponent<Animator>().SetTrigger("endState");     
        yield return   new   WaitForSeconds  (3f);
       fadeTransition.GetComponent<Animator>().SetTrigger("State");
      GameObject[] objects = GameObject.FindGameObjectsWithTag("nextScene");
      objects[0].GetComponent<thuthu>().ChangeScene("Scene2");
    }
    // chuyen  animation  scene2
    public IEnumerator TransitionScene2()
    {
        fadeTransition.GetComponent<Animator>().SetTrigger("endState");
        yield return new WaitForSeconds(3f);
        fadeTransition.GetComponent<Animator>().SetTrigger("State");
        GameObject[] objects = GameObject.FindGameObjectsWithTag("nextScene");
        objects[0].GetComponent<thuthu>().ChangeScene("Scene1");
    }
    //     kiểm  tra   có    va   chạm     với    vật  phẩm    không   
    private void OnTriggerStay2D(UnityEngine.Collider2D collision) {
        if (collision.gameObject.CompareTag("Item"))
        {
         
               GameObject itemVFX = collision.gameObject;

            if (Input.GetMouseButtonDown(0))
            {
                if (itemVFX != null && itemVFX.name.Equals("Item"))  {
                    itemVFX.GetComponent<Item>().HitItem();
                    Destroy(itemVFX, 0.3f);
 
               //  create   the   coin  
                   GameObject     coinColone   =      Instantiate(CameraShakeManager.instance.GetCoin(), transform.position, Quaternion.identity);
                  Destroy(coinColone ,   6.5f);

                 }
                else if (itemVFX != null && itemVFX.name.Equals("3Box"))
                {
                    itemVFX.GetComponent<Item>().HitItem1();
                    Destroy(itemVFX, 0.3f);
                    GameObject healthColone   = Instantiate(CameraShakeManager.instance.GetHealth  ()  , transform.position, Quaternion.identity);
                    healthColone.GetComponent<Health>().SetItem( gameObject.transform.parent.gameObject);
                    


                }
               else   if      (itemVFX  !=   null  &&  itemVFX.name.Equals("Chest")) {
                    itemVFX.GetComponent<Item>().HitItem1();
                    Destroy(itemVFX, 0.3f);
                }
            }
        }

       


    }
    
    


}  