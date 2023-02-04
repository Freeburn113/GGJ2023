using System;
using ScriptableEvents;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class LevelLoader : MonoBehaviour
    {
        public static int levelToLoad = 0;

        private AsyncOperation _loadSceneAsync;

        [SerializeField]
        private StringScriptableEvent _progressEvent;

        [SerializeField] 
        private ScriptableEvent _loadingCompletedEvent;

        private float _previousProgress = 0;

        public static void LoadLevel(int index)
        {
            LevelLoader.levelToLoad = index;
            SceneManager.LoadScene(1);
        }

        private void Start()
        {
            if(levelToLoad != 0) LoadLevelAsync();
        }

        private void Update()
        {
            if(null != _loadSceneAsync)
            {
                if (!_loadSceneAsync.isDone)
                {
                    if (_previousProgress != _loadSceneAsync.progress)
                    {
                        _progressEvent.value = Mathf.RoundToInt((_loadSceneAsync.progress * 100)).ToString() + "%";
                        _previousProgress = _loadSceneAsync.progress;
                        
                        _progressEvent.Raise();
                    }
                }
                else
                {
                    Debug.Log("loading done");
                    _loadingCompletedEvent.Raise();
                }
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                LoadLoadedLevel();
            }
        }
        
        public void LoadLevelAsync()
        {
            _loadSceneAsync = SceneManager.LoadSceneAsync(levelToLoad);
            _loadSceneAsync.allowSceneActivation = false;
        }

        public void LoadLoadedLevel()
        {
            _loadSceneAsync.allowSceneActivation = true;
        }
    }
}