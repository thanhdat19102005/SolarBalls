using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class thuthu : MonoBehaviour{
    public GameObject Player;
    public GameObject tH;
    public GameObject cimemachine;
    public GameObject mainCamera;
    public GameObject canvas;
    //      lay  image    fade   transition  
    private void Awake(){
     
      
    }

      public     void Update() {
        if (Input.GetKeyDown(KeyCode.K))  {
            ChangeScene("Scene2");
        }
        else if (Input.GetKeyDown(KeyCode.L)){
      
            ChangeScene("Scene1");
        }
    } 

    public void ChangeScene(string sceneName) {

        if (Player != null)
        {
            if (Player.transform.parent != null)
            {
                Player.transform.SetParent(null);
            }
            DontDestroyOnLoad(Player);
        }
        if (tH != null)
        {
            if (tH.transform.parent != null)
            {
                tH.transform.SetParent(null);
            }
            DontDestroyOnLoad(tH);
        }
        if (cimemachine != null)
        {
            if (cimemachine.transform.parent != null)
            {
                cimemachine.transform.SetParent(null);
            }
            DontDestroyOnLoad(cimemachine);
        }

        if (mainCamera != null)
        {
            if (mainCamera.transform.parent != null)
            {
                mainCamera.transform.SetParent(null);
            }
            DontDestroyOnLoad(mainCamera);
        }
        if (gameObject != null)
        {
            if (gameObject.transform.parent != null)
            {
                gameObject.transform.SetParent(null);
            }
            DontDestroyOnLoad(gameObject);
        }
        if (canvas != null)
        {
            if (canvas.transform.parent != null)
            {
                canvas.transform.SetParent(null);
            }
            DontDestroyOnLoad(canvas);
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(sceneName);
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        if (scene.name.Equals("Scene2"))  {
            if (Player != null)
                SceneManager.MoveGameObjectToScene(Player, scene);

            if (tH != null)
                SceneManager.MoveGameObjectToScene(tH, scene);

            if (cimemachine != null)
                SceneManager.MoveGameObjectToScene(cimemachine, scene);


            if (mainCamera != null)
                SceneManager.MoveGameObjectToScene(mainCamera, scene);

            if (gameObject != null)
                SceneManager.MoveGameObjectToScene(gameObject, scene);


            if (canvas != null)
                SceneManager.MoveGameObjectToScene(canvas, scene);
        }

        if (scene.name.Equals("Scene1"))
        {
            if (Player != null)
                SceneManager.MoveGameObjectToScene(Player, scene);

            if (tH != null)
                SceneManager.MoveGameObjectToScene(tH, scene);

            if (cimemachine != null)
                SceneManager.MoveGameObjectToScene(cimemachine, scene);

            if (mainCamera != null)
                SceneManager.MoveGameObjectToScene(mainCamera, scene);

           
            if (gameObject != null)
            SceneManager.MoveGameObjectToScene(gameObject, scene );

            if (canvas != null)
                SceneManager.MoveGameObjectToScene(canvas, scene);


            GameObject []  maincamera = GameObject.FindGameObjectsWithTag("MainCamera");
            GameObject []  trothuu= GameObject.FindGameObjectsWithTag("troThu");
            GameObject[] cinemachinee = GameObject.FindGameObjectsWithTag("cimema"); ;
            GameObject  []player = GameObject.FindGameObjectsWithTag("player");
            GameObject[] objects = GameObject.FindGameObjectsWithTag("nextScene");
            maincamera[0].SetActive(false);
            trothuu[0].SetActive(false);
            cinemachinee[0].SetActive(false);
            player[0].SetActive(false);
            objects[0].SetActive(false);


            if (player[1] != null) player[1].transform.position = new Vector3(17f, 0.35f, Player.transform.position.z);
            if (trothuu[1] != null) trothuu[1].transform.position = new Vector3(17f, 1f, tH.transform.position.z);


        }
   
        if (scene.name.Equals("Scene2"))
        {
            if (Player != null) Player.transform.position = new Vector3(-25.42f, 1.57f, Player.transform.position.z);
            if (tH != null) tH.transform.position = new Vector3(-27.56f, 2f, tH.transform.position.z);
        }
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

   
}


