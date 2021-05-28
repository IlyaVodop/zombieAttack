using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static event Action GameStarted;
    private enum UIState
    {
        Menu,
        Game,
        GameOver
    }

    [SerializeField]
    private GameObject MenuPanel;
    [SerializeField]
    private GameObject GameOverPanel;
    [SerializeField]
    private GameObject GamePanel;

    public Button GameBtn3D;

    [SerializeField]
    private Text _score;


    private UIState _currentState;

    private int _reward;

    void Awake()
    {
        _currentState = UIState.Menu;
        UpdateState();

        Subscribe();

    }


    void OnDestroy()
    {
        Unsubscribe();
    }

    private void Subscribe()
    {
        GameBtn3D.onClick.AddListener(StartGame);
        Player3D.GameOver += Player3D_GameOver;
        Enemy3D.OnReward += Enemy3D_OnReward;
    }

    private void Enemy3D_OnReward(int reward)
    {
        _reward += reward;
        _score.text = _reward.ToString();
    }

    private void Player3D_GameOver()
    {
        SetState(UIState.GameOver);
    }

    private void Unsubscribe()
    {
        GameBtn3D.onClick.RemoveListener(StartGame);
        Player3D.GameOver -= Player3D_GameOver;
        Enemy3D.OnReward -= Enemy3D_OnReward;
    }

    private void UpdateState()
    {
        MenuPanel.SetActive(_currentState == UIState.Menu);
        GameOverPanel.SetActive(_currentState == UIState.GameOver);
        GamePanel.SetActive(_currentState == UIState.Game);
    }

    private void SetState(UIState state)
    {
        _currentState = state;
        UpdateState();
    }

    private void StartGame()
    {
        SetState(UIState.Game);
        GameStarted?.Invoke();
    }
}
