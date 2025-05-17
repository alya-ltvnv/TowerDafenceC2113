using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelector : MonoBehaviour
{
    public GameObject[] towerPrefabs; // Префабы всех башен
    private GameObject selectedTower; // Выбранная башня

    public void SelectTower(int towerIndex)
    {
        selectedTower = towerPrefabs[towerIndex];
    }

    public GameObject GetSelectedTower()
    {
        return selectedTower;
    }
}
