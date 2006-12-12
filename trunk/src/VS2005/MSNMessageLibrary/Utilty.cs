using System;

namespace MSN.Core.Message
{
	/// <summary>
	/// The constant of every style
	/// </summary>
	public struct Style
	{
		/// <summary>
		/// Default text style
		/// </summary>
		public const string DEFAULT_TEXT_STYLE="font-family:����; color:#000000; ";
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

	/// <summary>
	/// Indicates MSN source type.
	/// </summary>
	public enum MSNSourceType
	{
		/// <summary>
		/// Directory
		/// </summary>
		Directory,

		/// <summary>
		/// File
		/// </summary>
		File
	}
}