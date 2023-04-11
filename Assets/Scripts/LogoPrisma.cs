using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class LogoPrisma : MonoBehaviour
{
    public VideoClip AnimPrisma;
    [SerializeField]
    private void Awake()
    {
        StartCoroutine(WaitVideoOver());
    }

    private IEnumerator WaitVideoOver()
    {
        yield return new WaitForSeconds((float)AnimPrisma.length);
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
