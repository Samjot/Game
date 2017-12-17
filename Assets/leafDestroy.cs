using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leafDestroy : MonoBehaviour {

    // Use this for initialization
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if layer... or tag
        Debug.Log("LEAF DESTROY");
        Destroy(gameObject);
    }
}
