using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class DefeatPanel : MonoBehaviour
{
    [SerializeField] private Button _restart;

    public event Action OnRestartButtonClicked;

    private void Start()
    {
        Hide();
    }

    private void OnEnable()
    {
        _restart.onClick.AddListener(OnRestartClick);
    }

    private void OnDisable()
    {
        _restart.onClick.RemoveListener(OnRestartClick);
    }

    public void Show() => gameObject.SetActive(true);  

    public void Hide() => gameObject.SetActive(false);

    private void OnRestartClick() => OnRestartButtonClicked?.Invoke();
}
