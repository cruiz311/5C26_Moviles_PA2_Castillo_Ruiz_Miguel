using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonSceneManager : MonoBehaviour
{
    public string gameplaySceneName = "Gameplay"; // El nombre de la escena de gameplay.

    private Button button; // Referencia al componente de botón.

    private void Start()
    {
        button = GetComponent<Button>(); // Obtén la referencia al componente de botón.
        button.onClick.AddListener(LoadGameplayScene); // Agrega un listener para manejar el clic en el botón.
    }

    private void LoadGameplayScene()
    {
        SceneGlobalManager.Instance.LoadSceneAsync(gameplaySceneName, LoadSceneMode.Single); // Carga la escena de gameplay.
    }
}
