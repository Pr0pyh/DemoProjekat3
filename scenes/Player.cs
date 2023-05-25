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
	
	public override void _Ready()
	{
			
	}


	public override void _Process(float delta)
	{
		MoveAndSlide(trans * speed);
	}
}
