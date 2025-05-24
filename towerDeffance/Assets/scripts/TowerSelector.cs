using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TowerSelector : MonoBehaviour
{
    public GameObject[] towerPrefabs; // ������� ���� �����
    public GameObject[] ghostTowerPrefabes;//������� �������� �����
    private GameObject selectedTower; // ��������� �����
    private GameObject selectedGhostTower;//��������� �������� �����

    [SerializeField] private GameController _gameController;
    public void SelectTower(int towerIndex)
    {
        if (_gameController.GetMoney() >= 10)
        {
            selectedTower = towerPrefabs[towerIndex];
            selectedGhostTower = ghostTowerPrefabes[towerIndex];
            _gameController.TakeMoney(-10);
        }
    }

    public GameObject GetSelectedTower()
    {
        return selectedTower;
    }

    public void SetNullTower()
    {
        selectedTower = null;
        selectedGhostTower = null;
    }

    public GameObject GetSelectedGhostTower()
    {
        return selectedGhostTower;
    }
}
