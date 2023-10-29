using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProgressHint : MonoBehaviour
{
    public float MinInterval;
    public float MaxInterval;
    public List<HintData> HintDatas;
    public ProgressController ProgressController;

    private float _nextHintTime;

    private void Awake()
    {
        _nextHintTime = MinInterval;
    }

    public void SpawnHint()
    {
        Debug.Log("spawn hint");
        var hintData = HintDatas[ProgressController.Progress];
        var player = FindObjectOfType<MovementController>();
        var positionDiff = ProgressController.ProgressObjectPosition - new Vector2(player.transform.position.x, player.transform.position.y);

        if (positionDiff.magnitude < 10f)
        {
            return;
        }

        var div = Mathf.Max(Mathf.Abs(positionDiff.x), Mathf.Abs(positionDiff.y)) / 2f;
        positionDiff /= div;

        if (positionDiff.x > 1.5)
        {
            positionDiff.x = 2;
        }
        else if (positionDiff.x < -1.5)
        {
            positionDiff.x = -2;
        }
        else if (positionDiff.x > 0.5)
        {
            positionDiff.x = 1;
        }
        else if (positionDiff.x < -0.5)
        {
            positionDiff.x = -1;
        }
        else 
        {
            positionDiff.x = 0;
        }

        if (positionDiff.y > 1.5)
        {
            positionDiff.y = 2;
        }
        else if (positionDiff.y < -1.5)
        {
            positionDiff.y = -2;
        }
        else if (positionDiff.y > 0.5)
        {
            positionDiff.y = 1;
        }
        else if (positionDiff.y < -0.5)
        {
            positionDiff.y = -1;
        }
        else
        {
            positionDiff.y = 0;
        }

        if (Mathf.Abs(positionDiff.x) == 2 && Mathf.Abs(positionDiff.y) == 2)
        {
            if (Random.value > 0.5f)
            {
                positionDiff.x /= 2f;
            }
            else
            {
                positionDiff.y /= 2f;
            }
        }

        var randomIndex = Random.Range(0, hintData.Objects.Count);
        var go = Instantiate(hintData.Objects[randomIndex]);
        go.transform.position = player.transform.position + positionDiff.x * Vector3.right + positionDiff.y * Vector3.up;
    }

    private void Update()
    {
        if (ProgressController.Progress < 1)
        {
            return;
        }

        if (_nextHintTime <= 0)
        {
            SpawnHint();
            _nextHintTime = Random.Range(MinInterval, MaxInterval);
        }

        _nextHintTime -= Time.deltaTime;
    }

    [System.Serializable]
    public class HintData
    {
        public List<GameObject> Objects;
    }
}
