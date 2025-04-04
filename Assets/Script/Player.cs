using System;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
using static System.TimeZoneInfo;
using Unity.Cinemachine;
using Unity.VisualScripting;
using TMPro;
using System.Runtime.InteropServices;
using System.Collections;

public class Player : MonoBehaviour {
    public static Player Instance;



    public Vector3 Destination;
    public float moveSpeed = 8f;
    public GameObject troThu;
    public float currentDamage = 0f;
    public float maxDamage = 50f;
    public GameObject image;


    public CinemachineImpulseSource impulseSource;


    public Boolean check = false;
    public AnimationCurve curve;
    private bool isMoving = false;
    public GameObject des;
    public GameObject fadeTransition;

    private void Awake() {


    }

    void Start() {
        currentDamage = maxDamage;
        impulseSource = GetComponent<CinemachineImpulseSource>();

    }

    // Update is called once per frame
    void Update() {


        Vector3 inputPlayer = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        GetComponent<Rigidbody2D>().linearVelocity = moveSpeed * inputPlayer;

        if (inputPlayer != Vector3.zero) {
            GetComponent<Animator>().SetBool("state", true);

        }
        else if (inputPlayer == Vector3.zero)
        {
            GetComponent<Animator>().SetBool("state", false);
        }

        if (inputPlayer.x > 0) {
            //  GetComponent<SpriteRenderer>().flipX =    false;

            transform.localScale = new Vector3(1, 1, 1);
            troThu.GetComponent<SpriteRenderer>().flipX = false;

        }
        else if (inputPlayer.x < 0) {

            //  GetComponent<SpriteRenderer>().flipX =      true ;
            troThu.GetComponent<SpriteRenderer>().flipX = true;

            transform.localScale = new Vector3(-1, 1, 1);

        }



    }







    void FixedUpdate()
    {
        if (check == true)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.AddForce(Vector2.right *  18f, ForceMode2D.Impulse);

            }
            check = false;
        }



    }



    public void TakeDamage(float damage)
    {
        currentDamage -= damage;
        currentDamage = Mathf.Max(currentDamage, 0);
        UpdateHp();
        if (currentDamage <= 0)
        {
            if (gameObject != null)
                Destroy(gameObject);
            SceneManager.LoadScene("End");
            
        }




    }
    public void UpdateHp() {
        if (image != null)
            image.GetComponent<UnityEngine.UI.Image>().fillAmount = currentDamage / maxDamage;



    }
    //  kiểm     tra   player   có  chạm  vào    cỏ  ko  nếu  có  thì  làm  mờ     
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Top"))
        {
            // Lấy SpriteRenderer của đối tượng bị va chạm
            Tilemap tilemap = collision.gameObject.GetComponent<Tilemap>();

            if (tilemap != null)  // Kiểm tra xem đối tượng có SpriteRenderer không
            {
                Color newColor = tilemap.color;  // Lấy màu hiện tại của đối tượng
                newColor.a = 220f / 255f;  // Đặt giá trị Alpha mới (230 trên 255 tương đương khoảng 0.9)
                tilemap.color = newColor;  // Cập nhật màu mới
            }

        }
        //  collision  with   ghotBullet  
        if (collision.gameObject.CompareTag("GhostBullet"))
        {
            CameraShakeManager.instance.CameraShake(impulseSource);
            check = true;
        }


        if (collision.gameObject.CompareTag("Coin"))
        {

            collision.gameObject.GetComponent<Coin>().SetItem(this.des);

        }
        if (collision.gameObject.CompareTag("Health")) {
            currentDamage = maxDamage;
            UpdateHp();

        }
        if (collision.gameObject.CompareTag("Gate") && SceneManager.GetActiveScene().name.Equals("Scene1"))
        {
            StartCoroutine(TransitionScene1());

        }
        if (collision.gameObject.CompareTag("Gate") && SceneManager.GetActiveScene().name.Equals("Scene2"))
        {
            StartCoroutine(TransitionScene2());
        }


    }



    public IEnumerator TransitionScene1()
    {
        fadeTransition.GetComponent<Animator>().SetTrigger("endState");
        yield return new WaitForSeconds(3f);
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




    //   thoát ra     quay trở  về  độ trong   suốt  ban đầu
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Top"))
        {
            // Lấy SpriteRenderer của đối tượng bị va chạm
            Tilemap tilemap = collision.gameObject.GetComponent<Tilemap>();

            if (tilemap != null)  // Kiểm tra xem đối tượng có SpriteRenderer không
            {
                Color newColor = tilemap.color;  // Lấy màu hiện tại của đối tượng
                newColor.a = 255f / 255f;  // Đặt giá trị Alpha mới (255 trên 255 tương đương khoảng 0.9)
                tilemap.color = newColor;  // Cập nhật màu mới
            }

        }
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("bug") || collision.gameObject.CompareTag("Ghost") || collision.gameObject.CompareTag("Clown"))     {
            CameraShakeManager.instance.CameraShake(impulseSource);
          

                
            check = true;




        }  
           
               
    }

   


}
