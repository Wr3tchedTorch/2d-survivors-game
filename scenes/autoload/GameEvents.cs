using Godot;
using System;

public partial class GameEvents : Node
{
	[Signal]
	public delegate void ExperienceVialCollectedEventHandler(double number);

	public void EmitExperienceVialCollected(double number)
	{
		EmitSignal(SignalName.ExperienceVialCollected, number);
	}
}
