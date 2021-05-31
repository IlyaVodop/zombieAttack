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
    private GameObject _menuPanel;
    [SerializeField]
    private GameObject _gameOverPanel;
    [SerializeField]
    private GameObject _gamePanel;

    public Button GameBtn3D;

    [SerializeField]
    private Text _scoreText;

    [SerializeField]
    private Text _savedScoreText;


    private UIState _currentState;

    private int _reward;

    private int SavedScore
    {
        get
        {
            return PlayerPrefs.GetInt("MaxScore", 0);
        }
        set
        {
            if (value > SavedScore)
            {
                PlayerPrefs.SetInt("MaxScore", value);
            }
        }
    }

    void Awake()
    {
        _currentState = UIState.Menu;
        _savedScoreText.text = SavedScore.ToString();
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
        _scoreText.text = _reward.ToString();
        SavedScore = _reward;
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
        _menuPanel.SetActive(_currentState == UIState.Menu);
        _gameOverPanel.SetActive(_currentState == UIState.GameOver);
        _gamePanel.SetActive(_currentState == UIState.Game);
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
