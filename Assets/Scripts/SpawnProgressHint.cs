using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProgressHint : MonoBehaviour
{
    public float MinInterval;
    public float MaxInterval;
    public List<GameObject> HintObjects;
    public ProgressController ProgressController;

    private float _nextHintTime;

    public void SpawnHint()
    {
        var hint = HintObjects[ProgressController.Progress];
        var player = FindObjectOfType<MovementController>();
        var positionDiff = ProgressController.ProgressObjectPosition - new Vector2(player.transform.position.x, player.transform.position.y);

        var div = Mathf.Max(Mathf.Abs(positionDiff.x), Mathf.Abs(positionDiff.y)) / 2f;
        positionDiff /= div;

        
    }
}
