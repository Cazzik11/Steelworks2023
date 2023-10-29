using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressController : MonoBehaviour
{
    public List<GameObject> ProgressObjects;
    public MapGenerator MapGenerator;
    public DialogueManager DialogueManager;
    public int MinDistanceFromPlayer = 0;

    private int progress = 0;
    private Vector2 progressObjectPosition;

    public int Progress => progress;
    public Vector2 ProgressObjectPosition => progressObjectPosition;

    private void OnEnable()
    {
        DialogueManager.OnDialogueEnded += CheckForMilestone;
    }

    private void OnDisable()
    {
        DialogueManager.OnDialogueEnded -= CheckForMilestone;
    }

    private void CheckForMilestone()
    {
        progress++;
        SpawnProgressObject();
    }

    private void SpawnProgressObject()
    {
        List<Vector2> possibleSpawns = new List<Vector2>();

        var player = FindObjectOfType<MovementController>().transform;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                var position = new Vector2((i - 1) * MapGenerator.MapDimensions.x/4, (j - 1) * MapGenerator.MapDimensions.y / 4);

                if (Vector2.Distance(player.position, position) > MinDistanceFromPlayer)
                {
                    possibleSpawns.Add(position);
                }
            }
        }

        var randomIndex = UnityEngine.Random.Range(0, possibleSpawns.Count);
        var xOffset = UnityEngine.Random.Range(-MapGenerator.MapDimensions.x / 8, MapGenerator.MapDimensions.x / 8);
        var yOffset = UnityEngine.Random.Range(-MapGenerator.MapDimensions.y / 8, MapGenerator.MapDimensions.y / 8);

        var po = Instantiate(ProgressObjects[progress-1]);
        progressObjectPosition = possibleSpawns[randomIndex] + xOffset * Vector2.right + yOffset * Vector2.up;
        po.transform.position = progressObjectPosition;
    }
}
