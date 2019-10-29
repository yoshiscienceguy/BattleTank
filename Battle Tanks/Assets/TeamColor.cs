using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public enum team {
    Team1, Team2, Team3, Team4
};
public class TeamColor : NetworkBehaviour
{

    public Material[] teamColors;
    public MeshRenderer[] paintedObjects;
    public team currentTeam = team.Team1;
    public controlSwitch cs;

    public AimPlayer ap;
    public Transform fpsLocation;
    public Transform tpsLocation;
    public Transform pivotPoint;

    // Start is called before the first frame update
    void Start()
    {
        if (isLocalPlayer) {
    
            cs.ap = ap;
            cs.fpsLocation = fpsLocation;
            cs.tpsLocation = tpsLocation;
     
            cs.pivotPoint = pivotPoint;
            cs.GetComponent<followPlayer>().player = transform;
            ap.enabled = true;
        }
        updateTeam(currentTeam);
           
    }
    public void updateTeam(team newTeam) {
        foreach (MeshRenderer mr in paintedObjects)
        {
            switch (newTeam)
            {
                case team.Team1:
                    mr.material = teamColors[0];
                    break;
                case team.Team2:
                    mr.material = teamColors[1];
                    break;
                case team.Team3:
                    mr.material = teamColors[2];
                    break;
                case team.Team4:
                    mr.material = teamColors[3];
                    break;
            }

        }
        switch (newTeam)
        {
            case team.Team1:
                gameObject.layer = 10;
                break;
            case team.Team2:
                gameObject.layer = 11;
                break;
            case team.Team3:
                gameObject.layer = 12;
                break;
            case team.Team4:
                gameObject.layer = 13;
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
