using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileModel : MonoBehaviour
{
    [SerializeField] public Vector2Int shape;
    TileType[,] tiles;

    // Start is called before the first frame update
    void Start()
    {
        tiles = new TileType[shape.x, shape.y];
        for (int x = 0; x < shape.x; x++)
            for (int y = 0; y < shape.y; y++)
                tiles[x, y] = TileType.GRASS_0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Traverse the tiles from left to right then top to bottom
    /// </summary>
    /// <returns></returns>
    internal IEnumerable<TileType> Traverse()
    {
        for (int y = 0; y < shape.y; y++)
            for (int x = 0; x < shape.x; x++)
                yield return tiles[x, y];
    }

}
