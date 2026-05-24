using UnityEngine;

public class ColorPickerBlock : MonoBehaviour
{
    public RedTone myTone; // Inspector'dan tonu seç (Light, Dark vb.)

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerColor pColor = other.GetComponent<PlayerColor>();
            if (pColor != null)
            {
                pColor.SetPendingColor(myTone, GetComponent<Renderer>().material.color);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerColor pColor = other.GetComponent<PlayerColor>();
            if (pColor != null) pColor.ResetPendingColor();
        }
    }
}