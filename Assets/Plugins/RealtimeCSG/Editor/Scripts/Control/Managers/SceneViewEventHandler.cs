﻿using UnityEngine;
using UnityEditor;
using InternalRealtimeCSG;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;
using System.Linq;
using UnityEngine.SceneManagement;

namespace RealtimeCSG
{
	internal sealed class SceneViewEventHandler
	{
		static bool mousePressed;

		internal static void OnScene(SceneView sceneView)
		{
			if (!RealtimeCSG.CSGSettings.EnableRealtimeCSG)
				return;

			UpdateLoop.UpdateOnSceneChange();
			if (EditorApplication.isPlayingOrWillChangePlaymode)
				return;

			if (Event.current.type == EventType.Repaint &&
				!ColorSettings.isInitialized)
				ColorSettings.Update();

			if (!UpdateLoop.IsActive())
				UpdateLoop.ResetUpdateRoutine();

			if (Event.current.type == EventType.MouseDown ||
				Event.current.type == EventType.MouseDrag) { mousePressed = true; }
			else if (Event.current.type == EventType.MouseUp ||
				Event.current.type == EventType.MouseMove) { mousePressed = false; }
			
			SceneDragToolManager.OnHandleDragAndDrop(inSceneView: true);
			RectangleSelectionManager.Update(sceneView);
			EditModeManager.InitSceneGUI(sceneView);

			if (Event.current.type == EventType.Repaint)
				MeshInstanceManager.RenderHelperSurfaces(sceneView); 

			if (Event.current.type == EventType.Repaint)
			{
				SceneToolRenderer.OnPaint(sceneView);
			} else
			//if (fallbackGUI)
			{
				SceneViewBottomBarGUI.ShowGUI(sceneView);
			}
			
			EditModeManager.OnSceneGUI(sceneView);

			//if (fallbackGUI)
			{
				TooltipUtility.InitToolTip(sceneView);
				if (Event.current.type == EventType.Repaint)
				{
					SceneViewBottomBarGUI.ShowGUI(sceneView);
				}
				if (!mousePressed)
				{
					Handles.BeginGUI();
					TooltipUtility.DrawToolTip(getLastRect: false);
					Handles.EndGUI();
				}
			}
		}
	}
}