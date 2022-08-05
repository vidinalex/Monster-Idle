using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Transform targetPos;
    private Vector3 initialPos;
    private void OnEnable()
    {
        initialPos = transform.position;
        transform.LookAt(targetPos);
        StartCoroutine(FlyTowardsEnemy(GameData.Default.flyTime));
    }

    private IEnumerator FlyTowardsEnemy(float time)
    {        
        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            transform.position = Vector3.Lerp(initialPos, targetPos.position, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = initialPos;
        ActionManager.Default.DeliverArrowDamage();
        gameObject.SetActive(false);
    }
}
