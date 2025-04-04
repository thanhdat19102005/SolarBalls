using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject destination;


    public AnimationCurve curve;  // Kéo thả Curve vào Inspector để điều chỉnh quỹ đạo
    public float duration = 2f;  // Thời gian coin bay(2 giây)
    private Vector3 startPosition;
    private Vector3 endPosition;
    private float elapsedTime = 0f;




    // test  
    public GameObject item;

    void Start()
    {
        startPosition = transform.position; // Bắt đầu từ vị trí ban đầu
        if (item != null)
        {
            endPosition = item.transform.position; // Đặt điểm đến là vị trí của item
           
        }
    }

    void Update()
    {
        if (item == null) return; // Không làm gì nếu không có mục tiêu

        elapsedTime += Time.deltaTime;
        float t = elapsedTime / duration;
        float height = curve.Evaluate(t);
        //   di    chuyển   từ    vị    trí    A  đến   vị tri   B  
        transform.position = Vector3.Lerp(startPosition, endPosition, t) + new Vector3(0, height, 0);
      
        
        if      (t >=  1) {
               GameObject    brokenBall   =   Instantiate(CameraShakeManager .instance    .GetBrokenBall  ()     ,      transform   .position   ,   transform    .rotation  );
               Destroy(brokenBall, 0.3f);
                Destroy(gameObject);
            
            
        }   
          
    }

    public void SetDestination(GameObject player)
    {
        if (player != null)  {
            this.item = player;
            startPosition = transform.position;  // Cập nhật lại vị trí bắt đầu
            endPosition = player.transform.position;  // Cập nhật lại vị trí đích
            elapsedTime = 0;  // Reset thời gian để bắt đầu di chuyển
        }  
    }

    private void OnTriggerEnter2D(Collider2D collision){
            if  (collision    .gameObject    .CompareTag   ("player")) {
            collision.gameObject.GetComponent<Player>().TakeDamage(20f);
             Destroy(gameObject  ,0.2f);
                

          
          
        }  
    }


}
