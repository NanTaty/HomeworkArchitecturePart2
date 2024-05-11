using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private Button _restart;
    [SerializeField] private Button _menuBtn;
    
    public event Action OnRestartClick;
    
    public event Action OnMenuBtnClick;

    private void Start()
    {
        Hide();
    }

    private void OnEnable()
    {
        _menuBtn.onClick.AddListener(MenuClick);
        
        _restart.onClick.AddListener(RestartClick);
    }

    private void OnDisable()
    {
        _menuBtn.onClick.RemoveListener(MenuClick);
        
        _restart.onClick.RemoveListener(RestartClick);
    }

    public void Show() => gameObject.SetActive(true);

    public void Hide() => gameObject.SetActive(false);

    private void MenuClick()
    {
        OnMenuBtnClick?.Invoke();
    }

    private void RestartClick()
    {
        OnRestartClick?.Invoke();
        Hide();
    }
}
