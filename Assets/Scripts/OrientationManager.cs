using UnityEngine;

public class OrientationManager : MonoBehaviour
{
    private bool isPortrait = true; // Variable para controlar la orientación actual.

    public GameObject landscapeUI;
    public GameObject portraitUI;

    void Start()
    {
        CheckOrientation();
    }

    void Update()
    {
        // Verificar si la orientación ha cambiado.
        if (Screen.width > Screen.height && !isPortrait)
        {
            // Cambio a modo Landscape.
            isPortrait = false;
            SetLandscapeLayout();
        }
        else if (Screen.width < Screen.height && isPortrait)
        {
            // Cambio a modo Portrait.
            isPortrait = true;
            SetPortraitLayout();
        }
    }

    private void SetLandscapeLayout()
    {
        if (landscapeUI != null)
        {
            landscapeUI.SetActive(true);
        }

        if (portraitUI != null)
        {
            portraitUI.SetActive(false);
        }
    }

    private void SetPortraitLayout()
    {
        if (landscapeUI != null)
        {
            landscapeUI.SetActive(false);
        }

        if (portraitUI != null)
        {
            portraitUI.SetActive(true);
        }
    }

    private void CheckOrientation()
    {
        // Verificar la orientación al inicio del juego.
        if (Screen.width > Screen.height)
        {
            isPortrait = false;
            SetLandscapeLayout();
        }
        else
        {
            isPortrait = true;
            SetPortraitLayout();
        }
    }
}
