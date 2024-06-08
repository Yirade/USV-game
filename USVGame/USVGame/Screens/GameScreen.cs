using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Gui;
using FlatRedBall.Math;
using FlatRedBall.Math.Geometry;
using FlatRedBall.Localization;
using Microsoft.Xna.Framework;
using USVGame.Entities;

namespace USVGame.Screens
{
    public partial class GameScreen
    {

        void CustomInitialize()
        {

			// This foreach handles enemies created before the screen's initialize.
			foreach (var enemy in GuardList)
			{
				PrepareEnemyPathfinding(enemy);
			}
			// This event handler handles enemies created after the screen's initialize.
			Factories.GuardFactory.EntitySpawned += PrepareEnemyPathfinding;
		}

		private void PrepareEnemyPathfinding(Guard enemy)
		{
			// This assumes Player1 is already created. If your game
			// creates its Player instances later, you need to make sure
			// the Player instance has already been created before this is
			// called.
			enemy.InitializePathfinding(Player1, WalkingNodeNetwork);
		}

		void CustomActivity(bool firstTimeCalled)
		{

		}

		void CustomDestroy()
        {


        }

        static void CustomLoadStaticContent(string contentManagerName)
        {


        }

    }
}
