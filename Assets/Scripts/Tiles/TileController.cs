using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    private TileView tileView;
    private bool updated = false;

    // Start is called before the first frame update
    void Start()
    {
        tileView = GetComponent<TileView>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!updated)
        {
            updated = true;
            tileView.FullRedraw();
        }
    }
}
