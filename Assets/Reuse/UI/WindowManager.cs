using System;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
    public List<WindowBase> windows { get; }

    public WindowManager()
    {
        windows = new List<WindowBase>();
    }

    public T Show<T>() where T : WindowBase
    {
        var existWindow = windows.Find(window => window as T);
        if (existWindow != null)
        {
            existWindow.transform.SetAsLastSibling();
            ActivateWindow(existWindow);
            return existWindow as T;
        }

        var type = typeof(T);
        var windowPrefab = Resources.Load<T>($"UI/Windows/{type.Name}");
        var window = Instantiate(windowPrefab, transform, false);

        window.Bind(this).transform.SetAsLastSibling();
        windows.Add(window);

        return window;
    }

    public T Get<T>() where T : WindowBase
    {
        var existWindow = windows.Find(window => window as T);

        if (existWindow == null)
            throw new Exception($"The {existWindow.name} does not exist");

        return existWindow as T;
    }

    public void Close(WindowBase window)
    {
        var lastWindow = windows.Find(w => w.GetType() == window.GetType());

        if (lastWindow == null || !lastWindow.gameObject.activeInHierarchy)
            return;

        DeactivateWindow(window);
    }

    public void Close<T>() where T : WindowBase
    {
        var lastWindow = windows.Find(window => window as T);

        if (lastWindow == null || !lastWindow.gameObject.activeInHierarchy)
            return;

        DeactivateWindow(lastWindow);

    }

    public void CloseAll()
    {
        foreach (var window in windows)
            DeactivateWindow(window);
    }

    private void DeactivateWindow(WindowBase window)
    {
        if (window == null)
            return;

        window.gameObject.SetActive(false);
    }

    private void ActivateWindow(WindowBase window)
    {
        if (window == null)
            return;

        window.gameObject.SetActive(true);
    }
}