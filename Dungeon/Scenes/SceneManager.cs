using Dungeon.Utils;
using Dungeon.Utils.Services;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon.Scenes
{
    public enum SceneType
    {
        Scene_Game,
        Scene_Editor,
        /*Scene_Help,
        Scene_Title*/
    }

    class SceneManager : ISceneService
    {
        private OrderedDictionary<SceneType, Scene> sceneContainer;
        private List<SceneType> sceneToRemove;
        private Dictionary<SceneType, Func<Scene>> factories;

        public Scene CurrentScene
        {
            get
            {
                return sceneContainer.Last;
            }
        }

        public SceneManager()
        {
            sceneContainer = new OrderedDictionary<SceneType, Scene>();
            sceneToRemove = new List<SceneType>();
            factories = new Dictionary<SceneType, Func<Scene>>();

            factories.Add(SceneType.Scene_Game, () => new Scene_Game(this));
            factories.Add(SceneType.Scene_Editor, () => new Scene_Editor(this));
        }

        public void Destroy()
        {
            foreach(Scene scene in sceneContainer.Values)
            {
                scene.Unload();
            }
            sceneContainer.Clear();
            sceneToRemove.Clear();
            factories.Clear();
        }

        public void Update(float dt)
        {
            if (sceneContainer.Count <= 0) return;
            if (sceneContainer.Last.IsTranscendent && sceneContainer.Count > 1)
            {
                int j = sceneContainer.Count - 1; // j records last transcendent scene index
                foreach (var scene in sceneContainer.Reverse())
                {
                    if (!scene.Value.IsTranscendent) break;
                    j--;
                }
                for (int i = j; i < sceneContainer.Count; i++)
                {
                    sceneContainer[j].Update(dt);
                }
            }
            else
            {
                sceneContainer.Last.Update(dt);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (sceneContainer.Count <= 0) return;
            if (sceneContainer.Last.IsTransparent && sceneContainer.Count > 1)
            {
                int j = sceneContainer.Count - 1;
                foreach(var scene in sceneContainer.Reverse())
                {
                    if (!scene.Value.IsTransparent) break;
                    j--;
                }
                for(int i = j; i < sceneContainer.Count; i++)
                {
                    sceneContainer[j].Draw(spriteBatch);
                }
            }
            else
            {
                sceneContainer.Last.Draw(spriteBatch);
            }
        }

        public bool HasScene(SceneType type)
        {
            return sceneContainer.ContainsKey(type);
        }

        public void SwitchTo(SceneType type)
        {
            if(sceneContainer.ContainsKey(type))
            {
                Scene temp = sceneContainer[type];
                sceneContainer.Remove(type);
                sceneContainer.Add(type, temp);
                return;
            }

            if(sceneContainer.Count != 0)
            {
                sceneContainer.Last.Deactivate();
            }
            CreateScene(type);
            sceneContainer.Last.Activate();
        }

        private void CreateScene(SceneType type)
        {
            Scene newScene = factories[type]();
            if (newScene == null) return;
            sceneContainer.Add(type, newScene);
            newScene.Load();
        }

        public void Remove(SceneType type)
        {
            sceneToRemove.Add(type);
        }

        public void ProcessRemoval()
        {
            foreach (SceneType t in sceneToRemove)
            {
                RemoveScene(t);
            }
        }

        private void RemoveScene(SceneType type)
        {
            if(sceneContainer.ContainsKey(type))
            {
                sceneContainer[type].Unload();
                sceneContainer.Remove(type);
            }
        }
    }
}
