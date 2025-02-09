using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chane_Scene_MainMenu : MonoBehaviour
{
    public void ChangeScene1(string TestScene0)
    {
        SceneManager.LoadScene(TestScene0);
    }
}