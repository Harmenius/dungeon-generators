using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    private TileView view;
    private TileModel model;
    [Tooltip("Number of rooms to try to generate.")]
    [SerializeField] int roomCount = 15;
    [Tooltip("Range from which to randomly select a room size.")]
    [SerializeField] RectInt roomSize = new RectInt(3, 3, 25, 25);

    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<TileView>();
        view.FullRedraw();

        model = GetComponent<TileModel>();
        StartCoroutine(GenerationLoop());
    }

    private IEnumerator GenerationLoop()
    {
        int nRooms = 0;
        while(nRooms < roomCount)
        {
            GenerateRoom();
            view.FullRedraw();
            nRooms++;
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void GenerateRoom()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector2Int bounds = model.shape;
            Vector2Int coord = new Vector2Int(UnityEngine.Random.Range(0, bounds.x - roomSize.xMin), UnityEngine.Random.Range(0, bounds.y - roomSize.yMin));
            Vector2Int size = new Vector2Int(UnityEngine.Random.Range(roomSize.xMin, Mathf.Min(roomSize.xMax, bounds.x - coord.x)), UnityEngine.Random.Range(roomSize.yMin, Mathf.Min(roomSize.yMax, bounds.y - coord.y)));

            if(!model.RoomOverlaps(coord, size))
            {
                model.BuildRoom(coord, size);
                return;
            }
        }
    }
}
