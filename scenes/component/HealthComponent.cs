using Godot;
using System;

public partial class HealthComponent : Node
{
	[Signal]
	public delegate void DiedEventHandler();

	[Export]
	public double MaxHealth = 10;
	private double CurrentHealth;

	public override void _Ready()
	{
		CurrentHealth = MaxHealth;
	}

	public void Damage(double damageAmount)
	{
		CurrentHealth = Math.Max(CurrentHealth - damageAmount, 0);		
		new Callable(this, MethodName.CheckDeath).CallDeferred();
	}

    public void CheckDeath() {
		if (CurrentHealth != 0) return;

		EmitSignal(SignalName.Died);
		Owner.QueueFree();
	}
}
