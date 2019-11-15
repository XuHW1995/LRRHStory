using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace XFramework
{
    public class SceneMgr : GameMgr<SceneMgr>
    {
        public override void Init()
        {

        }

        public override void Start()
        {

        }

        public override void EnterGame()
        {

        }

        public override void Update()
        {

        }

        public override void Destroy()
        {

        }

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
