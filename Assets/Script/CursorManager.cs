using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class CursorManager : MonoBehaviour
{
    public GameObject player;
    public float speed = 10f;

    public Texture2D normal;
    public Texture2D shoot;
    public Vector3 Destination;

    void Start()
    {
        normal = ResizeTexture(normal, 64, 64);
        Cursor.SetCursor(normal, new Vector2(32, 32), CursorMode.Auto);
         
    }

    void Update() {
         if  (Input .GetMouseButton(0)){
            shoot = ResizeTexture(shoot, 64, 64);
           Cursor.SetCursor(shoot, new Vector2(32, 32), CursorMode.Auto);
           


        }
        else  if (Input.GetMouseButtonUp(0))
        {
            normal = ResizeTexture(normal, 64, 64);
            Cursor.SetCursor(normal, new Vector2(32, 32), CursorMode.Auto);
        }

        //   Vector3   

        Vector3 mousePos = Input.mousePosition;
        if (mousePos.x < 0 || mousePos.x > Screen.width || mousePos.y < 0 || mousePos.y > Screen.height)
        {
        }

    }
    Texture2D ResizeTexture(Texture2D texture, int width, int height)
    {
        RenderTexture rt = new RenderTexture(width, height, 32);
        RenderTexture.active = rt;
        Graphics.Blit(texture, rt);

        Texture2D result = new Texture2D(width, height, TextureFormat.ARGB32, false);
        result.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        result.Apply();

        RenderTexture.active = null;
        rt.Release();

        return result;
    }

}
