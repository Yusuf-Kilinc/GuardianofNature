using UnityEngine;

public class PlayerTaken : MonoBehaviour
{
    public Transform Player;

    Vector3 pos,pos1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pos = new Vector3(Player.transform.position.x, Player.transform.position.y + 2f, -10);
        pos1 = new Vector3(transform.position.x, transform.position.y, -10);


       // this.transform.position = pos;

        this.transform.position = Vector3.Lerp(pos1, pos, 1 * Time.deltaTime);
    }
}
