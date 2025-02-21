using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject particlePrefab; // 파티클 시스템 프리팹
    private Animator particleAnimator;

    // Start is called before the first frame update
    void Start()
    {
        GameObject particleInstance = Instantiate(particlePrefab, transform.position, Quaternion.identity);
        particleAnimator = particleInstance.GetComponent<Animator>();
        Adsf();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Adsf()
    {
        particleAnimator.transform.position = transform.position;

        // 애니메이션 재생
        particleAnimator.SetTrigger("Play");
    }
}
