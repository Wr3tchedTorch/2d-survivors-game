using Godot;
using System;

public partial class Player : CharacterBody2D
{
	private const int _MAX_SPEED = 125;
	private const int ACCELERATION_SMOOTHING = 25;

	public override void _Process(double delta)
	{
		Vector2 dir = GetMovementVector().Normalized();
		var target_velocity = dir * _MAX_SPEED;
		Velocity = Velocity.Lerp(target_velocity, (float)(1 - Math.Exp(-delta * ACCELERATION_SMOOTHING)));
		MoveAndSlide();
	}

	public Vector2 GetMovementVector() => Input.GetVector("move_left", "move_right", "move_up", "move_down");
}
