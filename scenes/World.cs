using Godot;
using System;

public class World : Node2D
{
	//Broj kocaka koji se moze staviti
	[Export]
	int broj;
	Player player;
	//Varijabla koja ce nositi instancu scene 
	KockaSmera kockaSmera;
	//Scena na osnovu koje se instancira
	PackedScene kockaSmeraScene;
	Sprite shadowKocka;
	//pristup labeli koja pokazuje broj kocki koje su dostupne
	Label dostupanBroj;
	KockaSmera.VRSTA_KOCKE vrstaKocke;
	//Poziva se kada se napravi World scena
	public override void _Ready()
	{
		player = GetNode<Player>("Player");
		kockaSmeraScene = GD.Load<PackedScene>("res://scenes/KockaSmera.tscn");
		dostupanBroj = GetNode<CanvasLayer>("CanvasLayer").GetNode<Label>("Label");
		shadowKocka = GetNode<Sprite>("Sprite");
		GD.Print("nesto");
	}

	//Poziva se pri svakom inputu
	public override void _Input(InputEvent @event)
	{
		if(@event.IsActionPressed("mouse1") && broj > 0)
		{
			kockaSmera = (KockaSmera)kockaSmeraScene.Instance();
			AddChild(kockaSmera);
			kockaSmera.drugaKocka(vrstaKocke);
			kockaSmera.GlobalPosition = shadowKocka.GlobalPosition;
			broj--;
			dostupanBroj.Text = "Available: " + broj;
		}
		
		if (@event.IsActionPressed("move"))
		{
			player.Moving = true;
		}
		else if (@event.IsActionPressed("stop"))
		{
			player.Moving = false;
		} 
	}

	public override void _Process(float delta)
	{
		float x_round = Mathf.Ceil(GetGlobalMousePosition().x/64.0f);
		float y_round = Mathf.Ceil(GetGlobalMousePosition().y/64.0f);
		shadowKocka.GlobalPosition = new Vector2(x_round*64.0f-32.0f, y_round*64.0f-32.0f);
	}

	public void _on_Button_pressed()
	{
		vrstaKocke = KockaSmera.VRSTA_KOCKE.LEVO;
		shadowKocka.GlobalRotation = Mathf.Deg2Rad(270);
	}
	public void _on_Button2_pressed()
	{
		vrstaKocke = KockaSmera.VRSTA_KOCKE.DESNO;
		shadowKocka.GlobalRotation = Mathf.Deg2Rad(90);
	}
	public void _on_Button3_pressed()
	{
		vrstaKocke = KockaSmera.VRSTA_KOCKE.GORE;
		shadowKocka.GlobalRotation = Mathf.Deg2Rad(0);
	}
	public void _on_Button4_pressed()
	{
		vrstaKocke = KockaSmera.VRSTA_KOCKE.DOLE;
		shadowKocka.GlobalRotation = Mathf.Deg2Rad(180);
	}

	public void _on_Button5_pressed()
	{
		GetTree().ReloadCurrentScene();
	}
}
