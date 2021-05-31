using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StartGameListener : MonoBehaviour
{
    [SerializeField] private List<GameObject> _enableOnStartGame;
    void Awake()
    {
        UiManager.GameStarted += () => { _enableOnStartGame.ForEach(x => x.gameObject.SetActive(true)); };
    }
}
