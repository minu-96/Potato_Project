using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chane_Scene1 : MonoBehaviour
{
    public void ChangeScene1(string TestScene1)
    {
        SceneManager.LoadScene(TestScene1);
    }
}
