using System;
using System.Collections;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SlimeRPG
{
    public class Level : MonoBehaviour
    {
        // Singleton
        private static Level _instance;
        
        // Important objects
        [SerializeField] private Slime _slime;
        [SerializeField] private Player _player;
        [SerializeField] private GuiHandler _guiHandler;
        [SerializeField] private CinemachineVirtualCamera _virtualCamera;
        [SerializeField] private Spawner _spawner;
        [SerializeField] private Stager _stager;

        // Static getters
        public static Slime GetSlime => _instance._slime;
        public static Player GetPlayer => _instance._player;
        public static GuiHandler GetGui => _instance._guiHandler;
        public static Spawner GetSpawner => _instance._spawner;
        public static Stager GetStager => _instance._stager;
        
        [Header("Scene Preferences")] 
        [SerializeField] private Transform _slimeSpawnpoint;
        
        private void Awake()
        {
            Application.targetFrameRate = 60;
            
            _instance = this;

            InitializeSlime();
            ConfigureVirtualCamera();
            ConfigurePlayer();
        }

        private void ConfigurePlayer()
        {
            _player.slime = _slime;
        }

        private void ConfigureVirtualCamera()
        {
            _virtualCamera.Follow = _slime.transform;
        }

        private void InitializeSlime()
        {
            if (!_slime) return;

            _slime = Instantiate(_slime, _slimeSpawnpoint.position, Quaternion.identity, transform);
            Destroy(_slimeSpawnpoint.gameObject);
        }

        private void OnApplicationQuit()
        {
            Save();
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            if (!hasFocus)
                Save();
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            if (pauseStatus)
                Save();
        }

        private void Save()
        {
            _slime.SaveToDisk();
            _player.SaveToDisk();
            _stager.SaveToDisk();
        }

        public static void ReloadScene()
        {
            GetStager.crrPresetNumber = 0;
            _instance.Save();

            SceneManager.LoadScene("GamePlay");
        }
    }
}