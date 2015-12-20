using UnityEngine;
using System.Collections;

public class PropertyQuadTree
{
    static readonly int MAX_HEIGHT = 5;
    PropertyQuadTree[] nodes;

    public PropertyQuadTree(int height, Vector3 position, float size)
    {
        nodes = new PropertyQuadTree[4];
        if (height < MAX_HEIGHT)
        {
            for (int i = 0; i < 4; i++)
            {
                nodes[i] = new PropertyQuadTree(
                    height++,
                    new Vector3(),
                    size / 2
                );
            }
        }
    }
}
