
using UnityEngine;

public class StaffBullet : MonoBehaviour
{

    public WeaponHpData     dataHp;
       
    public float moveSpeed = 15f;
   
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
        
    }
    private void OnCollisionEnter2D(Collision2D collision)  {
        if (collision.gameObject.CompareTag("bug")) {
           GameObject bugColone = collision.gameObject;
           bugColone.GetComponent<BugKt>().TakeDamage(dataHp.damage);
        
        }
        if  (collision  .gameObject    .CompareTag   ("Ghost") ) {
            GameObject  ghostColone = collision.gameObject;
            ghostColone.GetComponent<Ghost>().TakeDamage(dataHp.damage);
        }

        if (collision.gameObject.CompareTag("Clown"))
        {
            GameObject clonwColone = collision.gameObject;
            clonwColone.GetComponent<Clown>().TakeDamage(dataHp.damage);
        }
    }  

}
