using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public GameObject chara;
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0, 0, Random.Range(0, 180));
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0, 0, Time.deltaTime*2);
        transform.position = chara.transform.position + new Vector3(0, 0, -10); ;
    }
}
