using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public GameObject[] canvases;    // drag & drop dans l'inspector
    public Button[] nextButtons;     // assigner les boutons (ou remplir automatiquement)
    private int currentIndex = 0;

    void Start()
    {
        ShowCanvas(0);

        // attacher automatiquement NextCanvas aux boutons (sécurité)
        if (nextButtons != null)
        {
            foreach (var btn in nextButtons)
            {
                if (btn != null) btn.onClick.AddListener(NextCanvas);
            }
        }
    }

    public void NextCanvas()
    {
        currentIndex++;
        if (currentIndex < canvases.Length)
            ShowCanvas(currentIndex);
        else
            HideAll();
    }

    void ShowCanvas(int index)
    {
        for (int i = 0; i < canvases.Length; i++)
            canvases[i].SetActive(i == index);
    }

    void HideAll()
    {
        foreach (var c in canvases) if (c) c.SetActive(false);
    }
}
