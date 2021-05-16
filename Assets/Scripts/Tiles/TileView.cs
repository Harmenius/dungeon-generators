using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;


public enum TileType
{
    GRASS_0,
    GRASS_1,
    GRASS_2,
    GRASS_3,
    GRASS_4,
    WALL_H,
    WALL_V,
    EMPTY,
    WALL_WS,
    WALL_ES,
    WALL_EN,
    WALL_WN
};

public class TileView : MonoBehaviour
{
    [SerializeField] Tilemap level;
    [SerializeField] Tile[] palette;
    [SerializeField] Vector2Int topLeft;

    RectInt bounds;
    TileModel model;

    void Start()
    {
        model = GetComponent<TileModel>();
        bounds = new RectInt(topLeft, model.shape);
        InitializePalette();
    }

    private void InitializePalette()
    {
        Sprite[] paletteSprites = Resources.LoadAll<Sprite>("Tiles/FungiFarmer");
        palette = new Tile[paletteSprites.Length];
        for (int i = 0; i < paletteSprites.Length; i++)
        {
            palette[i] = ScriptableObject.CreateInstance<Tile>();
            palette[i].sprite = paletteSprites[i];
        }
    }

    public void FullRedraw()
    {
        BoundsInt bounds = new BoundsInt(this.bounds.x, this.bounds.y, 0, this.bounds.width, this.bounds.height, 1);
        int[] tileInts = model.Traverse().Select(tile => (int)tile).ToArray();
        TileBase[] tiles = model.Traverse().Select(tile => palette[(int)tile]).ToArray();
        level.SetTilesBlock(bounds, tiles);
    }
}
