using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenecontroler : MonoBehaviour
{
 public void gotoscene(int scenenumber)
 {
    SceneManager.LoadScene(scenenumber);
    Debug.Log("hey");
 }
}
