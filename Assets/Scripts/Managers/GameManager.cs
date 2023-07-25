using Colony;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] private LevelManager _levelManager;
        public static GameManager Instance { get; set; }
        
        private void Start()
        {
            _levelManager.CreateLevel();
        }
     
        public void LevelWon()
        {
       
            SceneManager.LoadScene("Game");
            _levelManager.SetLevel();
        }

        public void LevelFail()
        {
            SceneManager.LoadScene("Game");
        }

        public void OnLevelEnd()
        {
            PlayerColonyController.Instance.StopMove();
            UiManager.Instance.Next();
        }



    }
}
