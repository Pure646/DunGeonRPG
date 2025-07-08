using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BamsongiController : MonoBehaviour
{
    private int GoldRandom;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;

        Destroy(gameObject, 5.0f);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Monster")
        {
            GetComponent<Rigidbody>().isKinematic = true;
            GoldRandom = Random.Range(50, 200);
            PlayerMovement.GoldPoint += GoldRandom;

            Destroy(gameObject);
        }
    }
    public void Shoot(Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce(dir);
    }
}
