using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReceiveDamages : MonoBehaviour
{
    public GameObject lifeBar;

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("CharacterWeapons") && col.gameObject.layer == gameObject.layer)
        {
            EnemyBehaviour enemyBehaviour = gameObject.GetComponent<EnemyBehaviour>();
            if(enemyBehaviour.GetHPratio() >0 ) enemyBehaviour.Damage(1);
            
            lifeBar.transform.localScale = new Vector3(enemyBehaviour.GetHPratio(), lifeBar.transform.localScale.y, lifeBar.transform.localScale.z);

            Destroy(col.gameObject);
        }
    }

}
