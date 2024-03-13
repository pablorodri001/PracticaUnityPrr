using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject menuPrincipal;
    public GameObject menuGameOver;
    public GameObject column;
    public GameObject piedra1;
    public GameObject piedra2;
    public Renderer fondo;
    public float velocidadInicial = 2; // Velocidad inicial de las columnas y las piedras
    public float aceleracion = 0.1f; // Aceleración del juego
    private float velocidad; // Velocidad actual de las columnas y las piedras
    public bool gameOver = false;
    public List<GameObject> cols;
    public bool start = false;
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

        velocidad = velocidadInicial; // Inicializar la velocidad
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Salir del juego
            //UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }

        if (start == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                start = true;
            }
        }

        if (start == true && gameOver == true)
        {
            menuGameOver.SetActive(true);
            if (Input.GetKeyDown(KeyCode.X))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (start == true && gameOver == false)
        {
            menuPrincipal.SetActive(false);
            fondo.material.mainTextureOffset += new Vector2(0.03f, 0) * Time.deltaTime;

            // Actualizar velocidad con aceleración
            velocidad += aceleracion * Time.deltaTime;

            // Mover columnas
            for (int i = 0; i < cols.Count; i++)
            {
                if (cols[i].transform.position.x <= -10)
                {
                    cols[i].transform.position = new Vector3(10, -3, 0);
                }

                cols[i].transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
            }

            // Mover Piedras
            for (int i = 0; i < obs.Count; i++)
            {
                if (obs[i].transform.position.x <= -10)
                {
                    float randomObs = Random.Range(11, 18);

                    // Verificar que la nueva posición no esté demasiado cerca de la posición de las otras piedras
                    foreach (var otherObs in obs)
                    {
                        if (Mathf.Abs(otherObs.transform.position.x - randomObs) < 2)
                        {
                            randomObs += 2; // Aumentar la posición para que haya suficiente espacio
                        }
                    }

                    obs[i].transform.position = new Vector3(randomObs, -2, 0);
                }

                obs[i].transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
            }
        }
    }
}