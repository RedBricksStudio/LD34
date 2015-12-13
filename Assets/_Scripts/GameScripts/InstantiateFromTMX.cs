using UnityEngine;
using System.Collections;

public class InstantiateFromTMX : MonoBehaviour {

    public TextAsset mapa;

    public GameObject wall;
    public GameObject player;
    public GameObject enemy;
    public GameObject pickup;

    public int rows;
    public int columns;

	// Use this for initialization
	void Awake () {
        string[,] tiles = CSVReader.SplitCsvGrid(mapa.text);
        CSVReader.DebugOutputGrid(tiles);

        
        for(int k=0;k < rows;k++) {
            for (int l = 0; l < columns; l++)
            {
                string val = tiles[k,l];
                Debug.Log("value: " + val);
                if (val.Equals("9"))
                {
                    //Debug.Log("Instantiating wall at " + new Vector2(k, l));
                    GameObject.Instantiate(wall, new Vector3(k * 2, 2, l * 2), Quaternion.identity);
                } else if (val.Equals("23")) {
                    GameObject.Instantiate(player, new Vector3(k * 2,2, l * 2), Quaternion.identity);
                } else if (val.Equals("11")) {
                    GameObject.Instantiate(enemy, new Vector3(k * 2, 2, l * 2), Quaternion.identity);
                } else if (val.Equals("30")) {
                    GameObject.Instantiate(pickup, new Vector3(k * 2, 2, l * 2), Quaternion.identity);
                }
            }
        }    
	}
	
	// Update is called once per frame
	void Update () {
	

	}
}
