using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

[CustomEditor(typeof(SliderMenu))]
[System.Serializable]
public class GeneralSettings : Editor{

	public override void OnInspectorGUI(){
		serializedObject.Update ();
		SliderMenu MySliderMenu = (SliderMenu)target;


		//-----------------------------------------------------------------------------------------------------------
		//Canvas Settings
		GUI.backgroundColor = Color.cyan;
		EditorGUILayout.HelpBox ("Canvas Settings",MessageType.Info);
		GUI.backgroundColor = Color.white;

		GUI.enabled = false;
		MySliderMenu.YourCanvas = EditorGUILayout.ObjectField ("Canvas (Pro)",MySliderMenu.YourCanvas,typeof(Canvas),true) as Canvas;
		MySliderMenu.SlidesInView = EditorGUILayout.IntField ("Slides In View (Pro)",MySliderMenu.SlidesInView);
		GUI.enabled = true;
		//-----------------------------------------------------------------------------------------------------------


		//-----------------------------------------------------------------------------------------------------------
		//ScrollBar Settings
		GUI.backgroundColor = Color.cyan;
		EditorGUILayout.HelpBox ("ScrollBar Settings",MessageType.Info);
		GUI.backgroundColor = Color.white;
		MySliderMenu.Enable_Show_ScrollBar = EditorGUILayout.Toggle ("Show ScrollBar",MySliderMenu.Enable_Show_ScrollBar);
		EditorGUILayout.PropertyField(serializedObject.FindProperty("HorizontalScrollBar"), true);
		GUI.enabled = false;
		MySliderMenu.ShowButtons = EditorGUILayout.Toggle ("Show Buttons (Pro)",MySliderMenu.ShowButtons);
		if (MySliderMenu.ShowButtons==true) {
			MySliderMenu.ButtonSprite = EditorGUILayout.ObjectField ("Button Sprite",MySliderMenu.ButtonSprite,typeof(Sprite),true) as Sprite;
		}
		GUI.enabled = true;
		//-----------------------------------------------------------------------------------------------------------



		//-----------------------------------------------------------------------------------------------------------
		//Content Settings
		GUI.backgroundColor = Color.cyan;
		EditorGUILayout.HelpBox ("Content Settings",MessageType.Info);
		GUI.backgroundColor = Color.white;
		MySliderMenu.Background = EditorGUILayout.ObjectField ("Background",MySliderMenu.Background,typeof(Sprite),true) as Sprite;
		EditorGUILayout.PropertyField(serializedObject.FindProperty("ScrollContent"), true);
		EditorGUILayout.PropertyField(serializedObject.FindProperty("LevelThumbnails"),new GUIContent("Slides (Manual Selection In Free Version)"), true);
		//-----------------------------------------------------------------------------------------------------------



		//-----------------------------------------------------------------------------------------------------------
		//Slides Info Settings
		GUI.backgroundColor = Color.cyan;
		EditorGUILayout.HelpBox ("Slides Settings",MessageType.Info);
		GUI.backgroundColor = Color.white;
		GUI.enabled = false;
		MySliderMenu.SlidesNamePrefix = EditorGUILayout.TextField ("Prefix Name (Pro)",MySliderMenu.SlidesNamePrefix);
		GUI.enabled = true;
		MySliderMenu.Element_Width = EditorGUILayout.FloatField ("Element Width",MySliderMenu.Element_Width);
		MySliderMenu.Element_Height = EditorGUILayout.FloatField ("Element Height",MySliderMenu.Element_Height);
		MySliderMenu.Element_Margin = EditorGUILayout.FloatField ("Margin",MySliderMenu.Element_Margin);
		MySliderMenu.Element_Scale = EditorGUILayout.FloatField ("Scale",MySliderMenu.Element_Scale);
		//-----------------------------------------------------------------------------------------------------------





		//-----------------------------------------------------------------------------------------------------------
		//Transition Settings
		GUI.backgroundColor = Color.cyan;
		EditorGUILayout.HelpBox ("Transition Settings",MessageType.Info);
		GUI.backgroundColor = Color.white;
		GUI.enabled = false;
		MySliderMenu.Transition_In = EditorGUILayout.FloatField ("Transition In (Pro)",MySliderMenu.Transition_In);
		MySliderMenu.Transition_Out = EditorGUILayout.FloatField ("Transition Out (Pro)",MySliderMenu.Transition_Out);
		EditorGUILayout.PropertyField(serializedObject.FindProperty("PreviousSlideColor"),new GUIContent("Previous Slide Color (Pro)"), true);
		EditorGUILayout.PropertyField(serializedObject.FindProperty("ActiveSlideColor"),new GUIContent("Active Slide Color (Pro)"), true);
		EditorGUILayout.PropertyField(serializedObject.FindProperty("NextSlideColor"),new GUIContent("Next Slide Color (Pro)"), true);
		GUI.enabled = true;
		//-----------------------------------------------------------------------------------------------------------


		//-----------------------------------------------------------------------------------------------------------
		//Desktop Platform Enable Or Disable
		GUI.backgroundColor = Color.cyan;
		EditorGUILayout.HelpBox ("Platform Settings",MessageType.Info);
		GUI.backgroundColor = Color.white;
		MySliderMenu.DesktopPlatform = EditorGUILayout.Toggle ("Desktop Platform",MySliderMenu.DesktopPlatform);
		//-----------------------------------------------------------------------------------------------------------


		serializedObject.ApplyModifiedProperties();

	}


}
