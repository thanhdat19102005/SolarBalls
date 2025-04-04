using UnityEngine;

public class GhostBullet : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed = 5f;
    public float danageEnter = 10f;
      
    void Start() {
        
    }

   
    void Update() {
        if    (player  !=    null)    {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
            
        }   


    }

    public       void     SetPlayer   ( GameObject    player) {
        this   .player    = player;           
    }
    private void OnTriggerEnter2D(Collider2D collision) {
           if   (   collision  .gameObject  .CompareTag    ("player")) {
            collision.gameObject.GetComponent<Player>().TakeDamage(danageEnter);


             }
    }
}
