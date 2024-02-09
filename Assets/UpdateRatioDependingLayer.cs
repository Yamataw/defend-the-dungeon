using System.Collections;
using UnityEngine;

public class UpdateRatioDependingLayer : MonoBehaviour
{
    private int _currentLayerIndex;
    private Animator _animator;
    public bool isMoving = false;
    void Start()
    {
        _currentLayerIndex = 6;
        _animator = GetComponent<Animator>();

    }

    void Update()
    {
        if (gameObject.layer == _currentLayerIndex) return;

        float ratio = (gameObject.layer - 6f) * 0.125f;
        StartCoroutine(MoveAndScaleOverTime(Vector3.down * (gameObject.layer - _currentLayerIndex), new Vector3(1 + ratio, 1 + ratio, 1 + ratio), 1f));

        _currentLayerIndex = gameObject.layer;

    }

    IEnumerator MoveAndScaleOverTime(Vector3 targetPosition, Vector3 targetScale, float duration)
    {
        isMoving = true;

        float elapsedTime = 0f;
        Vector3 startingPos = transform.position;
        Vector3 startingScale = transform.localScale;


        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startingPos, startingPos + targetPosition, elapsedTime / duration);
            transform.localScale = Vector3.Lerp(startingScale, targetScale, elapsedTime / duration);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = startingPos + targetPosition;
        isMoving = false;
    }


}
