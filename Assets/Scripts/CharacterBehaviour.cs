using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    public GameObject Arrow;
    public Transform CharacterPosition;
    public Animator Animator;
    public int CurrentLayer;
    public UpdateRatioDependingLayer UpdateRatioInstance;
    private bool _isShooting = false;
    private bool _isEnd;
    public float arrowMultiplicator = 0.04f;

    public CharacterData Character;

    private int _currentHP;

    void Start()
    {
        _isEnd = false;
        CurrentLayer = 8;
        gameObject.layer = CurrentLayer;
        _currentHP = Character.MaxHP;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !_isShooting)
        {
            ShootArrow();
        }
        if (Input.GetKeyDown(KeyCode.W) && !UpdateRatioInstance.isMoving)
        {
            Move(false);
        }
        if (Input.GetKeyDown(KeyCode.S) && !UpdateRatioInstance.isMoving)
        {
            Move(true);

        }
    }

        void ShootArrow()
    {
        if (UpdateRatioInstance.isMoving) return;
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.nearClipPlane; 
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            
        Vector3 shootDirection = (worldMousePosition - CharacterPosition.position).normalized;
        float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;

        GameObject arrow = Instantiate(Arrow, CharacterPosition.position, Quaternion.Euler(0, 0, angle -90));
        UpdateRatioDependingLayerObjectsAndNPCS.UpdateFastLayer(arrow, CurrentLayer, arrowMultiplicator);
       
        arrow.GetComponent<Rigidbody2D>().AddForce(shootDirection * Character.ShotSpeed, ForceMode2D.Impulse);
        Animator.SetTrigger("Shoot");
        StartCoroutine(ShootDelay());
    }

    void Move(bool Forward)
    {
        if (Forward && gameObject.layer == 9) return;
        if (!Forward && gameObject.layer == 6) return;
        if (Forward) gameObject.layer++;
        if (!Forward) gameObject.layer--;
        CurrentLayer = gameObject.layer;
        Animator.SetTrigger("Walk");



    }


    IEnumerator ShootDelay()
    {
        _isShooting = true;
        yield return new WaitForSeconds(Character.ShotDelay);
        _isShooting = false;
    }

    public void Damages(int amount)
    {
        _currentHP -= amount;
        if (_currentHP <= 0)
        {
            if(!_isEnd)GameManager.Instance.UpdateEnd();
            _isEnd = true;
        }
    }
        public float GetHPratio()
    {
        return (_currentHP / (float)Character.MaxHP) * 1.82f;
    }




}
