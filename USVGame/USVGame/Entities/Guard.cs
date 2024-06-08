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
using USVGame.TopDown;

namespace USVGame.Entities
{
    public partial class Guard
    {
		TopDownAiInput<Guard> topDownAiInput;

		/// <summary>
		/// Initialization logic which is executed only one time for this Entity (unless the Entity is pooled).
		/// This method is called when the Entity is added to managers. Entities which are instantiated but not
		/// added to managers will not have this method called.
		/// </summary>
		private void CustomInitialize()
        {
			topDownAiInput = new TopDownAiInput<Guard>(this);

			// This helps us visualize the path the EnemyBase takes to get to
			// the player
			topDownAiInput.IsPathVisible = true;
			// Use a darker color so it stands out over the bright level tiles
			//topDownAiInput.PathColor = Color.Purple;
			this.InitializeTopDownInput(topDownAiInput);

		}

        private void CustomActivity()
        {
			// initialize it to a large negative number so the path updates immediately
			double lastTimePathUpdates = -999;
			// how often the path should update. We do this to improve performance
			double pathUpdateFrequency = 1;

			if (TimeManager.CurrentScreenSecondsSince(lastTimePathUpdates) > pathUpdateFrequency)
			{
				lastTimePathUpdates = TimeManager.CurrentScreenTime;
				topDownAiInput.UpdatePath();
			}
			// We only call UpdatePath once every second since that doesn't need
			// to update too requently, but this should be called every frame so the
			// enemy's movement values are updated according to its path.
			topDownAiInput.DoTargetFollowingActivity();
		}

        private void CustomDestroy()
        {
			
        }

        private static void CustomLoadStaticContent(string contentManagerName)
        {
			
        }

        public void InitializePathfinding(Player player, TileNodeNetwork nodeNetwork)
        {
			topDownAiInput.FollowingTarget = player;
			topDownAiInput.NodeNetwork = nodeNetwork;
		}
    }
}
