using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonSceneManager : MonoBehaviour
{
    public string gameplaySceneName = "Gameplay"; // El nombre de la escena de gameplay.

    private Button button; // Referencia al componente de bot�n.

    private void Start()
    {
        button = GetComponent<Button>(); // Obt�n la referencia al componente de bot�n.
        button.onClick.AddListener(LoadGameplayScene); // Agrega un listener para manejar el clic en el bot�n.
    }

    private void LoadGameplayScene()
    {
        SceneGlobalManager.Instance.LoadSceneAsync(gameplaySceneName, LoadSceneMode.Single); // Carga la escena de gameplay.
    }
}
