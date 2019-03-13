using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawDistance : MonoBehaviour
{

    public Terrain m_terrain;  //reference to your terrain
    public float DrawDistanceNum; // how far you want to be able to see the grass

    // Use this for initialization
    void Start()
    {

        m_terrain.detailObjectDistance = DrawDistanceNum;

    }
}
