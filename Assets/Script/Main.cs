/*
Speed Unity3D-2D - 2019 - Fabrizio Radica

 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    public GameObject tileObj;
    public float blocSize;
    GameObject[] tilesArray = new GameObject[1024];
    int i = 0;

    //Mappa del livello.
    //Array multimensionale: [livello, x, y]
    int[,,] tileMap ={
        //Livello 1
        {
            {0,1,1,1,1,1,1,1,1,0},
            {1,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,1,1,0,1},
            {1,0,0,1,0,0,0,0,1,0},
            {1,0,0,0,1,1,0,1,1,0},
            {1,1,0,0,1,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,1},
            {0,1,1,1,1,1,1,1,1,0},
        },
        //Livello 2
        {
            {0,1,1,1,1,1,1,1,1,0},
            {1,0,0,1,0,0,0,0,0,1},
            {1,0,0,1,0,0,0,1,0,1},
            {1,0,1,1,0,1,1,1,0,1},
            {1,0,1,0,0,0,0,0,0,1},
            {1,0,0,0,1,1,1,0,0,1},
            {1,0,0,0,1,0,1,1,0,1},
            {0,1,1,1,1,0,1,1,1,0},
        }
    };

    // Start is called before the first frame update
    void Start()
    {
        //renderizzo il mio livello
        // se metto 1, renderizzo il secondo array della mappa.
        renderTiledMap(0);
    }

    void tile(int id, float x, float y)
    {
        //instanzio il mio oggetto caricandolo da file
        tilesArray[i] = Instantiate(tileObj);

        //Creo l'oggetto dentro al padre (non è necessario ma mantiene un certo ordine nella gerarchia.
        tilesArray[i].transform.parent = transform;

        //centro l'area del livello
        float centerx = (transform.position.x - tileMap.GetLength(2)) * 0.5f;
        float centery = (transform.position.y - tileMap.GetLength(1)+1) * 0.5f;

        //posiziono il tile
        tilesArray[i].transform.position = new Vector2(centerx + x, centery-y);

    }

    public void renderTiledMap(int level)
    {
        for (int y = 0; y < tileMap.GetLength(1); y++)
        {
            for (int x = 0; x < tileMap.GetLength(2); x++)
            {
                int ttile = tileMap[level, y, x];

                //controllo se nell'array della mappa ci sono tiles
                // se trovo 0, allora non disegno nulla (spazio vuoto)
                if (ttile > 0)
                {
                    tile(i, x * blocSize, -y * blocSize);
                }
                i++;
            }
        }
    }
}
