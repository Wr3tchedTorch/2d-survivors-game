using Godot;
using System;

public partial class Player : CharacterBody2D
{
	private const int _MAX_SPEED = 200;

	public override void _Process(double delta)
	{
		Vector2 dir = GetMovementVector().Normalized();
		Velocity = dir * _MAX_SPEED;
		MoveAndSlide();
	}

	public Vector2 GetMovementVector() => Input.GetVector("move_left", "move_right", "move_up", "move_down");
}
