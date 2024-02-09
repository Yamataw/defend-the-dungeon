using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttacks : MonoBehaviour
{
    private Animator _animator;
    public CharacterBehaviour CharacterBehaviour;
    public GameObject allyHealthBar;


    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemies"))
        {
            EnemyBehaviour enemyBehaviour = col.gameObject.GetComponent<EnemyBehaviour>();
            _animator = col.gameObject.GetComponent<Animator>();
            _animator.SetTrigger("isAttacking");
            if (!enemyBehaviour.hasDealDamages) {
                CharacterBehaviour.Damages(enemyBehaviour.Enemy.Damages);
                allyHealthBar.transform.localScale = new Vector3(CharacterBehaviour.GetHPratio(), allyHealthBar.transform.localScale.y, allyHealthBar.transform.localScale.z);
                enemyBehaviour.hasDealDamages = true;
            }
            StartCoroutine(DestroyAfterAnimation(col.gameObject));
        }
    }

    IEnumerator DestroyAfterAnimation(GameObject enemy)
    {
        yield return new WaitForSeconds(2f);
        Destroy(enemy);
    }
}
