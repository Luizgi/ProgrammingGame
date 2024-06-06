using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [Header("Components")]
    [SerializeField] RectTransform _transform;
    [SerializeField] Canvas _canvas;
    [SerializeField] CanvasGroup _canvasGroup;
    [SerializeField] AudioSource _audioSource;

    [Header("Audio Clips")]
    [SerializeField] AudioClip _drag;
    [SerializeField] AudioClip _drop;

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Clicked");
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
       // _audioSource.clip = _drag;
       // _audioSource.Play();

        _canvasGroup.alpha = .5f;
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _transform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
      //  _audioSource.clip = _drop;
      //  _audioSource.Play();

        _canvasGroup.alpha = 1f;
        _canvasGroup.blocksRaycasts = true;
    }
}
