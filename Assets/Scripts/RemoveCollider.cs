using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCollider : MonoBehaviour
{
    public BoxCollider2D BoxCollider;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BoxCollider.enabled = false; 
    }
}
