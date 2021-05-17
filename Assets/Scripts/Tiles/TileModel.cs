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

    internal bool RoomOverlaps(Vector2Int coord, Vector2Int size)
    {
        int buffer = 1;
        for (int y = Mathf.Max(coord.y - buffer, 0); y < coord.y + size.y + buffer; y++)
            for (int x = Mathf.Max(coord.x - buffer, 0); x < coord.x + size.x + buffer; x++)
                if (tiles[x, y] != TileType.GRASS_0)
                    return true;
        return false;
    }

    internal void BuildRoom(Vector2Int coord, Vector2Int size)
    {
        for (int y = coord.y; y < coord.y + size.y; y++)
            for (int x = coord.x; x < coord.x + size.x; x++)
                tiles[x, y] = TileType.GRASS_1;
    }
}
