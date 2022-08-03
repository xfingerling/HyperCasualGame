using UnityEngine;
using UnityEngine.UI;

public class LevelPassedWindow : WindowBase
{
    [SerializeField] private Button _mainMenuButton;

    protected override void Awake()
    {
        base.Awake();
        _mainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);
    }

    private void OnMainMenuButtonClicked()
    {
        MainApp.instance.gameController.Clear();
        MainApp.instance.windowManager.Show<MainMenuWindow>();
        Close();
    }
}
