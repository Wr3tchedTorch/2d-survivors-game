using Godot;
using System;

public partial class HurtboxComponent : Area2D
{
	[Export]
	HealthComponent HealthComponent;
	public override void _Ready()
	{
		AreaEntered += OnAreaEntered;
	}

	public void OnAreaEntered(Area2D otherArea)
	{
		if (otherArea is not HitboxComponent || HealthComponent == null) return;

		var hitBoxComponent = otherArea as HitboxComponent;
		HealthComponent.Damage(hitBoxComponent.Damage);
	}
}
