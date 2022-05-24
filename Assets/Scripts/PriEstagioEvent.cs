using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriEstagioEvent : MonoBehaviour
{
    public bool inWindZone = false;
    public GameObject windZone;

    ///metodo para quando entrar na area de vento
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "windArea")
        {
            windZone = coll.gameObject;
            inWindZone = true;
        }
    }
}
