using System.Collections;
using System.Security.Cryptography;
using UnityEngine;

public class Coin : MonoBehaviour{
    public GameObject   destination;


    public AnimationCurve curve;  // Kéo thả Curve vào Inspector để điều chỉnh quỹ đạo
    public float duration = 2f;  // Thời gian coin bay(2 giây)
    private Vector3 startPosition;
    private Vector3 endPosition;
    private float elapsedTime = 0f;



    
    void Start()  {
        startPosition = transform.position;
        endPosition = startPosition + new Vector3(3f, 0f, 0f); // Di chuyển theo trục X
    }

    void Update() {

        if (destination == null) // Nếu chưa có item, thì chạy Animation Curve
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;
            float height = curve.Evaluate(t);

            transform.position = Vector3.Lerp(startPosition, endPosition, t) + new Vector3(0, height, 0);
        }
        else // Nếu có item, thì di chuyển về phía item
        {
            transform.position = Vector2.MoveTowards(transform.position, destination.transform.position, 5 * Time.deltaTime);
            if   (  Vector3  .Distance  (  destination .transform  .position    ,    transform  .transform .position )  <=   0.2f)
            {
                Destroy(gameObject, 0.3f);

            }   

        }

    }
    public   void   SetItem  (GameObject destination)
    {
        this.destination = destination;

    }
       
    }
