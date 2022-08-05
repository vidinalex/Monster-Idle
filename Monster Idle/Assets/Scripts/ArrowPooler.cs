using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPooler : MonoBehaviour
{
    [SerializeField] private Transform targetPos;
    [SerializeField] private List<Arrow> arrows;

    private int index = 0;

    public void SpawnArrow()
    {
        arrows[index].targetPos = targetPos;
        arrows[index].gameObject.SetActive(true);
        index++;

        if(index == arrows.Count)
            index = 0;
    }
}
