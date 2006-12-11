using System;

namespace MSNMessageLibrary
{
	/// <summary>
	/// The constant of every style
	/// </summary>
	public struct Style
	{
		/// <summary>
		/// Default text style
		/// </summary>
		public const string DEFAULT_TEXT_STYLE="font-family:ËÎÌו; color:#000000; ";
	}

	/// <summary>
	/// MSN Chat history format 
	/// </summary>
	public enum MSNChatHistoryFormat:int
	{
		/// <summary>
		/// MSN
		/// </summary>
		MSN=0,

		/// <summary>
		/// Gaim Plain Text
		/// </summary>
		GaimPlainText=1,

		/// <summary>
		/// Gaim  HTML
		/// </summary>
		GaimHTML=2
	}
}
