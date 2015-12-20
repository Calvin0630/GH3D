using UnityEngine;
using System.Collections;

public class PropertyQuadTree
{
    static readonly int MAX_HEIGHT = 4;
    PropertyQuadTree[] nodes;

    public PropertyQuadTree(int height, Vector3 position, float size)
    {
        nodes = new PropertyQuadTree[4];
        if (height < MAX_HEIGHT && isPopulationAboveAverage())
        {
            for (int i = 0; i < 4; i++)
            {
                nodes[i] = new PropertyQuadTree(
                    height + 1,
                    new Vector3(),
                    size / 2
                );
            }
        }
    }

    bool isPopulationAboveAverage() {
        // calculate population density for and return true for subdivisions that are about threshold || average
        return true;
    }
}
