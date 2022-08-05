using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private ArrowPooler arrowPooler;

    private void OnEnable()
    {
        inputManager.tapped += SpawnArrow;
    }

    private void OnDisable()
    {
        inputManager.tapped -= SpawnArrow;
    }

    private void SpawnArrow()
    {
        arrowPooler.SpawnArrow();
    }
}
