using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
   private bool muted = false;
   [SerializeField]
   private AudioSource _audioSource;
   
   [SerializeField]
   private AudioClip _clip;
   private void Start()
   {
      if (!PlayerPrefs.HasKey("muted"))
      {
         PlayerPrefs.SetInt("muted", 0);
         Load();
      }
      else
      {
         Load();
      }
      _audioSource.mute = muted;
      
      
   }


   public void OnButtonPress()
   {
      if (muted == false)
      {
         muted = true;
         _audioSource.mute = true;
      }
      else
      {
         muted = false;
         _audioSource.mute = false;
      }
      Save();
   }

   private void Load()
   {
      muted = PlayerPrefs.GetInt("muted") == 1;
   }

   private void Save()
   {
      PlayerPrefs.SetInt("muted", muted ? 1 : 0);
   }

   public void ButtonPressSound()
   {
      _audioSource.PlayOneShot(_clip);
     
   }
}
