using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText; // Referencia al objeto Text que mostrará la puntuación
    private int score = 0; // Puntuación inicial

    void Update()
    {
        // Aumentar la puntuación con el tiempo (puedes cambiar esto según tus necesidades)
        score += 1;

        // Actualizar el texto de la puntuación
        scoreText.text = "Puntuación: " + score.ToString();
    }
}

