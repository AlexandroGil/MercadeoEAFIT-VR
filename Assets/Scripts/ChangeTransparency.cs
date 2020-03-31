using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTransparency : MonoBehaviour {

    [SerializeField]
    private float fadeSpeed = 1;

    private GameObject cube;
    private GameObject canvas;
    private MeshRenderer renderer;

    public bool isFading;
    public bool faded;

    // Start is called before the first frame update
    void OnEnable() {
        cube = this.gameObject;
        canvas = gameObject.transform.GetChild(0).gameObject;
        renderer = cube.GetComponent<MeshRenderer>();
    }

    IEnumerator FadeOut() {
        for(float t = fadeSpeed;t>= -0.5f;t -= 0.05f) {
            Color c = renderer.material.color;
            c.a = t;
            renderer.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }

        faded = true;
    }

    public void ButtonPressedEnter() {
        isFading = true;
        canvas.SetActive(false);
        //cube.SetActive(false);
        StartCoroutine("FadeOut");
        StartCoroutine("DestroyObject");
    }

    public void ButtonPressedExit() {
        Application.Quit();
    }

    IEnumerator DestroyObject() {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
}
