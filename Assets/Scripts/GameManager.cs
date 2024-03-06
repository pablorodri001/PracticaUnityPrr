using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour

{
    public GameObject column;
    public GameObject piedra1;
    public GameObject piedra2;
    public Renderer fondo;
    public float velocidad = 2;
    public bool gameOver = false;
    public List<GameObject> cols;

    public List<GameObject> obs;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 21; i++)
        {
            cols.Add(Instantiate(column, new Vector2(-10 + i, -3), Quaternion.identity));

        }

        obs.Add(Instantiate(piedra1, new Vector2(14, -2), Quaternion.identity));
        obs.Add(Instantiate(piedra2, new Vector2(18, -2), Quaternion.identity));




    }

    // Update is called once per frame
    void Update()
    {
        fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.03f, 0) * Time.deltaTime;


        for (int i = 0; i < cols.Count; i++)
        {
            if (cols[i].transform.position.x <= -10)
            {
                cols[i].transform.position = new Vector3(10, -3, 0);
            }

            cols[i].transform.position =
                cols[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;


        }

        //mover Piedras
        for (int i = 0; i < obs.Count; i++)
        {
            if (obs[i].transform.position.x <= -10)
            {
                float randomObs = Random.Range(11, 18);
                obs[i].transform.position = new Vector3(randomObs, -2, 0);
            }

            obs[i].transform.position = obs[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;


        }
    }
}
