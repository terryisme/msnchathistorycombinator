using System;
using System.IO;
using System.Collections;
using MSN.Core.Message;
namespace MSN.Core
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
		private MSNFILESTRUCT  m_path1;
		private MSNFILESTRUCT m_path2;
	    private MSNFILESTRUCT m_savedPath; 
	    private string m_strExceptionDuringProcess=string.Empty;
	    private string m_strXslPath;
	    MSN.Core.MSNDocumentCombine.SetProgressText  m_spt;

	   /// <summary>
	   /// Construction.
	   /// </summary>
	   /// <param name="path1">The path of file/directory 1.</param>
	   /// <param name="path2">The path of file/directory 2</param>
	   /// <param name="savedPath">The saved path.</param>
	   /// <param name="XslPath">The XSL file path.</param>
		public CombineMSNDirectory(MSNFILESTRUCT path1,MSNFILESTRUCT path2,MSNFILESTRUCT savedPath,string XslPath):this(path1,path2,savedPath)
		{
			m_strXslPath=XslPath;			
		}

	   /// <summary>
	   /// Construction.
	   /// </summary>
	   /// <param name="path1">The path of file/directory 1.</param>
	   /// <param name="path2">The path of file/directory 2</param>
	   /// <param name="savedPath">The saved path.</param>
	   public CombineMSNDirectory(MSNFILESTRUCT path1,MSNFILESTRUCT path2,MSNFILESTRUCT savedPath)
	   {
		   m_path1=path1;
		   m_path2=path2;
		   m_savedPath=savedPath;
	   }

	   private void ProcessMSNFile()
	   {
		   	MSNDocumentCombine chatDoc=new MSNDocumentCombine();
		   	chatDoc.OnSetProgressText=this.m_spt;		
		   	chatDoc.XSLFilePathSrc=this.m_strXslPath;
		   	chatDoc.FirstDocument=m_path1;			
		   	chatDoc.SecondDocument=m_path2;
		    chatDoc.SavedDocument=m_savedPath;
		   	chatDoc.Combine();
		   
	   }

	   /// <summary>
	   /// To process and combine MSN chat  histories.
	   /// </summary>
	   /// <returns>
	   /// Return true if success, otherwise false.
	   /// </returns>
	   public bool Process()
	   {
		   if(!Check()) return false;

		   //If the saved path is File type, it proves that all items to combine are of File type.
		   //So it is need to combine, rather than move the file only
		   if(m_savedPath.SourceType==MSNSourceType.File)
		   {
			  ProcessMSNFile();
			   return true;
		   }

		   //step1:Read the files information and put them into a hash table,
		   //where key is the file name, and the value is a tag to indicate whether or not  the file is processed.
		   //if the value is true, it indicates that it is already handled.otherwise no.
		   Hashtable htPath1=new Hashtable();
		   Hashtable htPath2=new Hashtable();

		   //Step1.1 Iterate the path1. process when only directory
		   if(MSNSourceType.Directory== m_path1.SourceType)
			   htPath1=GetSubFiles(m_path1.Path);
		   else
			   htPath1.Add(m_path1.Path,false);

		   //Step1.2 Iterate path2
		   if(MSNSourceType.Directory==m_path2.SourceType)
			   htPath2=GetSubFiles(m_path2.Path);
		   else
			   htPath2.Add(m_path2.Path,false);

		   string pathDir1=m_path1.Path;
		   if(m_path1.SourceType==MSNSourceType.File)
		   {
			   pathDir1=new FileInfo(m_path1.Path).DirectoryName;
		   }
		   string pathDir2=m_path2.Path;
		   if(m_path2.SourceType==MSNSourceType.File)
		   {
			   pathDir2=new FileInfo(m_path2.Path).DirectoryName;
		   }

		   //Step2:Compare and combine

		   //Step2.1 Process the files in path1
		   ProcessMSNDirectory(htPath1,htPath2,pathDir2);

		   //Step2.2 Porcess the files in Path2
		   ProcessMSNDirectory(htPath2,htPath1,pathDir1);
		   return true;
	   }


	   /// <summary>
	   /// To validate files/directories
	   /// </summary>
	   /// <returns></returns>
	   private bool Check()
	   {
		   if(m_path1.Path==null||m_path1.Path==string.Empty)
		   {
			   m_strExceptionDuringProcess=  "The path 1 is empty!";
			   return false;
		   }

		   if(m_path2.Path==null||m_path2.Path==string.Empty)
		   {
			   m_strExceptionDuringProcess= "The path 2 is empty";
			   return false;
		   }

		   if(m_savedPath.Path==null||m_savedPath.Path==string.Empty)
		   {
			   m_strExceptionDuringProcess= "The saved path is empty";
			   return false;
		   }
		   
		  return IsExisting(m_path1.Path)&&IsExisting(m_path2.Path);
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
				   if(m_savedPath.SourceType==MSNSourceType.Directory)
				   {
					   docCombine.SavedDocument.Path=m_savedPath.Path+"\\"+new FileInfo(aKey.ToString()).Name;
				   }
				   else
					    docCombine.SavedDocument.Path=new FileInfo(m_savedPath.Path).DirectoryName+"\\"+new FileInfo(aKey.ToString()).Name;

				   docCombine.OnSetProgressText=m_spt;
				   docCombine.Combine();
				   htCompare[compareDir+"\\"+new FileInfo(aKey.ToString()).Name]=true;
				  // htTable[aKey]=true;
			   }
			   else// if not found in compared directory, save directly
			   {
				   if(!Directory.Exists(m_savedPath.Path))
					   Directory.CreateDirectory(m_savedPath.Path);
				   try
				   {
					   if(string.Compare(aKey.ToString(),m_savedPath.Path+"\\"+new FileInfo(aKey.ToString()).Name,true)!=0)
						   File.Copy(aKey.ToString(),m_savedPath.Path+"\\"+new FileInfo(aKey.ToString()).Name,true);
				   }
				   catch 
				   {
				   	
				   }
				  
			   }

		   }

	   }
	
	   /// <summary>
	   /// A delegate . 
	   /// To set the progress text to display for users.
	   /// </summary>
	   public MSN.Core.MSNDocumentCombine.SetProgressText OnSetProgressText
	   {
		   get
		   {
			   return this.m_spt;
		   }
		   set
		   {
			   this.m_spt=value;
		   }
	   }
	}



}
