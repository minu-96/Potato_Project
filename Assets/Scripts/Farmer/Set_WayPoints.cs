using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_WayPoints : MonoBehaviour
{
    public Vector2 areaMin; //랜덤 위치 최소값
    public Vector2 areaMax; //랜덤 위치 최대값


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(Random.Range(areaMin.x, areaMax.x), Random.Range(areaMin.y, areaMax.y));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
