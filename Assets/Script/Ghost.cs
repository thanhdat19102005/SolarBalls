using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ghost : MonoBehaviour
{
    public float moveSpeed = 5f; // Tốc độ di chuyển bug  
    public Vector2 direction; // Hướng di chuyển của  bug 
    public Rigidbody2D rb;
    public Camera secondaryCamera; // Tham chiếu đến Camera phụ

    public float maxHp = 40f;
    //   hieu  ung  Attack   
    public GameObject ps;

    public GameObject ghostBullet;
    public GameObject player;




    void Start()  {
        player = GameObject.FindGameObjectWithTag("player");

        rb = GetComponent<Rigidbody2D>();
        if (secondaryCamera == null)
        {

            return;
        }
        StartCoroutine(ChangeDirection()); // Bắt đầu di chuyển ngẫu nhiên

        //    create    random  bullet  for  ghost
        StartCoroutine(CreateBullet());
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = direction * moveSpeed; // Cập nhật vận tốc theo hướng
        KeepInsideCamera(); // Giữ Bug trong phạm vi camera phụ
                            // Kiểm tra hướng di chuyển để lật nhân vật
        if (direction.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Lật sang trái
        }
        else if (direction.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // Lật sang phải
        }
       
    }
    public IEnumerator ChangeDirection()
    {
        while (true)
        {
            direction = Random.insideUnitCircle.normalized; // Hướng ngẫu nhiên
            yield return new WaitForSeconds(Random.Range(1f, 3f)); //  dừng  1-3   giấy  mới tiếp   tục   vòng  lập   
        }
    }
    //   CreateBullet
    public IEnumerator   CreateBullet   ()   {
          while   (true){
            GameObject[] ghostArr = GameObject.FindGameObjectsWithTag("Ghost");       
            int    random      =    UnityEngine .Random  .Range   (0, ghostArr.Length);
           
             GameObject ghostBulletColone = Instantiate(ghostBullet,    ghostArr [random]. transform.position, transform.rotation);
            ghostBulletColone.GetComponent<GhostBullet>().SetPlayer(player);
            Destroy(ghostBulletColone, 4f);
            
            yield return new WaitForSeconds(15f);
            
                    
        }  
    }

    public void KeepInsideCamera()
    {
        if (secondaryCamera == null) return;

        Vector3 pos = transform.position;
        //  trả   về  vị  trí  nằm  trong   camera  
        Vector3 screenPos = secondaryCamera.WorldToViewportPoint(pos);
        // Nếu Bug chạm biên, đổi hướng ngược lại
        if (screenPos.x <= 0.05f || screenPos.x >= 0.95f)
        {
            direction.x *= -1;
        }
        if (screenPos.y <= 0.05f || screenPos.y >= 0.95f)
        {
            direction.y *= -1;
        }

        // Giữ Bug trong phạm vi màn hình của camera phụ
        transform.position = secondaryCamera.ViewportToWorldPoint(new Vector3(
            Mathf.Clamp(screenPos.x, 0.05f, 0.95f),
            Mathf.Clamp(screenPos.y, 0.05f, 0.95f),
            screenPos.z
        ));
    }
    public     void  TakeDamage ( float     damage) {
        maxHp -= damage;
         if  (maxHp  <= 0) {
               Destroy   ( gameObject );

        }
       
        
          
    }
       //   Attack   ghost
      public    void HitGhost  ()   
    {
        if (ps != null)
        {
            StartCoroutine(CallBack());


        }

    }
        
    public IEnumerator CallBack()
    {
        yield return new WaitForSeconds(0.2f);
        GameObject colone = Instantiate(ps, transform.position, Quaternion.identity);
               Destroy(colone, 0.4f);
    }

}
