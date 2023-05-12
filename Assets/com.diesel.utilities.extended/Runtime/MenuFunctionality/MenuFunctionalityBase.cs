using UnityEngine;

public abstract class MenuFunctionalityBase : MonoBehaviour
{
    [Header("Toggle Menus")]
    [SerializeField] private GameObject MainMenuToggle;
    [SerializeField] private GameObject PauseMenuToggle;
    [SerializeField] private GameObject SettingsToggle;

    // Settings
    private bool SettingsMenuCurrentlyActive = false;
    private bool PauseMenuCurrentlyActive = false;
    private bool isFullscreen = false;
    private bool CanPause = false;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePauseMenu();
    }

    public abstract void Continue();
    public abstract void NewGame();
    public virtual void Quit() => Application.Quit();

    public virtual void ToggleSettingsMenu() {
        SettingsMenuCurrentlyActive = !SettingsMenuCurrentlyActive;
        SettingsToggle.SetActive(SettingsMenuCurrentlyActive);
    }

    public virtual void TogglePauseMenu() {
        if (!CanPause)
            return;

        PauseMenuCurrentlyActive = !PauseMenuCurrentlyActive;
        PauseMenuToggle.SetActive(PauseMenuCurrentlyActive);
    }

    public virtual void ToggleFullscreen() {
        isFullscreen = !isFullscreen;
    }

    public virtual void HideMenu() {
        MainMenuToggle.SetActive(false);

        CanPause = true;
    }
}