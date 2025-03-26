using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovable : MonoBehaviour
{
    [Header("Components")]
    
    [SerializeField] float moveSpeed = 500f;

    RectTransform _transformArrow;
    RectTransform _transformNode;

    void Awake()
    {
        _transformArrow = GetComponent<RectTransform>();
        _transformNode = GetComponentInParent<RectTransform>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        _transformNode.anchoredPosition += new Vector2(moveX, moveY);

        Vector2 direction = (_transformNode.anchoredPosition - _transformArrow.anchoredPosition).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        _transformArrow.rotation = Quaternion.Euler(0, 0, angle);    
    }
}
