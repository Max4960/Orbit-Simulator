using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
public void ToMenuScene(){      // This Function uses unity's built in scene manager to load the scene when
    SceneManager.LoadScene("Menu");
}

public void ToTemplateScene(){
    SceneManager.LoadScene("Templates");
}

public void ToCustomScene(){
    SceneManager.LoadScene("Custom");
}

public void ToOptionsScene(){
    SceneManager.LoadScene("Options");
}
}
