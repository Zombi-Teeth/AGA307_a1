using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    float moveDistance = 500;
    public EnemyType enemyType;


    private void Start()
    {
       // SetUp();
    }

   /* void SetUp()
    {
        switch (enemyTypes)
        {
            case EnemyTypes.OneHanded:
                health = 100;
                break;

            case EnemyTypes.TwoHanded:
                health = 200;
                break;

            case EnemyTypes.Archer:
                health = 50;
                break;
        }
    }
   */
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Move());
        }
    }

    IEnumerator Move()
    {
        for (int i = 0; i < moveDistance; i++)
        {
            transform.Translate(Vector3.forward * Time.deltaTime);

            yield return null;
        }

        transform.Rotate(Vector3.up * 180);

        yield return new WaitForSeconds(3);

        StartCoroutine(Move());
    }

}
