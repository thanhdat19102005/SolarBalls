using UnityEngine;

public class ManagerAudio : MonoBehaviour
{

    public static ManagerAudio instance;

    public   GameObject  manager  ;
    public AudioClip musicBackGround;
    public AudioClip knife;
    public AudioClip bow;
    public AudioClip staff;
    public AudioClip scene1;
    public    AudioClip scene2; 

    private void Awake()
    {
        if (instance == null) {
            instance = this;
        }
    } 

     public void   MusicBackGround  ()  {
        manager   .  GetComponent  <AudioSource>   ()    .clip = musicBackGround; // Gán nhạc nền
        manager.GetComponent<AudioSource>().loop = true; // Lặp lại nhạc
        manager.GetComponent<AudioSource>().Play(); // Phát nhạc
    }

     public     void   MusicKnife   () {
        manager.GetComponent<AudioSource>().PlayOneShot(knife);
      
 }

    public void MusicBow()
    {
        manager.GetComponent<AudioSource>().PlayOneShot(bow);
     

    }

    public void MusicStaff()
    {
        manager.GetComponent<AudioSource>().PlayOneShot(staff);
       
    }
    public void MusicScene1()
    {
        manager.GetComponent<AudioSource>().clip = scene1; // Gán nhạc nền
        manager.GetComponent<AudioSource>().loop = true; // Lặp lại nhạc
        manager.GetComponent<AudioSource>().Play(); // Phát nhạc
       

    }
    public void MusicScene2()
    {
        manager.GetComponent<AudioSource>().clip = scene2; // Gán nhạc nền
        manager.GetComponent<AudioSource>().loop = true; // Lặp lại nhạc
        manager.GetComponent<AudioSource>().Play(); // Phát nhạc
       
    }

}
