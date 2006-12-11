using System;
using MSNMessageLibrary;
using System.IO;
using System.Collections;
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
	    private string m_strSavedPath; 
	    private string m_strExceptionDuringProcess=string.Empty;
	   private string m_strXslPath;

	   /// <summary>
	   /// Construction.
	   /// </summary>
	   /// <param name="path1">The path of file/directory 1.</param>
	   /// <param name="type1">The type, file or directory for path1..</param>
	   /// <param name="path2">The path of file/directory 2</param>
	   /// <param name="type2">The type of path2.</param>
		public CombineMSNDirectory(string path1,MSNSourceType type1,string path2,MSNSourceType type2,string savedPath,string XslPath)
		{
			m_strPath1=path1;
			m_strPath2=path2;
			m_type2=type2;
			m_type1=type1;
			m_strSavedPath=savedPath;
			m_strXslPath=XslPath;

			
		}

	   public bool Process()
	   {
		   if(!Check()) return false;

		   //step1:Read the files information and put them into a hash table,
		   //where key is the file name, and the value is a tag to indicate whether or not  the file is processed.
		   //if the value is true, it indicates that it is already handled.otherwise no.
		   Hashtable htPath1=new Hashtable();
		   Hashtable htPath2=new Hashtable();

		   //Step1.1 Iterate the path1. process when only directory
		   if(MSNSourceType.Directory== m_type1)
			   htPath1=GetSubFiles(m_strPath1);

		   //Step1.2 Iterate path2
		   if(MSNSourceType.Directory==m_type2)
			   htPath2=GetSubFiles(m_strPath2);

		   //Step2:Compare and combine

		   //Step2.1 Process the files in path1
		   ProcessMSNDirectory(htPath1,htPath2,m_strPath2);

		   //Step2.2 Porcess the files in Path2
		   ProcessMSNDirectory(htPath2,htPath1,m_strPath1);
		   return true;
	   }


	   /// <summary>
	   /// To validate files/directories
	   /// </summary>
	   /// <returns></returns>
	   private bool Check()
	   {
		   if(m_strPath1==null||m_strPath1==string.Empty)
		   {
			   m_strExceptionDuringProcess=  "The path 1 is empty!";
			   return false;
		   }

		   if(m_strPath2==null||m_strPath2==string.Empty)
		   {
			   m_strExceptionDuringProcess= "The path 2 is empty";
			   return false;
		   }

		   if(m_strSavedPath==null||m_strSavedPath==string.Empty)
		   {
			   m_strExceptionDuringProcess= "The saved path is empty";
			   return false;
		   }
		   
		  return IsExisting(m_strPath1)&&IsExisting(m_strPath2);
	   }

	   /// <summary>
	   /// Check the specified path is existing.
	   /// </summary>
	   /// <param name="path">The path to check</param>
	   /// <returns>
	   /// Return true if the path is valid, otherwise false 
	   /// </returns>
	   private bool IsExisting(string path)
	   {
		   return true;
	   }

	   /// <summary>
	   /// Load all files in the directory
	   /// </summary>
	   /// <param name="dirPath"></param>
	   /// <returns></returns>
	   private Hashtable GetSubFiles(string dirPath)
	   {
		   Hashtable htTable=new Hashtable();
		   try
		   {
			   string[] files=Directory.GetFiles(dirPath);
			   foreach(string aFile in files)
			   {
				   //only XML files
				  if(string.Compare( new FileInfo(aFile).Extension,".xml",true)==0)
					  htTable.Add(aFile,false);
			   }
		   }
		   catch(Exception ex)
		   {
			   m_strExceptionDuringProcess="Meets error when get files information from directory. ";
			   m_strExceptionDuringProcess+="\nDirectory:"+dirPath; 
			   m_strExceptionDuringProcess+="\nDetails:"+ex.Message;
		   }
		   return htTable;

	   }

	   private void ProcessMSNDirectory(Hashtable htTable,Hashtable htCompare,string compareDir)
	   {
		   foreach(object aKey in htTable.Keys)
		   {
			   if(Convert.ToBoolean(htTable[aKey])) continue;

			   //If not handled
			   if(htCompare.ContainsKey(compareDir+"\\"+new FileInfo(aKey.ToString()).Name))
			   {
				   if(Convert.ToBoolean(htCompare[compareDir+"\\"+new FileInfo(aKey.ToString()).Name])) continue;

				   MSNDocumentCombine docCombine=new MSNDocumentCombine();

				   //Set the first MSN file
				   docCombine.FirstDocument.Format=MSNChatHistoryFormat.MSN;
				   docCombine.FirstDocument.Path=	aKey.ToString();

				   //set the second MSN file
				   docCombine.SecondDocument.Format=MSNChatHistoryFormat.MSN;
				   docCombine.SecondDocument.Path=	aKey.ToString();

				   //Set the XSL file
				   docCombine.XSLFilePathSrc=m_strXslPath;

				   docCombine.SavedDocument.Format=MSNChatHistoryFormat.MSN;
				   docCombine.SavedDocument.Path=m_strSavedPath+"\\"+new FileInfo(aKey.ToString()).Name;

				   docCombine.OnSetProgressText=new MSNMessageLibrary.MSNDocumentCombine.SetProgressText(hello);
				   docCombine.Combine();
				   htCompare[compareDir+"\\"+new FileInfo(aKey.ToString()).Name]=true;
				  // htTable[aKey]=true;
			   }
			   else// if not found in compared directory, save directly
			   {
				   if(!Directory.Exists(m_strSavedPath))
					   Directory.CreateDirectory(m_strSavedPath);
				   File.Copy(aKey.ToString(),m_strSavedPath+"\\"+new FileInfo(aKey.ToString()).Name,true);
			   }

		   }

	   }
	   public void hello(string s)
	   {

	   }
	}



}
