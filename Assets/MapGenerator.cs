using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    int[,] map;

    public int width;
    public int height;
    public string seed;
    private System.Random pseudoRandom;

    [Range(0,100)]
    public int fillPercentage;
    // Start is called before the first frame update
    void Start()
    {
        GenerateMap();
        
    }

    void GenerateMap(){
        map = new int[width, height];
        seed = (seed.Length <= 0) ? Time.time.ToString() : seed;
        pseudoRandom = new System.Random(seed.GetHashCode());

        for (int x = 0; x < width; x++){
            for (int y = 0; y < height; y++){
                map[x,y] = (pseudoRandom.Next(0,100) > fillPercentage) ? 0 : 1;          // E.g. If you want 30 % of the map to be walls you need to do random > 0.7
            }
        }
    }

    void OnDrawGizmos(){
        if (map != null){
            for (int x = 0; x < width; x++){
                for (int y = 0; y < height; y++){
                    Gizmos.color = (map[x,y] == 1)?Color.black : Color.white;
                    Vector3 pos = new Vector3(-width/2 + x + .5f, 0, -height/2 + y + .5f);
                    Gizmos.DrawCube(pos, Vector3.one);
                }
            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
