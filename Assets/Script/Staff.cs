using UnityEngine;

public class Staff : MonoBehaviour
{
    public float rotateOffset = 0f;
    private Vector3 originalScale;
    private Transform parentTransform;

    public GameObject StaffBullet;
     

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalScale = transform.localScale;
        parentTransform = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
             
        if (parentTransform != null)
        {
            Vector3 parentScale = parentTransform.lossyScale;
            transform.localScale = new Vector3(
                 originalScale.x / parentScale.x,
                 originalScale.y / parentScale.y,
                 originalScale.z / parentScale.z
            );
        }
        // Lấy vị trí chuột
        Vector3 mousePos = Input.mousePosition;
        if (mousePos.x < 0 || mousePos.x > Screen.width || mousePos.y < 0 || mousePos.y > Screen.height)
        {
            return; // Chuột ra ngoài màn hình
        }

        Vector3 displacement = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        float angle = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + rotateOffset);

        // Lật đối tượng theo trục Y nếu cần
        if (angle < -90 || angle > 90)
        {
        
            transform.localScale = new Vector3(transform.localScale.x, -Mathf.Abs(transform.localScale.y), transform.localScale.z);
        }
        else
        {

            transform.localScale = new Vector3(transform.localScale.x, Mathf.Abs(transform.localScale.y), transform.localScale.z);
        }
          
        if   (StaffBullet !=   null   )  {
                if (Input.GetMouseButtonDown(0))  {
              GameObject     StaffBulleColone    =    Instantiate(StaffBullet, transform.position, transform.rotation);
                ManagerAudio.instance.MusicStaff();

                Destroy(StaffBulleColone, 3f);





            }  
        }   


    }
}
