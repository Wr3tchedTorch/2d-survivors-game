using Godot;
using System;

public partial class SwordAbility : Node2D
{	
	public HitboxComponent HitboxComponent;
	public override void _Ready() => HitboxComponent = GetNode<HitboxComponent>("HitboxComponent");	
}
