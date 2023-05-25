using Godot;
using System;

public class Player : KinematicBody2D
{
	[Export]
	public int speed;
	
	private Vector2 trans;
	public Vector2 Trans 
	{
		get {return trans;}
		set {trans = value;}
	}
	
	private bool moving;
	public bool Moving 
	{
		get {return moving;}
		set {moving = value;}
	}
	
	public override void _Ready()
	{
		trans = new Vector2(1, 0);
	}

	public void PromeniSmer(Vector2 smer)
	{
		trans = smer;
	}

	public override void _Process(float delta)
	{
		if (moving)
		{
			MoveAndSlide(trans * speed);	
		}
	}
}
