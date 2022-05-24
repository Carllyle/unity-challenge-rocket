using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        //definir uma distancia entre a camera e o foguete
        offset = new Vector3(0f, 3f, -10f);
    }

    // Update is called once per frame
    void Update()
    {
        //mudar camera pra acompanhar o foguete
        transform.position = target.position + offset;
        //Debug.Log(target.position + offset);
    }
}
