using Godot;
using System;

public partial class VialDropComponent : Node
{

	[Export(PropertyHint.Range, ("0,1"))]
	public double VialPercent = .5;
	[Export]
	public HealthComponent HealthComponent;
	[Export]
	public PackedScene VialScene;
	public override void _Ready()
	{
		HealthComponent.Died += OnDied;
	}

	public void OnDied()
	{
		if (new Random().NextDouble() > VialPercent) return;

		if (VialScene == null || Owner is not Node2D) return;

		var spawnPosition = (Owner as Node2D).GlobalPosition;
		var vialInstance = (Node2D)VialScene.Instantiate();

		Owner.GetParent().AddChild(vialInstance);
		vialInstance.GlobalPosition = spawnPosition;
	}
}
