using System.IO.IsolatedStorage;
using Godot;

namespace BombArena.Scenes.Bomb;

public partial class Bomb : RigidBody3D
{
	private float _timerExplosion;
	private bool _isExploding;
	private float _explosionRadius = 6.28f;
	private float _explosionDamage = 1f;
	private float _explosionDuration = 0.5f;
	private float _explosionRange = 3f;

	//public void Explode()
	//{
	//	_isExploding = true;
	//	if (CollisionShape3D.)
	//	{
	//		// Create an explosion effect here (e.g., play an animation, spawn particles, etc.)
	//		// You can also apply damage to nearby objects based on the explosion radius and damage.
	//		// For example, you can use a physics query to find nearby objects and apply damage to them.
	//		// After the explosion effect is done, you can remove the bomb from the scene.
	//	}
	//}

	public override void _Process(double delta)
	{
		if (_isExploding)
		{
			_explosionDuration -= (float)delta;
			if (_explosionDuration <= 0)
			{
				QueueFree(); // Remove the bomb after the explosion duration
			}
			return;
		}
	}

	public override void _Ready()
	{
		_isExploding = false;
		_timerExplosion = 1.5f; // Set the timer for 1.5 seconds
	}
}
