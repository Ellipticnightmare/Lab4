using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManagerScript : MonoBehaviour
{

  public static AudioClip playerShoot, playerMove;
  public static AudioSource plyShoot;
  public static AudioSource plyMove;


    void Start()
    {
      plyShoot = gameObject.AddComponent<AudioSource>();
      plyMove = gameObject.AddComponent<AudioSource>();


      //playerShoot = Resources.Load<AudioClip> ("playerShoot");

      //audioSrc = GetComponent <AudioSource> ();
    }

    public static void PlaySound (string clip)
    {
      switch (clip)
      {
        case "playerShoot":
          plyShoot.PlayOneShot (playerShoot);
          break;

        case "playerMove":
        plyMove.PlayOneShot (playerMove);
        break;
      }
    }
}
