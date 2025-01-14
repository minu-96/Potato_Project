using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chane_Scene : MonoBehaviour
{
    public void ChangeScene(string TestScene2)
    {
        SceneManager.LoadScene(TestScene2);
    }
}
