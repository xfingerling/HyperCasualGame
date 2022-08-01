using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuWindow : WindowBase
{
    [SerializeField] private Button _playButton;

    protected override void Awake()
    {
        base.Awake();
        _playButton.onClick.AddListener(OnPlayButtonClicked);
    }

    private void Start()
    {
        Debug.Log("MainMenuWindow Start");
    }

    private void OnPlayButtonClicked()
    {
        var level = MainApp.instance.dynamicDataProvider.Levels.First();
        MainApp.instance.gameController.Play(level);
        Close();
    }
}
