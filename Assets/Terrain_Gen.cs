using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Random = UnityEngine.Random;//had to specify that it was unity engine random and not just random

public class Terrain_Gen : MonoBehaviour
{
   public int width = 500; 
    public int height = 50; 

    public int depth = 35; 

    public float scale = 20f; //how severe the hills/mountains are

    public float offX = 100f;
    public float offY = 100f;

    private void Start()
    {
         offX = Random.Range(0f, 9999f);
         offY = Random.Range(0f, 9999f);
    }

  private void Update()
    {
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);
       
    }

    TerrainData GenerateTerrain (TerrainData terrainData)
    {
        terrainData.heightmapResolution = width + 1;
        terrainData.size = new Vector3(width, depth, height);

        terrainData.SetHeights(0, 0, GenerateHeights());
        return terrainData;
    }

    float[,] GenerateHeights()
    {
        float[,] heights = new float[width, height];
        for(int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                heights[x, y] = CalcHeight(x, y);
            }
        }

        return heights;
    }

    float CalcHeight (int x, int y)
    {
        float xCoord = (float)x / width * scale + offX;
        float yCoord = (float)y / height * scale + offY;

        return Mathf.PerlinNoise(xCoord, yCoord); //returns a gradient noise after randomising it
    }
}
