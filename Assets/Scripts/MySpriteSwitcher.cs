using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Yarn.Unity.Example {

    //[RequireComponent (typeof (SpriteRenderer))]
    /// Attach SpriteSwitcher to game object
    public class MySpriteSwitcher : MonoBehaviour {

        [System.Serializable]
        public struct SpriteInfo {
            public string name;
            public Sprite sprite;
        }

        public Image image;

        public SpriteInfo[] sprites;

        /// Create a command to use on a sprite
        [YarnCommand("setsprite")]
        public void UseSprite(string spriteName) {

            Sprite s = null;
            foreach(var info in sprites) {
                if (info.name == spriteName) {
                    s = info.sprite;
                    break;
                }
             }
            if (s == null) {
                Debug.LogErrorFormat("Can't find sprite named {0}!", spriteName);
                return;
            }

            //GetComponent<SpriteRenderer>().sprite = s;
            image.sprite = s;
            image.SetNativeSize();
        }
    }

}
