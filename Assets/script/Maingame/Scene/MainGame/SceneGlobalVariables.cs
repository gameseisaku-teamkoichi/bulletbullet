using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BulletBullet.SceneGlobalVariables.Stage
{
    public class SceneGlobalVariables : MonoBehaviour
    {
        public CharaNowStage charaNowStage;
        public StopGameTime stopGameTime;
        public CharacterStatus characterStatus;
        public CharacterSpawn characterSpawn;
        public DesInfo desInfo;
        public Scene scene;
        public Gun gun;

        private static SceneGlobalVariables instance;
        public static SceneGlobalVariables Instance
        {
            get { return instance; }
        }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
}
