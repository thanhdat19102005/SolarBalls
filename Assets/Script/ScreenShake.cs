
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraShakeManager : MonoBehaviour
{
    public static CameraShakeManager instance;
    public GameObject coin;
    public GameObject health;
    public GameObject ball;
    public GameObject player;
    public GameObject brokenBall;





    [SerializeField] private float globalShakeForce = 2f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void CameraShake(CinemachineImpulseSource impulseSource)
    {
        impulseSource.GenerateImpulseWithForce(globalShakeForce);
    }

    //   get  GameObject coin   
    public   GameObject    GetCoin  ()
    {
        return this.coin;

    }
     //     get   GameObject    health  
       public    GameObject   GetHealth   ()
    {
            return  this.health;

    }

    public GameObject GetBall()
    {
        return this.ball;

    }
    public GameObject GetPlayer()
    {
        return this. player ;

    }
    public GameObject GetBrokenBall()
    {
        return this.brokenBall;

    }
}