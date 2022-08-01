using UnityEngine;

public class MainApp : Singletone<MainApp>
{
    public IDynamicDataProvider dynamicDataProvider { get; private set; }
    public WindowManager windowManager { get; private set; }
    public GameController gameController { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        dynamicDataProvider = new DebugDynamicDataProvider();

        windowManager = new GameObject("[WindowManager]").AddComponent<WindowManager>();
        windowManager.transform.SetParent(transform);

        gameController = new GameObject("[GameController]").AddComponent<GameController>();
        gameController.transform.SetParent(transform);
    }

    private void Start()
    {
        windowManager.Show<MainMenuWindow>();
    }
}
