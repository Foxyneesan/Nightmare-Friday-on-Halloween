using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZarządzanieScenami : MonoBehaviour
{
 public void ZmienScene()
{
	SceneManager.LoadScene(1);
}

public void Wyjdz()
{
Application.Quit();
}
}
