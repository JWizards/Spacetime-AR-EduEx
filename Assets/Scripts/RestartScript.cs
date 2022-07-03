using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour
{
   public void ReloadARScene()
   {
       Gravity.DestroyList();
       Gravity.Bodies = new List<Gravity>();
       SceneManager.LoadSceneAsync("AR Scene",LoadSceneMode.Single);
   }
}
