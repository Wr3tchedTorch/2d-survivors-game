using Godot;
using System;
using System.Linq;

public partial class SwordAbilityController : Node
{
	[Export]
	public PackedScene SwordAbility;
	private const int _MAX_RANGE = 150;
	private double Damage = 5;

	public override void _Ready()
	{
		GetNode<Timer>("Timer").Timeout += OnTimerTimeout;
	}

	public void OnTimerTimeout()
	{
		var player = (Node2D)GetTree().GetFirstNodeInGroup("player");
		if (player == null) return;

		var enemies = GetTree().GetNodesInGroup("enemy").Cast<Node2D>();
		enemies = enemies.Where(
			enemy => enemy.GlobalPosition.DistanceSquaredTo(player.GlobalPosition) < Math.Pow(_MAX_RANGE, 2));

		if (!enemies.Any()) return;

		enemies = enemies.OrderBy((Node2D enemy) => enemy.GlobalPosition.DistanceSquaredTo(player.GlobalPosition));

		var swordInstance = SwordAbility.Instantiate<SwordAbility>();
		player.GetParent().AddChild(swordInstance);
		
		swordInstance.HitboxComponent.Damage += Damage;
		
		swordInstance.GlobalPosition = enemies.First().GlobalPosition;
		swordInstance.GlobalPosition += Vector2.Right.Rotated((float)(new Random().NextDouble() * Math.Tau)) * 8;

		var enemyDirection = enemies.First().GlobalPosition - swordInstance.GlobalPosition;
		swordInstance.Rotation = enemyDirection.Angle();
	}
}
