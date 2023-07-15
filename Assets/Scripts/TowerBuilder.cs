using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    public GameObject[] gameObjects;
    public int rows = 5;
    public int columns = 5;
    public float spacing = 1.0f;

    private void Start()
    {
        // Genişliklere göre GameObject listesini sırala
        System.Array.Sort(gameObjects, CompareByWidth);

        // Kuleyi oluştur
        Vector3 position = transform.position;

        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                int objIndex = (row * columns + column) % gameObjects.Length;
                GameObject obj = gameObjects[objIndex];

                float x = position.x + (obj.transform.localScale.x + spacing) * column;
                float y = position.y + (obj.transform.localScale.y + spacing) * row;
                Vector3 towerObjectPosition = new Vector3(x, y, position.z);

                GameObject towerObject = Instantiate(obj, towerObjectPosition, Quaternion.identity);
                towerObject.transform.parent = transform;
            }
        }
    }

    private int CompareByWidth(GameObject obj1, GameObject obj2)
    {
        float width1 = obj1.transform.localScale.x;
        float width2 = obj2.transform.localScale.x;
        return width1.CompareTo(width2);
    }
}