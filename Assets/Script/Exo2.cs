using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Exo2 : MonoBehaviour
{
    [SerializeField] GameObject rightController;
    [SerializeField] private GameObject[] projectiles;
    [SerializeField] private GameObject[] targets;
    public Vector3[] tab_pos_init;
    public Quaternion[] tab_rot_init;


    //Scoring
    public int points = 100;

    public static int score;
    [SerializeField] public TextMeshProUGUI score_nb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        projectiles = GameObject.FindGameObjectsWithTag("Projectile");
        targets = GameObject.FindGameObjectsWithTag("Target");
        tab_pos_init = new Vector3[projectiles.Length];

        for (var i = 0; i < projectiles.Length; i++)
        {
            tab_pos_init[i] = projectiles[i].transform.position;
            tab_rot_init[i] = projectiles[i].transform.rotation;
        }

        //Scoring
        score = 0;
        UpdateScoreUI();

    }

    // Update is called once per frame
    void Update()
    {
        for (var i = 0; i < projectiles.Length; i++)
        {
            if (projectiles[i].transform.position != tab_pos_init[i])
            {
                GameObject projectile = Instantiate(projectiles[i], tab_pos_init[i], tab_rot_init[i]);
            }
        }


    }

    //Scoring
    public void AddPoints(int points)
    {
        score += points;
        UpdateScoreUI();
    }
    void UpdateScoreUI()
    {
        score_nb.text = score.ToString();
    }
}
