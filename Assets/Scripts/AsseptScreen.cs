using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsseptScreen : MonoBehaviour
{
   public GameObject messageContainer;
   private int storedData = 0;
   public string dataStoredName = "DisplayMessageFirstTime";
   [SerializeField]
   private bool deleteStoredDataInEditor = false;
  
   private void Awake()
   {
    storedData = PlayerPrefs.GetInt(dataStoredName, 0);
     messageContainer.SetActive(storedData == 0);
    PlayerPrefs.SetInt(dataStoredName, 1);
    
   }
  
   private void OnValidate()
   {
    if (deleteStoredDataInEditor)
    {
     deleteStoredDataInEditor = false;
     PlayerPrefs.DeleteKey(dataStoredName);
     
    }
   }
}
