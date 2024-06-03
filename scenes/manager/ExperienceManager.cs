using Godot;
using System;

public partial class ExperienceManager : Node
{
	public double CurrentExperience { get; private set; }

	public override void _Ready()
	{
		GetNode<GameEvents>("/root/GameEvents").ExperienceVialCollected += OnExperienceVialCollected;
	}

	public void IncrementExperience(double number)
	{
		CurrentExperience += number;
		GD.Print(CurrentExperience);
	}

	public void OnExperienceVialCollected(double number)
	{
		IncrementExperience(number);
	}
}
