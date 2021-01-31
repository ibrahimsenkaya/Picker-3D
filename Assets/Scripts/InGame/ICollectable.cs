using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableAbstract : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Checkpoint")
        {
            GetComponent<Collider>().isTrigger = true;
        }
    }
}
