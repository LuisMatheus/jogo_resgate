using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : TacticsMove 
{
    public int level = 1;

    public int health = 50;
    public int mana;

    public int healthRegen;
    public int manaRegen;

    public int strenght = 5;
    public int agility;
    public int luck;

    public int initiative;
    public int precision;
    public int armor;

    public int move = 5;

    public override void NewTurn()
    {
        move += 2;
    }

    // Use this for initialization
    void Start () 
	{
        Init();
	}
	
	// Update is called once per frame
	void Update () 
	{
        Debug.DrawRay(transform.position,transform.forward);

        if (!turn)
        {
            return;
        }

        if (!moving)
        {
			FindSelectableTiles(move);
            CheckMouse();
            
        }
        else
        {
            
            Move(move);
            
        }

		void CheckMouse()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit hit;
                if (Physics.Raycast(ray,out hit))
                {
                    if (hit.collider.tag == "Tile")
                    {
                        Tile t = hit.collider.GetComponent<Tile>();
                        

                        if (t.selectable)
                        {
                            MoveToTile(t);
                            move -= getDistance();

                        }
                    }

                }
            }
        }

		
	}

    

}
