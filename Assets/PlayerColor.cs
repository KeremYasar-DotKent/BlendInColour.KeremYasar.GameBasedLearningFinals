using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    public RedTone myCurrentTone = RedTone.None;
    private Renderer myRenderer;

    private bool canPickColor = false;
    private RedTone pendingTone;
    private Color pendingVisualColor;

    void Awake()
    {
        myRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        if (canPickColor && Input.GetKeyDown(KeyCode.E))
        {
            ApplyNewColor(pendingTone, pendingVisualColor);
        }
    }

    public void ApplyNewColor(RedTone newTone, Color visualColor)
    {
        myCurrentTone = newTone;
        if (myRenderer != null) myRenderer.material.color = visualColor;

        // --- SÝHÝRLÝ KISIM BURASI ---
        // Sahnedeki tüm ColorPassBlock scriptine sahip objeleri bul
        ColorPassBlock[] allDoors = FindObjectsByType<ColorPassBlock>(FindObjectsSortMode.None);

        foreach (ColorPassBlock door in allDoors)
        {
            // Her kapýya "Ben bu rengi aldým, açýlýyor musun?" diye sor
            door.CheckAndOpen(myCurrentTone);
        }
    }

    public void SetPendingColor(RedTone tone, Color color)
    {
        canPickColor = true;
        pendingTone = tone;
        pendingVisualColor = color;
    }

    public void ResetPendingColor()
    {
        canPickColor = false;
    }
}