using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    [Header("Panels")]
    [SerializeField] GameObject _introPanel;
    [SerializeField] GameObject _gamePanel;
    [SerializeField] GameObject _retryPanel;
    [SerializeField] GameObject _nextLevelPanel;
    [SerializeField] GameObject _settingsPanel;
    [SerializeField] GameObject _loadingPanel;
    [SerializeField] Animator _loadingAnim;
    [Header("Texts")]
    [SerializeField] TextMeshProUGUI _currentLevelText;
    [SerializeField] TextMeshProUGUI _nextLevelText;
    [SerializeField] TextMeshProUGUI _scoreText;
    [Header("ProgressBar")]
    [SerializeField] Slider _progressBar;
    [Header("Settings")]
    [SerializeField] Slider _musicSlider;
    [SerializeField] Slider _soundSlider;

    public void IntroPanel()
    {
        _introPanel.SetActive(true);
        _gamePanel.SetActive(true);
        _retryPanel.SetActive(false);
        _nextLevelPanel.SetActive(false);
    }
    public void GamePanel()
    {
        _introPanel.SetActive(false);
        _gamePanel.SetActive(true);
        _retryPanel.SetActive(false);
        _nextLevelPanel.SetActive(false);
    }
    public void SettingsPanelShow()
    {
        _settingsPanel.SetActive(true);
    }
    public void SettingsPanelHide()
    {
        _settingsPanel.SetActive(false);
    }
    public void RetryPanel()
    {
        StartCoroutine(PanelRoutine(_retryPanel));
    }
    public void NextLevelPanel()
    {
        StartCoroutine(PanelRoutine(_nextLevelPanel));
    }
    public void LevelText()
    {
        _currentLevelText.text = $"{(LevelManager.instance.Index + 1)}";
        _nextLevelText.text = $"{(LevelManager.instance.Index + 2)}";
    }
    public void ScoreUpdate(int score)
    {
        _scoreText.text = $"{score}";
    }
    public void ProgressBar(float value)
    {
        _progressBar.value = value;
    }
    public void MusicVolume()
    {
        int x = Mathf.RoundToInt(_musicSlider.value);
        _musicSlider.value = x;
        AudioManager.instance.MusicVolume(x);
    }
    public void SoundVolume()
    {
        int x = Mathf.RoundToInt(_soundSlider.value);
        _soundSlider.value = x;
    }
    IEnumerator PanelRoutine(GameObject obj)
    {
        yield return new WaitForSeconds(1);
        obj.SetActive(true);
    }
    public IEnumerator LevelLoadRoutine(int index)
    {
        _loadingPanel.SetActive(true);
        _loadingAnim.SetTrigger("fadeIn");
        yield return new WaitForSeconds(1f);
        LevelManager.instance.ManageLevel(index);
        _loadingAnim.SetTrigger("fadeOut");
        yield return new WaitForSeconds(1f);
        _loadingPanel.SetActive(false);
    }
}
