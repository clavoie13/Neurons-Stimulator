﻿using UnityEngine;
using System.Collections;

public class CancerScript : MonoBehaviour {

    public int indexLigne;
    public int indexCol;
    public Grid grid;
    public GameObject mortGameObject;

    public int VieMax;
    public int VieActuelle;
    public int ressourceValue;
    private bool BarDeVieEstVisible = false;

    public GameObject bareDeVie;

    private Coroutine currentCoroutine = null;
    private GameObject MabareDeVie;

    // Use this for initialization
    void Start () {
        VieActuelle = VieMax;
	}
	
	// Update is called once per frame
	void Update () {
	
        if(VieActuelle == VieMax - 1)
        {
            if(BarDeVieEstVisible == false)
            {

                MabareDeVie = Instantiate(bareDeVie, new Vector2(transform.position.x - 0.3f, transform.position.y + 0.4f), Quaternion.identity) as GameObject;
                MabareDeVie.transform.parent = gameObject.transform;
                MabareDeVie.GetComponent<barreDeVieScript>().maxVie = VieMax;
                BarDeVieEstVisible = true;
            }
        }

        if(VieActuelle < 1)
        {
            DestroyLeBloc();
            grid.GetComponent<Pathfinder>().UpdateShortestPaths();
        }
	}

    public void DestroyLeBloc()
    {
        grid.GetComponent<CellGrid>().RemoveElement(new Position(indexLigne, indexCol));
        grid.SetElement(Grid.EMPTY, new Position(indexLigne, indexCol));
        Instantiate(mortGameObject, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void Hurt()
    {
        VieActuelle--;

        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);
        currentCoroutine = StartCoroutine(WaitForHurt());
    }

    IEnumerator WaitForHurt()
    {
        yield return new WaitForSeconds(1);
        Destroy(MabareDeVie);
        VieActuelle = VieMax;
        BarDeVieEstVisible = false;
    }


}
