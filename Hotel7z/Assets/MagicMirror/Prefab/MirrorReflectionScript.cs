using UnityEngine;
using System.Collections;

public class MirrorReflectionScript : MonoBehaviour
{
    private MirrorCameraScript childScript;
    

    private void Start()
    {
        childScript = gameObject.transform.parent.gameObject.GetComponentInChildren<MirrorCameraScript>();

        if (childScript == null)
        {
            Debug.LogError("Child script (MirrorCameraScript) should be in sibling object");
        }
        Sc_GameMng.instance.mirrorMaterial = GetComponent<Renderer>().material;

        if (Sc_GameMng.instance.mirrorMaterial == null)
        {
            Debug.LogError("거울 메테리얼 NULL");
        }
        else
            Debug.Log("mirrorMaterial : " + Sc_GameMng.instance.mirrorMaterial.name);
    }

    private void OnWillRenderObject()
    {
        childScript.RenderMirror();
    }
}
