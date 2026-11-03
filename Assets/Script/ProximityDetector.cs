using TMPro;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class ProximityDetector : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject rightController;
    [SerializeField] private GameObject[] tab;
    [SerializeField] Color colorprox;
    [SerializeField] float coef_echelle;
    [SerializeField] float seuil_declenche;
    [SerializeField] float seuil_angle = 20f;


    private Color[] tab_color_init;
    private Vector3[] tab_echelle_init;
    public LineRenderer rayon;
    private TextMeshPro myText;
    private GameObject myObject;

    void Start()
    {
        //Rayon
        rayon = gameObject.AddComponent<LineRenderer>();
        rayon.positionCount = 2;
        rayon.startWidth = 0.01f;
        rayon.endWidth = 0.01f;
        rayon.material = new Material(Shader.Find("Sprites/Default"));
        rayon.startColor = Color.white;
        rayon.endColor = Color.white;
        rayon.enabled = false;

        //Texte
        myObject = new GameObject("TexteInfos");
        myObject.transform.SetParent(rightController.transform, false);
        myObject.transform.localPosition = new Vector3(0, 0.05f, 0.1f);
        myText = myObject.AddComponent<TextMeshPro>();
        myText.fontSize = 0.4f;
        myText.alignment = TextAlignmentOptions.Center;
        myText.text = "";

        //Init Tableau
        tab_color_init = new Color[tab.Length];
        tab_echelle_init = new Vector3[tab.Length];

        for (var i = 0; i < tab.Length; i++)
        {
            tab_color_init[i] = tab[i].transform.GetComponent<Renderer>().material.color;
            tab_echelle_init[i] = tab[i].transform.localScale;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float mindist = float.MaxValue;
        int cubeproche = -1;

        for (var i = 0; i < tab.Length; i++)
        {
            float dist = Vector3.Distance(rightController.transform.position, tab[i].transform.position);
            if (dist < mindist)
            {
                mindist = dist;
                cubeproche = i;
            }
        }


        for (var i = 0; i < tab.Length; i++)
        { 
            float dist = Vector3.Distance(rightController.transform.position, tab[i].transform.position);
            Vector3 direction = tab[i].transform.position - rightController.transform.position;
            float angle = Vector3.Angle(rightController.transform.forward, direction);

            if (i == cubeproche && dist < seuil_declenche && angle < seuil_angle)
            {
                tab[i].transform.GetComponent<Renderer>().material.color = colorprox;
                tab[i].transform.localScale = tab_echelle_init[i] * coef_echelle;

                rayon.enabled = true;
                rayon.SetPosition(0, rightController.transform.position);
                rayon.SetPosition(1, tab[i].transform.position);

                myText.text = $"angle : {angle:F1}°\ndistance : {dist:F2}m";
            }
            else
            {
                tab[i].transform.GetComponent<Renderer>().material.color = tab_color_init[i];
                tab[i].transform.localScale = tab_echelle_init[i];
            }

            if(cubeproche == -1)
            {
                rayon.enabled = false;
            }

        }
    }
}
