using Godot;
using System;

public partial class ArenaTimeUI : CanvasLayer
{
	[Export]
	public ArenaTimeManager ArenaTimeManager;
	private Label label;

	public override void _Ready()
	{
		label = GetNode<Label>("%Label");
	}

	public override void _Process(double delta)
	{
		if (ArenaTimeManager == null) return;

		var timeElapsed = ArenaTimeManager.GetTimeElapsed();
		label.Text = FormatSecondsToString(timeElapsed);
	}

	public static string FormatSecondsToString(double seconds)
	{
		var minutes = Math.Floor(seconds / 60);
		var remainingSeconds = seconds - (minutes * 60);
		return $"{minutes}:{String.Format("{0:00}", Math.Floor(remainingSeconds))}";
	}
}
