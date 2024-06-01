using Godot;
using System;

public partial class EnemyManager : Node
{
	[Export]
	public PackedScene basicEnemyScene;

	const int SPAWN_RADIUS = 375;
	public override void _Ready()
	{
		GetNode<Timer>("Timer").Timeout += OnTimerTimeout;
	}

	private void OnTimerTimeout()
	{
		var player = (Node2D) GetTree().GetFirstNodeInGroup("player");
		if (player == null) return;

		var randomDirection = Vector2.Right.Rotated((float)(new Random().NextDouble() * Math.Tau));
		var spawnPosition = player.GlobalPosition + (randomDirection * SPAWN_RADIUS);

		var enemy = (Node2D) basicEnemyScene.Instantiate();
		GetParent().AddChild(enemy);
		enemy.GlobalPosition = spawnPosition;
	}
}
