using TMPro;
using UnityEngine;

/**
 * Works with both TextMeshPro (3D/world) and TextMeshProUGUI (UI).
 */
[RequireComponent(typeof(TMP_Text))]
public class NumberField : MonoBehaviour
{
    private int number;
    private TMP_Text textComponent;

    private void Awake()
    {
        textComponent = GetComponent<TMP_Text>();
    }

    public void SetNumber(int newValue)
    {
        number = newValue;
        textComponent.text = number.ToString();
    }

    public void AddNumber(int toAdd)
    {
        SetNumber(number + toAdd);
    }

    public int GetNumber()
    {
        return number;
    }
}
