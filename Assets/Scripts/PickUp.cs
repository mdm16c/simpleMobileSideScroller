using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    PointCounter pc;

    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.Find("Canvas").GetComponent<PointCounter>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") 
        {
            pc.incrementScore();
            Destroy(gameObject);
        }
    }
}
