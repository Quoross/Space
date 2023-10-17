using UnityEngine;
using Random = UnityEngine.Random;//had to specify that it was unity engine random and not just random, I do not know why

public class TerrainGen : MonoBehaviour
{
    public int width = 256; //anything above 300 starts tanking performance for me
    public int height = 256;

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
        var terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);
    }

    private TerrainData GenerateTerrain(TerrainData terrainData)
    {
        terrainData.heightmapResolution = width + 1;
        terrainData.size = new Vector3(width, depth, height);

        terrainData.SetHeights(0, 0, GenerateHeights());
        return terrainData;
    }

    private float[,] GenerateHeights()
    {
        var heights = new float[width, height];
        for (var x = 0; x < width; x++)
        for (var y = 0; y < height; y++)
            heights[x, y] = CalcHeight(x, y);

        return heights;
    }

    private float CalcHeight(int x, int y)
    {
        var xCoord = (float)x / width * scale + offX;
        var yCoord = (float)y / height * scale + offY;

        return Mathf.PerlinNoise(xCoord, yCoord); //returns a gradient noise after randomising it
    }
}