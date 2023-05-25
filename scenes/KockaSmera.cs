using Godot;
using System;

public class KockaSmera : Area2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    [Export]
    Vector2 smerKocke;
    public enum VRSTA_KOCKE  {
        LEVO,
        DESNO,
        GORE,
        DOLE
    };
    Sprite sprite;
    VRSTA_KOCKE vrstaKocke;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        sprite = GetNode<Sprite>("Sprite");
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        
    }

    public void _on_KockaSmera_body_entered(Node2D body)
    {
        // if(body.GetType() == Player)
        // {
        //     Player player = (Player)body;
        //     player.PromeniSmer(smerKocke);
        // }
    }

    public void drugaKocka(VRSTA_KOCKE vrstaKocke)
    {
        GD.Print(vrstaKocke);
        switch(vrstaKocke)
        {
            case VRSTA_KOCKE.LEVO:
                smerKocke = new Vector2(-1, 0);
                GlobalRotation = Mathf.Deg2Rad(270);
                break;
            case VRSTA_KOCKE.DESNO:
                smerKocke = new Vector2(1, 0);
                GlobalRotation = Mathf.Deg2Rad(90);
                break;
            case VRSTA_KOCKE.GORE:
                smerKocke = new Vector2(0, -1);
                GlobalRotation = Mathf.Deg2Rad(0);
                break;
            case VRSTA_KOCKE.DOLE:
                smerKocke = new Vector2(0, 1);
                GlobalRotation = Mathf.Deg2Rad(180);
                break;
        }
    }
}
