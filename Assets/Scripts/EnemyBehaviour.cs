using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class EnemyBehaviour : MonoBehaviour

{

    public EnemyData Enemy;
    public float oscillationSpeed = 180f;
    private bool _moveStarted = false;
    public Animator DefaultAnimator;
    public bool hasDealDamages = false;
    public bool hasDeathCounted = false;
    public SpriteRenderer spriteRender;
    private int  _currentHP;


    void Start()
    {
        gameObject.layer = Random.Range(6,10);
        spriteRender.sortingOrder = gameObject.layer - 5;
        _currentHP = Enemy.MaxHP;
        
        

    }



    void Update()
    {
        float rotationAngle = Mathf.Sin(Time.time * oscillationSpeed * Mathf.Deg2Rad) * 4f;
        if (!DefaultAnimator.GetBool("isDead")) transform.rotation = Quaternion.Euler(0f, 0f, rotationAngle);
        if(!DefaultAnimator.GetBool("isDead")) transform.Translate(Vector2.right * -1 * Time.deltaTime);
        if(_currentHP <= 0)
        {
            DefaultAnimator.SetBool("isDead", true);
            StartCoroutine(EnemyDeath());

        }

    }

    public IEnumerator  EnemyDeath()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        if (!hasDeathCounted)
        {
            GameManager.Instance.KillCount++;
            GameManager.Instance.KillCountUpdate();
            hasDeathCounted = true;

        }


    }

    public void Damage(int amount)
    {
       _currentHP -= amount;


    }

    public float GetHPratio()
    {
        return (_currentHP / (float)Enemy.MaxHP)*1.5f;
    }




}
