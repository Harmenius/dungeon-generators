using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSetter : MonoBehaviour
{
    TileMap tileMap;

    void Start()
    {
        tileMap = GetComponent<TileMap>();
    }

}
