using TMPro;
using UnityEditor;
using UnityEditor.Presets;
using UnityEngine.UI;

namespace Kogane.Internal
{
	internal static class TextMeshProUGUIContextMenu
	{
		private const string MENU_ITEM_NAME = "CONTEXT/TextMeshProUGUI/Add ContentSizeFitter";

		[MenuItem( MENU_ITEM_NAME )]
		private static void AddContentSizeFitter( MenuCommand command )
		{
			var textMeshProUGUI   = ( TextMeshProUGUI ) command.context;
			var gameObject        = textMeshProUGUI.gameObject;
			var contentSizeFitter = Undo.AddComponent<ContentSizeFitter>( gameObject );
			var presets           = Preset.GetDefaultPresetsForObject( contentSizeFitter );

			if ( presets == null || presets.Length <= 0 ) return;

			var preset = presets[ 0 ];

			preset.ApplyTo( contentSizeFitter );
		}

		[MenuItem( MENU_ITEM_NAME, true )]
		private static bool CanAddContentSizeFitter( MenuCommand command )
		{
			var textMeshProUGUI = ( TextMeshProUGUI ) command.context;
			var contentSizeFitter = textMeshProUGUI.GetComponent<ContentSizeFitter>();

			return contentSizeFitter == null;
		}
	}
}