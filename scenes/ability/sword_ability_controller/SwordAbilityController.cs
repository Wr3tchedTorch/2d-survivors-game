using Godot;
using System;
using System.Linq;

public partial class SwordAbilityController : Node
{
	[Export]
	public PackedScene SwordAbility;
	private const int _MAX_RANGE = 150;

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

		if (enemies.Count() == 0) return;

		enemies.OrderBy((Node2D enemy) => enemy.GlobalPosition.DistanceSquaredTo(player.GlobalPosition));

		var swordInstance = SwordAbility.Instantiate<Node2D>();
		player.GetParent().AddChild(swordInstance);
		swordInstance.GlobalPosition = enemies.First().GlobalPosition;
	}
}
