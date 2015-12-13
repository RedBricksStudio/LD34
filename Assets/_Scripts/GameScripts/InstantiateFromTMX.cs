using UnityEngine;
using System.Collections;

public class InstantiateFromTMX : MonoBehaviour {

    public TextAsset mapa;

    public GameObject wall;
    public GameObject player;
    public GameObject enemy;
    public GameObject pickup;
    public GameObject waypoint;

    public int rows;
    public int columns;

    public GameObject waypoint1;

	// Use this for initialization
	void Awake () {
        string[,] tiles = CSVReader.SplitCsvGrid(mapa.text);
        CSVReader.DebugOutputGrid(tiles);

        int offset = 1;

        ArrayList enemies = new ArrayList();
        
        for(int k=0;k < rows;k++) {
            for (int l = 0; l < columns; l++)
            {
                string val = tiles[l, k];
                if (val.Equals("WW"))
                {
                    //Debug.Log("Instantiating wall at " + new Vector2(k, l));
                    GameObject newWall = (GameObject)Instantiate(wall, new Vector3(k * offset, 2, l * offset), Quaternion.identity);
                    //newWall.AddComponent<NavMeshObstacle>();
                    //newWall.GetComponent<NavMeshObstacle>().carving = true;
                } else if (val.Equals("PP")) {
                    GameObject.Instantiate(player, new Vector3(k * offset, 2, l * offset), Quaternion.identity);
                } else if (val.Contains("E")) {
                    enemies.Add(new Vector2(k, l));                    
                } else if (val.Equals("CC")) {
                    GameObject.Instantiate(pickup, new Vector3(k * offset, 2, l * offset), Quaternion.identity);
                }
                else if (val.Equals("90"))
                {
                    GameObject.Instantiate(waypoint, new Vector3(k * offset, 2, l * offset), Quaternion.identity);
                }
            }
        }



        foreach (Vector2 position in enemies)
        {            
            GameObject enemyGO = (GameObject)Instantiate(enemy, new Vector3(position.x * offset, 2, position.y * offset), Quaternion.identity);
            enemyGO.GetComponent<EnemyStateMachine>().addWaypoint(waypoint1);
        }
	}
	
	// Update is called once per frame
	void Update () {
	

	}
}
