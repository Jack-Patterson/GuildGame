using System;
using System.Collections.Generic;
using com.Halcyon.API.Services.Scenes;
using UnityEngine.SceneManagement;
using Scene = com.Halcyon.API.Services.Scenes.Scene;

namespace com.Halcyon.Core.Services.Scenes
{
    public class SceneService: ISceneService
    {
        private List<Scene> _scenes;

        public List<Scene> Scenes => _scenes;

        public SceneService()
        {
            _scenes = new List<Scene>();
            _scenes.Add(new Scene("MainMenu", 0));
            _scenes.Add(new Scene("GameScene", 1));
        }

        public void AddScene(Scene scene)
        {
            _scenes.Add(scene);
        }

        public Scene GetScene(int sceneIndex)
        {
            foreach (Scene scene in _scenes)
            {
                if (scene.SceneIndex == sceneIndex)
                {
                    return scene;
                }
            }

            throw new SceneNotFoundException($"Scene with build index {sceneIndex} cannot be found.");
        }

        public Scene GetScene(string name)
        {
            foreach (Scene scene in _scenes)
            {
                if (scene.Name.Equals(name))
                {
                    return scene;
                }
            }

            throw new SceneNotFoundException($"Scene named {name} cannot be found.");
        }

        public void ChangeToScene(Scene scene)
        {
            ChangeToScene(scene.SceneIndex);
        }

        public void ChangeToScene(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }

        public void ChangeToScene(string name)
        {
            ChangeToScene(GetScene(name).SceneIndex);
        }

        public void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}