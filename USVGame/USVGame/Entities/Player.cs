using System;
using System.Collections.Generic;
using System.Text;
using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;
using FlatRedBall.Math.Geometry;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace USVGame.Entities
{
	public partial class Player
	{
		/// <summary>
		/// Initialization logic which is executed only one time for this Entity (unless the Entity is pooled).
		/// This method is called when the Entity is added to managers. Entities which are instantiated but not
		/// added to managers will not have this method called.
		/// </summary>
		private void CustomInitialize()
		{
			
		}

		partial void CustomInitializeTopDownInput()
		{
			MovementInput = new Multiple2DInputs().Or(InputManager.Keyboard.Get2DInput(
				Keys.Left,
				Keys.Right,
				Keys.Up,
				Keys.Down
			).Or(InputManager.Keyboard.Get2DInput(
				Keys.A,
				Keys.D,
				Keys.W,
				Keys.S
			 )));
		}

		private void CustomActivity()
		{
			
		}

		private void CustomDestroy()
		{
			
		}

		private static void CustomLoadStaticContent(string contentManagerName)
		{
			
		}
	}
}
