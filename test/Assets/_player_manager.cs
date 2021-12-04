using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _player_manager : MonoBehaviour
{
    [Header("params")]
    public GameObject GO_prefab_player;
    public GameObject GO_prefab_goal;
    //public GameObject GO_spawn;
    [Header("debug")]
    public List<_player> list_player = new List<_player>();
    public List<_room> list_room = new List<_room>();
    public bool b_add_player;
    public string s_id;
    public string s_color;
    public GameObject GO_player_container;
    public GameObject GO_goal_container;
    [Header("fun")]
    public int i_nb;
    public bool b_add;

    public List<GameObject> list_GO_canvas = new List<GameObject>();


    private int i_max_answer_needed_per_room = 2;
    // Start is called before the first frame update
    void Start()
    {
        list_GO_canvas.Add(GameObject.Find("Canvas/Image/MRI/mri1"));
        list_GO_canvas.Add(GameObject.Find("Canvas/Image/MRI/mri2"));
        list_GO_canvas.Add(GameObject.Find("Canvas/Image/MRI/mri3"));
        list_GO_canvas.Add(GameObject.Find("Canvas/Image/MRI/mri4"));
        list_GO_canvas.Add(GameObject.Find("Canvas/Image/MRI/mri5"));
        


        GO_player_container = GameObject.Find("GO_player_container");
        GO_goal_container = GameObject.Find("GO_goal_container");

        _room r_auditorium = new _room();
        r_auditorium.s_room_id = "auditorium";
        r_auditorium.GO_room = GameObject.Find("_rooms/auditorium");
        r_auditorium.i_max_player_in = 100;
        r_auditorium.i_cur_number_player = 0;
        list_room.Add(r_auditorium);


        _room r_mri1 = new _room();
        r_mri1.s_room_id = "mri1";
        r_mri1.GO_room = GameObject.Find("_rooms/mri1");
        r_mri1.i_max_player_in = 100;
        r_mri1.i_cur_number_player = 0;
        r_mri1.i_correct_answer_needed = i_max_answer_needed_per_room;
        r_mri1.i_correct_answer_gotten = 0;
        r_mri1.i_incorrect_answer_gotten = 0;
        list_room.Add(r_mri1);
        GameObject.Find("Canvas/Image/MRI/mri1").transform.GetChild(0).GetComponent<Text>().text = (r_mri1.i_correct_answer_needed).ToString();
        GameObject.Find("Canvas/Image/MRI/mri1").transform.GetChild(1).GetComponent<Text>().text = (r_mri1.i_correct_answer_gotten).ToString();
        GameObject.Find("Canvas/Image/MRI/mri1").transform.GetChild(2).GetComponent<Text>().text = (r_mri1.i_incorrect_answer_gotten).ToString();

        _room r_mri2 = new _room();
        r_mri2.s_room_id = "mri2";
        r_mri2.GO_room = GameObject.Find("_rooms/mri2");
        r_mri2.i_max_player_in = 100;
        r_mri2.i_cur_number_player = 0;
        r_mri2.i_correct_answer_needed = i_max_answer_needed_per_room;
        r_mri2.i_correct_answer_gotten = 0;
        r_mri2.i_incorrect_answer_gotten = 0;
        list_room.Add(r_mri2);
        GameObject.Find("Canvas/Image/MRI/mri2").transform.GetChild(0).GetComponent<Text>().text = (r_mri2.i_correct_answer_needed).ToString();
        GameObject.Find("Canvas/Image/MRI/mri2").transform.GetChild(1).GetComponent<Text>().text = (r_mri2.i_correct_answer_gotten).ToString();
        GameObject.Find("Canvas/Image/MRI/mri2").transform.GetChild(2).GetComponent<Text>().text = (r_mri2.i_incorrect_answer_gotten).ToString();

        _room r_mri3 = new _room();
        r_mri3.s_room_id = "mri3";
        r_mri3.GO_room = GameObject.Find("_rooms/mri3");
        r_mri3.i_max_player_in = 100;
        r_mri3.i_cur_number_player = 0;
        r_mri3.i_correct_answer_needed = i_max_answer_needed_per_room;
        r_mri3.i_correct_answer_gotten = 0;
        r_mri3.i_incorrect_answer_gotten = 0;
        list_room.Add(r_mri3);
        GameObject.Find("Canvas/Image/MRI/mri3").transform.GetChild(0).GetComponent<Text>().text = (r_mri3.i_correct_answer_needed).ToString();
        GameObject.Find("Canvas/Image/MRI/mri3").transform.GetChild(1).GetComponent<Text>().text = (r_mri3.i_correct_answer_gotten).ToString();
        GameObject.Find("Canvas/Image/MRI/mri3").transform.GetChild(2).GetComponent<Text>().text = (r_mri3.i_incorrect_answer_gotten).ToString();

        _room r_mri4 = new _room();
        r_mri4.s_room_id = "mri4";
        r_mri4.GO_room = GameObject.Find("_rooms/mri4");
        r_mri4.i_max_player_in = 100;
        r_mri4.i_cur_number_player = 0;
        r_mri4.i_correct_answer_needed = i_max_answer_needed_per_room;
        r_mri4.i_correct_answer_gotten = 0;
        r_mri4.i_incorrect_answer_gotten = 0;
        list_room.Add(r_mri4);
        GameObject.Find("Canvas/Image/MRI/mri4").transform.GetChild(0).GetComponent<Text>().text = (r_mri4.i_correct_answer_needed).ToString();
        GameObject.Find("Canvas/Image/MRI/mri4").transform.GetChild(1).GetComponent<Text>().text = (r_mri4.i_correct_answer_gotten).ToString();
        GameObject.Find("Canvas/Image/MRI/mri4").transform.GetChild(2).GetComponent<Text>().text = (r_mri4.i_incorrect_answer_gotten).ToString();

        _room r_mri5 = new _room();
        r_mri5.s_room_id = "mri5";
        r_mri5.GO_room = GameObject.Find("_rooms/mri5");
        r_mri5.i_max_player_in = 100;
        r_mri5.i_cur_number_player = 0;
        r_mri5.i_correct_answer_needed = i_max_answer_needed_per_room;
        r_mri5.i_correct_answer_gotten = 0;
        r_mri5.i_incorrect_answer_gotten = 0;
        list_room.Add(r_mri5);
        GameObject.Find("Canvas/Image/MRI/mri5").transform.GetChild(0).GetComponent<Text>().text = (r_mri5.i_correct_answer_needed).ToString();
        GameObject.Find("Canvas/Image/MRI/mri5").transform.GetChild(1).GetComponent<Text>().text = (r_mri5.i_correct_answer_gotten).ToString();
        GameObject.Find("Canvas/Image/MRI/mri5").transform.GetChild(2).GetComponent<Text>().text = (r_mri5.i_incorrect_answer_gotten).ToString();


        _room r_vr1 = new _room();
        r_vr1.s_room_id = "vr1";
        r_vr1.GO_room = GameObject.Find("_rooms/vr1");
        r_vr1.i_max_player_in = 10;
        r_vr1.i_cur_number_player = 0;
        list_room.Add(r_vr1);
        _room r_vr2 = new _room();
        r_vr2.s_room_id = "vr2";
        r_vr2.GO_room = GameObject.Find("_rooms/vr2");
        r_vr2.i_max_player_in = 10;
        r_vr2.i_cur_number_player = 0;
        list_room.Add(r_vr2);
    }

    // Update is called once per frame
    void Update()
    {
        if (b_add_player)
        {
            b_add_player = false;

            add_new_player(s_id, s_color);
        }

        if (b_add)
        {
            b_add = false;

            for (int i = 0; i < i_nb; i++)
            {
                string s = ((int)Random.Range(0,100000)).ToString();
                string s_color = ColorUtility.ToHtmlStringRGB(new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1));
                add_new_player(s, "#" + s_color);
            }
        }
    }

    public void add_new_player(string in_s_player_id, string in_s_color)
    {
        bool b_p_exist = false;
        foreach (_player p in list_player)
        {
            if (p.s_player_id == in_s_player_id)
            {
                b_p_exist = true;
            }
        }
        if (!b_p_exist)
        {
            _player new_player = new _player();
            new_player.s_player_id = in_s_player_id;
            new_player.cur_room = list_room.Find(r => r.s_room_id == "auditorium");
            list_room.Find(r => r.s_room_id == "auditorium").i_cur_number_player++;
            new_player.GO_player = Instantiate(GO_prefab_player, new_player.cur_room.GO_room.transform.position + new Vector3(Random.Range(-1f,1f), Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f)), Quaternion.identity);
            new_player.GO_player.transform.parent = GO_player_container.transform;
            new_player.GO_player.name = in_s_player_id;
            new_player.GO_goal = Instantiate(GO_prefab_goal, new_player.cur_room.GO_room.transform.position, Quaternion.identity);
            new_player.GO_goal.transform.parent = GO_goal_container.transform;
            new_player.list_string_completed_rooms = new List<string>();
            new_player.list_string_correct_rooms = new List<string>();

            Material mat_new_mat = new Material(Shader.Find("Standard"));
            Color out_color = new Color(1,1,1,1);
            ColorUtility.TryParseHtmlString(in_s_color, out out_color);
            mat_new_mat.SetColor("_Color", out_color);
            new_player.GO_player.GetComponent<MeshRenderer>().material = mat_new_mat;
            new_player.GO_goal.GetComponent<MeshRenderer>().material = mat_new_mat;

            new_player.GO_player.GetComponent<MoveTo>().goal = new_player.GO_goal.transform;

            list_player.Add(new_player);
        }
        else
        {
            Debug.Log(s_id + " already exists");
        }
    }

    public void move_player_to(string in_s_player_id, string s_target)
    {
        _player target_player = list_player.Find(p => p.s_player_id == in_s_player_id);
        _room r_target = list_room.Find(r => r.s_room_id == s_target);

        if (target_player != null && r_target != null)
        {
            if (r_target.i_cur_number_player < r_target.i_max_player_in)
            {
                target_player.GO_goal.transform.position = r_target.GO_room.transform.position;
                list_room.Find(r => r.s_room_id == target_player.cur_room.s_room_id).i_cur_number_player--;
                list_room.Find(r => r.s_room_id == s_target).i_cur_number_player++;
                target_player.cur_room = list_room.Find(r => r.s_room_id == s_target);
            }
            else
            {
                Debug.Log(r_target.s_room_id + " - too many players in the room");
            }

            //target_player.GO_player.GetComponent<MoveTo>().b_move_to = true;
            target_player.GO_player.GetComponent<MoveTo>().move_to();
        }
    }

    public void validate_answer(string in_s_player_id, string s_target)
    {
        _player target_player = list_player.Find(p => p.s_player_id == in_s_player_id);

        if (!target_player.list_string_completed_rooms.Contains(s_target))
        {
            target_player.list_string_completed_rooms.Add(s_target);
            target_player.list_string_correct_rooms.Add(s_target);
            _room r_target = list_room.Find(r => r.s_room_id == s_target);
            r_target.i_correct_answer_gotten++;

            GameObject GO_canvas = list_GO_canvas.Find(go => go.name == s_target);
            GO_canvas.transform.GetChild(1).GetComponent<Text>().text = (int.Parse(GO_canvas.transform.GetChild(1).GetComponent<Text>().text) + 1).ToString();

            Debug.Log("Room validated: " + r_target.i_correct_answer_gotten + "/" + r_target.i_correct_answer_needed);
            if(r_target.i_correct_answer_gotten == r_target.i_correct_answer_needed)
            {
                GO_canvas.GetComponent<Text>().color = new Color(0,1,0,1);
                GO_canvas.transform.GetChild(0).GetComponent<Text>().color = new Color(0, 1, 0, 1);
            }
        }
        else
        {
            Debug.Log("Room already completed by this player");
        }
    }
    public void wrong_answer(string in_s_player_id, string s_target)
    {
        _player target_player = list_player.Find(p => p.s_player_id == in_s_player_id);

        if (!target_player.list_string_completed_rooms.Contains(s_target))
        {
            target_player.list_string_completed_rooms.Add(s_target);
            _room r_target = list_room.Find(r => r.s_room_id == s_target);
            r_target.i_incorrect_answer_gotten++;

            GameObject GO_canvas = list_GO_canvas.Find(go => go.name == s_target);
            GO_canvas.transform.GetChild(2).GetComponent<Text>().text = (int.Parse(GO_canvas.transform.GetChild(2).GetComponent<Text>().text) + 1).ToString();
        }
        else
        {
            Debug.Log("Room already completed by this player");
        }
    }
}

public class _player
{
    public string s_player_id;
    public GameObject GO_player;
    public GameObject GO_goal;
    public List<string> list_string_completed_rooms = new List<string>();
    public List<string> list_string_correct_rooms = new List<string>();
    public _room cur_room;
}

public class _room
{
    public string s_room_id;
    public GameObject GO_room;
    public int i_max_player_in;
    public int i_cur_number_player;

    public int i_correct_answer_needed = 10;
    public int i_correct_answer_gotten = 0;
    public int i_incorrect_answer_gotten = 0;
}