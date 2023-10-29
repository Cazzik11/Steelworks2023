using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    public float DestroyTime;

    private void OnEnable()
    {
        Invoke("DestroyGhost", DestroyTime);
    }

    private void DestroyGhost()
    {
        Destroy(this.gameObject);
    }
}
