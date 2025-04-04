using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Clown : MonoBehaviour {
    public float moveSpeed = 2f; // Tốc độ di chuyển bug  
    public Vector2 direction; // Hướng di chuyển của  bug 
    public Rigidbody2D rb;
    public Camera secondaryCamera; // Tham chiếu đến Camera phụ
    public float damageEnter = 10f;
    public float damageStay = 4f;


    public float maxHp = 40f;
    // image bug     blood   
    public GameObject image;


    void Start() {
          rb = GetComponent<Rigidbody2D>();
        if (secondaryCamera == null)
        {

            return;
        }
        StartCoroutine(ChangeDirection()); // Bắt đầu di chuyển ngẫu nhiên
        StartCoroutine(BoomRandom());


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
    //   create   random  boom   
    public IEnumerator BoomRandom()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3f, 6f));
            GetComponent<Animator>().SetTrigger("State");
            GameObject ballColone = Instantiate(CameraShakeManager.instance.GetBall(), transform.position, transform.rotation);
            ballColone.GetComponent<Ball>().SetDestination(CameraShakeManager.instance.GetPlayer());

            Destroy(ballColone,  4f);


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

    public void TakeDamage(float damage)
    {
        maxHp -= damage;
        if (maxHp <= 0)
        {
            Destroy(gameObject);

        }



    }
}
