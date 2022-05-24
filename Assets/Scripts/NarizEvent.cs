using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarizEvent : MonoBehaviour
{
    public bool inTerrain = false;
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

    ///metodo para quando encostar no chão
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "terrain")
        {
            inTerrain = true;
        }
    }
}
