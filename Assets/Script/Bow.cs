using Unity.VisualScripting;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public float rotateOffset = 0f;
    private Vector3 originalScale;
    private Transform parentTransform;
    public GameObject bulletBow;
    public GameObject bulletPosition;
   

    void Start()
    {
        originalScale = transform.localScale;
        parentTransform = transform.parent;
      

    }

    void Update()
    {
        // Điều chỉnh lại Scale để không bị ảnh hưởng bởi GameObject cha
        //    cách   chỉnh   gameObject  con   không bị    ảnh   hướng  Scale   từ  gameObject   cha 

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

        Vector3 displacement = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float angle = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + rotateOffset);

        // Lật đối tượng theo trục Y nếu cần
        if (angle < -90 || angle > 90)
        {
            transform.localScale = new Vector3(transform.localScale.x, -Mathf.Abs(transform.localScale.y), transform.localScale.z);
        }
        else {

            transform.localScale = new Vector3(transform.localScale.x, Mathf.Abs(transform.localScale.y), transform.localScale.z);
        }


        if ( Input .GetMouseButtonDown(0) ) {
          GameObject      bulletBowColone    =   Instantiate(bulletBow, bulletPosition.transform.position,     bulletPosition   .transform  .rotation  );
            ManagerAudio.instance.MusicBow();

            Destroy(bulletBowColone, 3f);
              
            



        }



    }







}