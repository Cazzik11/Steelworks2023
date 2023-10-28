using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public Vector2 MapDimensions;
    public GameObject GrassTile;
    public Vector2 GrassTileSize;
    public List<GameObject> EnviroProps;
    public float TilePopulationChance;

    private Vector2 _generatedDimensions;
    private Vector2 _groundTileCount;

    private void Awake()
    {
        GenerateGround();
        PopulateProps();
    }

    private void GenerateGround()
    {
        CalculateDimensions();

        var bottomLeftAnchor = new Vector2((-(_groundTileCount.x - 1)) / 2 * GrassTileSize.x, (-(_groundTileCount.y - 1) / 2) * GrassTileSize.y);

        for (int i = 0; i < _groundTileCount.x; i++)
        {
            for (int j = 0; j < _groundTileCount.y; j++)
            {
                var position = bottomLeftAnchor + i * GrassTileSize.x * Vector2.right + j * GrassTileSize.y * Vector2.up;
                var instance = Instantiate(GrassTile);
                instance.transform.position = position;
            }
        }

    }

    private void CalculateDimensions()
    {
        var horizontalTiles = Mathf.CeilToInt((MapDimensions.x - GrassTileSize.x / 2) / GrassTileSize.x);
        _generatedDimensions.x = horizontalTiles * GrassTileSize.x;
        _groundTileCount.x = horizontalTiles;

        var verticalTiles = Mathf.CeilToInt((MapDimensions.y - GrassTileSize.y / 2) / GrassTileSize.y);
        _generatedDimensions.y = verticalTiles * GrassTileSize.y;
        _groundTileCount.y = verticalTiles;
    }

    private void PopulateProps()
    {
        var parent = new GameObject("generated props");
        var bottomLeftTile = -_generatedDimensions / 2;

        for (int j = 0; j < _generatedDimensions.y; j++)
        {
            for (int i = (int)_generatedDimensions.x - 1; i >= 0; i--)
            {
                if (Random.value < TilePopulationChance)
                {
                    SpawnRandomEnviroAsset(bottomLeftTile.x + i, bottomLeftTile.y + j, parent.transform);
                }
            }
        }
    }

    private void SpawnRandomEnviroAsset(float x, float y, Transform parent)
    {
        var randomAssetIndex = Random.Range(0, EnviroProps.Count - 1);
        var randomAsset = EnviroProps[randomAssetIndex];
        var xOffset = Random.Range(-0.5f, 0.5f);
        var yOffset = Random.Range(-0.5f, 0.5f);

        var asset = Instantiate(randomAsset);
        asset.transform.position = new Vector3(x + xOffset, y + yOffset, 1 - (y + yOffset)/1000);
        asset.transform.parent = parent;

        /*if (parent.childCount < 1)
        {
            return;
        }

        for (int i = 0; i < parent.childCount; i++)
        {
            if (asset.transform.position.y < parent.GetChild(i).transform.position.y)
            {
                asset.transform.SetSiblingIndex(i);
                break;
            }
        }*/
    }
}
