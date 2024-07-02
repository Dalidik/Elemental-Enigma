using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
   public Slider Slider;
  
   private Boolean _stopTimer;
   [SerializeField]
   private GameObject _looseScreen;
   [SerializeField]
   private Single _reminingTime;
   public GameObject GameScreen;
   private Boolean _isOver;
   private void Start()
   {
      Time.timeScale = 0;
      _looseScreen.SetActive(false);
      Slider.maxValue = _reminingTime;
      Slider.value = _reminingTime;
   }

   void Update()
   {
      
      if (_reminingTime > 0)
      {
         _reminingTime -= Time.deltaTime;
         Slider.value = _reminingTime;
      }
      else if (_reminingTime <= 0 && !_isOver)
      {
         _isOver = true;
         _reminingTime = 0;
         OpenLooseScreen();
            
      }

      int minutes = Mathf.FloorToInt(_reminingTime / 60);
      int seconds = Mathf.FloorToInt(_reminingTime % 60);
     
   }

   public void StartTimer()
   {
      if (GameScreen.activeInHierarchy)
      {
         Time.timeScale = 1;
      }
   }
   

   public void StopTimer()
   {
      Time.timeScale = 0;
   }

   public void ReloadTimer()
   {
      Time.timeScale = 0;
      _reminingTime = 210;
   }

   
   private void OpenLooseScreen()
   {
       
      _looseScreen.SetActive(true);
   }

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
  /* private Boolean _stopTimer;
   [SerializeField]
   private GameObject _looseScreen;

   private void Awake()
   {
      _looseScreen.SetActive(false);
   }

   private void Start()
   {
      Time.timeScale = 0;
      _stopTimer = false;
      Slider.maxValue = _Time;
      Slider.value = _Time;
   }

   private void Update()
   {
      Single time = _Time - Time.time;

      Int32 minutes = Mathf.FloorToInt(time / 60);
      Int32 seconds = Mathf.FloorToInt(time - minutes * 60f);

      if (time <= 0)
      {
         _stopTimer = true;
         _looseScreen.SetActive(true);
      }

      if (_stopTimer == false)
      {
         Slider.value = time;
      }
   }

   public void StartTimer()
   {
      Time.timeScale = 1;
   }*/
}
