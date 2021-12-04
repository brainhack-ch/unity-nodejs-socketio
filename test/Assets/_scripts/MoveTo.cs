using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    public bool b_move_to;
    private bool b_is_moving;

    public Transform goal;

    private NavMeshAgent agent;
    public SocketIOScript socketioscript;
    public _player_manager pm;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
        socketioscript = GameObject.Find("SocketIO").GetComponent<SocketIOScript>();
        pm = GameObject.Find("_game_manager").GetComponent<_player_manager>();
    }


    public void move_to()
    {
        socketioscript.SendChat("targeted" + " " + this.transform.name + " " + pm.list_player.Find(p => p.s_player_id == this.transform.name).cur_room.s_room_id);

        b_move_to = false;
        b_is_moving = true;

        RaycastHit hit;
        if (Physics.Raycast(goal.transform.position, -transform.up, out hit, 100))
        {
            goal.position = hit.point;
        }

        if ((agent.destination - goal.position).magnitude < agent.radius)
            return;

        agent.destination = goal.position;
    }

    private void Update()
    {
        if (b_move_to)
        {
            move_to();
        }
        if (b_is_moving)
        {
            //Debug.Log(this.transform.name + " - " + Vector2.Distance(new Vector2(agent.transform.position.x, agent.transform.position.z), new Vector2(goal.position.x, goal.position.z)) + " - " + agent.velocity.sqrMagnitude);
            if (Vector2.Distance(new Vector2(agent.transform.position.x, agent.transform.position.z), new Vector2(goal.position.x, goal.position.z)) <= path_end_offset && agent.velocity.sqrMagnitude < 0.1f)
            {
                b_is_moving = false;
                socketioscript.SendChat("reached" + " " + this.transform.name + " " + pm.list_player.Find(p => p.s_player_id == this.transform.name).cur_room.s_room_id);
            }
        }
    }

    private float path_end_offset = 2f;
}
