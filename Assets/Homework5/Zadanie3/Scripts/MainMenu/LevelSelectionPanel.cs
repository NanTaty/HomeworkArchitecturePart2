using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LevelSelectionPanel : MonoBehaviour
{
    [SerializeField] private Button oneColorSelectBtn;

    [SerializeField] private Button allColorSelectBtn;

    private SceneLoader _sceneLoader;

    [Inject]
    private void Construct(SceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
    }

    private void OnEnable()
    {
        oneColorSelectBtn.onClick.AddListener(SelectOneColorMode);
        allColorSelectBtn.onClick.AddListener(SelectAllColorMode);
    }

    private void OnDisable()
    {
        oneColorSelectBtn.onClick.RemoveListener(SelectOneColorMode);
        allColorSelectBtn.onClick.RemoveListener(SelectAllColorMode);
    }

    private void SelectOneColorMode() => _sceneLoader.Load(new LevelLoadingData(GameType.OneColor));
    
    private void SelectAllColorMode() => _sceneLoader.Load(new LevelLoadingData(GameType.AllColors));
}
