using System;
using System.IO.IsolatedStorage;
using Godot;

namespace BombArena.Scenes.Bomb;

public partial class Bomb : RigidBody3D
{
	private float _timerExplosion = 3f;
	private bool _isExploding;
	private float _explosionRadius = 6.28f;
	private int _explosionDamage = 1;
	private float _explosionDuration = 0.5f;
	private float _explosionRange = 1.5f;
	private PackedScene _bombScene;


	private void explode()
	{
		if (_isExploding)
		{		
			// Logic to apply damage to players within the explosion radius
			var players = GetTree().GetNodesInGroup("players");
			foreach (var player in players)
			{
				if (player is BombArena.Scenes.Player.Player playerNode)
				{
					float distance = GlobalPosition.DistanceTo(playerNode.GlobalPosition);
					if (distance <= _explosionRange)
					{
						playerNode.TakeDamage(_explosionDamage); // Apply damage to the player
					}
				}
			}
		}
	}
	private void RandomSpawnBomb(double delta)
	{
		if (_timerExplosion > 0 && !_isExploding)
		{
			_timerExplosion -= (float)delta;
			return;
		}
		else
		{
			var randomf = new Random();
			float spawnX = (float) randomf.Next(-62, 62) / 10f; // Random X position between -6.2 and 6.2
			float spawnZ = (float) randomf.Next(-53, 53) / 10f; // Random Z position between -5.3 and 5.3
			_isExploding = true; // Set the bomb to explode
			_timerExplosion = 0.5f; // Reset the timer for the next bomb spawn
			Bomb bomb = (Bomb) _bombScene.Instantiate(); // Create an instance of the bomb scene
			GetTree().CurrentScene.AddChild(bomb); // Add the bomb to the scene tree
			explode(); // Call the explode method to apply damage to players
			bomb.GlobalPosition = new Vector3(spawnX, 8f, spawnZ); // Set the position where you want to spawn the bomb
		}
	}

	public override void _Process(double delta)
	{
		if (_isExploding)
		{
			_explosionDuration -= (float)delta; // Decrease the explosion duration
			if (_explosionDuration <= 0)
			{
				QueueFree(); // Remove the bomb after the explosion duration
			}
		}
		else
			RandomSpawnBomb(delta);
	}

	public override void _Ready()
	{
		_bombScene = GD.Load<PackedScene>("res://scenes/bomb/bomb.tscn");
		_isExploding = false;
	}
}
