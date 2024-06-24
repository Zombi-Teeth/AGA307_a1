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
        SetUp();
    }

    void SetUp()
    {
        if (enemyType == EnemyType.OneHanded)
            health = 100;
        else if (enemyType == EnemyType.TwoHanded)
            health = 200;
        else if (enemyType == EnemyType.Archer)
            health = 50;
    }

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
        //Rotate our boject 180 ndegrees so that its facing the other way
        transform.Rotate(Vector3.up * 180);   
        //Wait 3 seconds
        yield return new WaitForSeconds(3);
        //Call the coroutine again
        StartCoroutine(Move());
    }

}
