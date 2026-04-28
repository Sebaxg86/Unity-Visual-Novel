using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Arrastramos los paneles desde el Inspector de Unity
    public GameObject panelMenu;
    public GameObject panelCuarto;
    public GameObject panelCafeteria;

    // Se activa al picarle a "Nueva Partida"
    public void IrAHabitacion()
    {
        panelMenu.SetActive(false);      // Apaga el menú
        panelCuarto.SetActive(true); // Prende la habitación
    }

    // Se activa cuando tocas un objeto o terminas de explorar
    public void EmpezarEpisodio()
    {
        // No apagamos la habitación si queremos que se vea de fondo
        panelCafeteria.SetActive(true); 
    }
    
    public void RegresarAlMenu()
    {
        panelCuarto.SetActive(false);
        panelCafeteria.SetActive(false);
        panelMenu.SetActive(true);
    }
}