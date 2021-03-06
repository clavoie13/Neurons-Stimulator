﻿using UnityEngine;
using System.Collections;

public class mapInitialiser : MonoBehaviour {

    public Grid grid;
    public GameObject spawner;
    public GameObject mine;
    public GameObject eclair;
    public GameObject cancer;

	// Use this for initialization
	void Start () {
        grid = GetComponent<Grid>();
        initMap();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void initMap()
    {
        for (int i = 0; i < Grid.NUMBER_OF_ROWS; i++)
        {
            for (int j = 0; j < Grid.NUMBER_OF_COLS; j++)
            {
                int element = grid.GetElement(i, j);
                if(element == Grid.SPAWN)
                {
                    Instantiate(spawner, new Vector2(-7 + (j * 0.4f), 3 - (i * 0.4f)), Quaternion.identity);
                }
                else if(element == Grid.MINE)
                {
                    Instantiate(mine, new Vector2(-7 + (j * 0.4f), 3 - (i * 0.4f)), Quaternion.identity);
                }
                else if(element == Grid.DEAD_CELL)
                {
                    GameObject o = (GameObject)Instantiate(cancer, new Vector2(-7 + (j * 0.4f), 3 - (i * 0.4f)), Quaternion.identity);
                    o.GetComponent<CancerScript>().grid = grid;
                    GetComponent<CellGrid>().SetElement(o, new Position(i, j));
                }
            }
        }
    }

    public void addRessourceOnMap(int row, int col)
    {
        //INSTANCIER RESSOURCE
        GameObject myRessource = Instantiate(eclair, new Vector2(-7 + (col * 0.4f), 3 - (row * 0.4f)), Quaternion.identity) as GameObject;
        myRessource.GetComponent<EclairScript>().indexCol = col;
        myRessource.GetComponent<EclairScript>().indexLigne = row;
        myRessource.GetComponent<EclairScript>().grid = grid;        
    }
}
