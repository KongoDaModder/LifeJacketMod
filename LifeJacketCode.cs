using System;
using BepInEx;
using UnityEngine;
using UnityEngine.InputSystem;
using Utilla;

namespace GorillaTagModTemplateProject
{
	/// <summary>
	/// This is your mod's main class.
	/// </summary>

	/* This attribute tells Utilla to look for [ModdedGameJoin] and [ModdedGameLeave] */
	[ModdedGamemode]
	[BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
	[BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
	public class Plugin : BaseUnityPlugin
	{
		bool inRoom;

		void Start()
		{
			/* A lot of Gorilla Tag systems will not be set up when start is called /*
			/* Put code in OnGameInitialized to avoid null references */

			Utilla.Events.GameInitialized += OnGameInitialized;
		}

		void OnEnable()
		{
			bool enable = GorillaLocomotion.Player.Instance.HeadInWater;
			if (enable)
			{
				Physics.gravity = new Vector3(0f, 9.81f, 0f)
			}
			if (enable) = false;
			{
                Physics.gravity = new Vector3(0f, -9.81f, 0f)
            }
			HarmonyPatches.ApplyHarmonyPatches();
		}

		void OnDisable()
		{
			{
                Physics.gravity = new Vector3(0f, -9.81f, 0f)
            }
            HarmonyPatches.RemoveHarmonyPatches();
		}

		void OnGameInitialized(object sender, EventArgs e)
		{
			/* Code here runs after the game initializes (i.e. GorillaLocomotion.Player.Instance != null) */
		}

		void Update()
		{
			/* Code here runs every frame when the mod is enabled */
		}

		/* This attribute tells Utilla to call this method when a modded room is joined */
		[ModdedGamemodeJoin]
		public void OnJoin(string gamemode)
		{
			inRoom = true;
		}

		/* This attribute tells Utilla to call this method when a modded room is left */
		[ModdedGamemodeLeave]
		public void OnLeave(string gamemode)
		{
			inRoom = false;
		}
	}
}
