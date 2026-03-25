using Godot;

namespace BombArena.Scenes.Player;

public partial class Player : CharacterBody3D
{
	private float _baseSpeed = 2.0f;
	private float _maxSpeed = 4.0f;
	private float _speedGrowth = 0.02f;
	private float _elapsedTime = 0.0f;
	private float _rotationSpeed = 8.0f;
	private AnimationPlayer _animationPlayer;

	private float GetCurrentSpeed()
	{
		return Mathf.Min(_baseSpeed + _elapsedTime * _speedGrowth, _maxSpeed);
	}

	private Vector3 GetInputDirection()
	{
		Vector3 direction = Vector3.Zero;
		if (Input.IsActionPressed("move_forward"))
		{
			direction += Vector3.Forward;
			_animationPlayer.Play("walk");
		}
		if (Input.IsActionPressed("move_backward"))
		{
			direction += Vector3.Back;
			_animationPlayer.Play("walk");
		}
		if (Input.IsActionPressed("move_left"))
		{
			direction += Vector3.Left;
			_animationPlayer.Play("walk");
		}
		if (Input.IsActionPressed("move_right"))
		{
			direction += Vector3.Right;
			_animationPlayer.Play("walk");
		}
		if (direction == Vector3.Zero)
		{
			_animationPlayer.Play("idle");
		}
		return direction.Normalized();
	}

	private void VelocityUpdate(double delta)
	{
		_elapsedTime += (float)delta;
		Velocity = GetCurrentSpeed() * GetInputDirection();
	}

	private void RotatePlayer(Vector3 direction, double delta)
	{
		if (direction != Vector3.Zero)
		{
			float targetAngle = Mathf.Atan2(direction.X, direction.Z);
			float newY = Mathf.LerpAngle(Rotation.Y, targetAngle, (float)delta * _rotationSpeed);
			Rotation = new Vector3(Rotation.X, newY, Rotation.Z);
		}
	}

	public void GravityUpdate(double delta)
	{
		if (!IsOnFloor())
		{
			float gravity = (float)ProjectSettings.GetSetting("physics/3d/default_gravity") * 30f;
			Vector3 gravityDirection = ProjectSettings
				.GetSetting("physics/3d/default_gravity_vector")
				.AsVector3();

			Velocity += gravityDirection * gravity * (float)delta;
		}
	}
	public override void _PhysicsProcess(double delta)
	{
		VelocityUpdate(delta);
		RotatePlayer(GetInputDirection(), delta);
		GravityUpdate(delta);
		MoveAndSlide();
	}

	public override void _Ready()
	{
		_animationPlayer = GetNode < AnimationPlayer >("AnimationPlayer");
	}
}
