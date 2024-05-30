using Godot;
using System;

public partial class BasicEnemy : CharacterBody2D
{
	private const int _MAX_SPEED = 75;

	public override void _Process(double delta)
	{
		Velocity = GetDirectionToPlayer() * _MAX_SPEED;
		MoveAndSlide();
	}

	public Vector2 GetDirectionToPlayer() {
		var playerNode = (Node2D) GetTree().GetFirstNodeInGroup("player");
		if (playerNode == null) return Vector2.Zero;
				
		return (playerNode.GlobalPosition - GlobalPosition).Normalized();
	}
}
