using UnityEngine;

[CreateAssetMenu(fileName = "NuevaFruta", menuName = "Fruta")]
public class FrutaSO : ScriptableObject
{
    public string nombre;
    public int points;
    public GameObject fruitPrefab;

}
