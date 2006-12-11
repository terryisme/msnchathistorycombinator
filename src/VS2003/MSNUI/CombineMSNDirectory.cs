using System;
using MSNMessageLibrary;
namespace MSNChatCombinator
{
	/// <summary>
	/// CombineMSNDirectory, is to combine 2 both MSN directory.
	/// </summary>
	/// <remarks>
	/// It will  fit to 2 cases:
	/// 1. Directory and directory
	/// 2. Directory and file
	/// </remarks>
   public  class CombineMSNDirectory
	{
		private string  m_strPath1;
		private string m_strPath2;
		private MSNSourceType m_type1;
	    private MSNSourceType m_type2;
		public CombineMSNDirectory(string path1,string path2)
		{
			m_strPath1=path1;
			m_strPath2=path2;

		}

	   /// <summary>
	   /// To get the type of source type.
	   /// </summary>
	   /// <remarks>
	   /// How to check
	   /// </remarks>
	   public MSNSourceType DigSourceType(string path)
	   {
		   return MSNSourceType.Directory;
	   }

	   
	}

	/// <summary>
	/// Indicates MSN source type.
	/// </summary>
	public enum MSNSourceType
	{
		Directory,
		File
	}
}
