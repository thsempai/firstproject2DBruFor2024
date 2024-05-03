using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Platform : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other){
        other.transform.SetParent(transform);
    }

    private void OnTriggerExit2D(Collider2D other){
        other.transform.SetParent(null);
    }
}
