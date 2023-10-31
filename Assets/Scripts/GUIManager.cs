using UnityEngine;

public class GUIManager:MonoBehaviour
{
    public RectTransform landscapeLayout;
    public RectTransform portraitLayout;

    private void Start()
    {
        if (Screen.width > Screen.height)
        {
            SetLandscapeLayout();
        }
        else
        {
            SetPortraitLayout();
        }
    }

    private void Update()
    {
        if (Screen.width > Screen.height)
        {
            SetLandscapeLayout();
        }
        else
        {
            SetPortraitLayout();
        }
    }

    private void SetLandscapeLayout()
    {
        landscapeLayout.gameObject.SetActive(true);
        portraitLayout.gameObject.SetActive(false);
    }

    private void SetPortraitLayout()
    {
        landscapeLayout.gameObject.SetActive(false);
        portraitLayout.gameObject.SetActive(true);
    }
}
