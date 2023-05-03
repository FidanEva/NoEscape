//Shady
using UnityEngine;

[ExecuteInEditMode]
public class Reveal : MonoBehaviour
{
    [SerializeField] Material Mat;
    [SerializeField] Light SpotLight;

    Transform tfLight;

    private void Start()
    {
        var goLight = GameObject.Find("RevealingLight");
        if (goLight) tfLight = goLight.transform;
    }

    void Update ()
    {
        if (SpotLight.enabled == true)
        {
            //Debug.Log("fdv");
            Mat.SetVector("_LightPos", SpotLight.transform.position);
            Mat.SetVector("_LightDir", SpotLight.transform.forward);
            Mat.SetFloat("_Range", 8);

        }

        if (SpotLight.enabled == false)
        {
            Mat.SetFloat("_Range", 0);
            Debug.Log("range");
        }
        //Mat.SetFloat ("MyLightAngle", SpotLight.spotAngle);
    }//Update() end
}//class end