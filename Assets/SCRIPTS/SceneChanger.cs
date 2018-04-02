using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {
	public void LoadScene (int sceneBuildIndex) {
		SceneManager.LoadScene (sceneBuildIndex);
	}
	public void LoadScene (string sceneName) {
		SceneManager.LoadScene (sceneName);
	}
}
