using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de escenas

public class MainMenu : MonoBehaviour
{
    // Función para iniciar el juego
    public void StartGame()
    {
        // Carga la siguiente escena en la lista de Build Settings
         
    }

    // Función para cerrar el juego
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("El juego se ha cerrado"); // Solo se ve en el editor
    }
}