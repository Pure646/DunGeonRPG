using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGenerator : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject BamsongiPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bamsongi = Instantiate(BamsongiPrefab);
            bamsongi.transform.position =
                _camera.transform.position + _camera.transform.forward * 1.0f;
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            Vector3 worldDir = ray.direction;
            bamsongi.GetComponent<BamsongiController>().Shoot(worldDir.normalized * 5000);
        }
        if (Input.GetKeyDown(KeyCode.Z)) 
        {

        }
        if (Input.GetKeyDown(KeyCode.X)) 
        {

        }
        if (Input.GetKeyDown(KeyCode.C)) 
        {

        }
    }
}
