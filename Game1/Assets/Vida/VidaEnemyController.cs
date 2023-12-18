using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemyController : MonoBehaviour
{
    GameObject Enemy;

    // Start is called before the first frame update
    void Start()
    {
        Enemy = FindObjectOfType<EnemyController>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Enemy != null)
            transform.position = new Vector3(Enemy.transform.position.x, transform.position.y, transform.position.z);
    }


}
