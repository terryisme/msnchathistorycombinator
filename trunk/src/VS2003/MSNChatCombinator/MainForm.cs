using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using MSNMessageLibrary;
namespace MSNChatCombinator
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListView listFiles;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtXSLPath;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.LinkLabel linkAdd;
		private System.Windows.Forms.LinkLabel linkChooseSavePath;
		private System.Windows.Forms.LinkLabel linkCombine;

		private int MAXCOUNT=0;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtSavePath;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItemAdd;
		private System.Windows.Forms.MenuItem menuItemEdit;
		private System.Windows.Forms.MenuItem menuItemDelete;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.ColumnHeader No;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.Label label7;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MainForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.listFiles = new System.Windows.Forms.ListView();
			this.No = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.menuItemAdd = new System.Windows.Forms.MenuItem();
			this.menuItemEdit = new System.Windows.Forms.MenuItem();
			this.menuItemDelete = new System.Windows.Forms.MenuItem();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtXSLPath = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.linkAdd = new System.Windows.Forms.LinkLabel();
			this.linkChooseSavePath = new System.Windows.Forms.LinkLabel();
			this.linkCombine = new System.Windows.Forms.LinkLabel();
			this.label5 = new System.Windows.Forms.Label();
			this.txtSavePath = new System.Windows.Forms.TextBox();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.label6 = new System.Windows.Forms.Label();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.label7 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// listFiles
			// 
			this.listFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.No,
																						this.columnHeader2,
																						this.columnHeader1});
			this.listFiles.ContextMenu = this.contextMenu1;
			this.listFiles.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.listFiles.FullRowSelect = true;
			this.listFiles.Location = new System.Drawing.Point(27, 52);
			this.listFiles.Name = "listFiles";
			this.listFiles.Size = new System.Drawing.Size(340, 104);
			this.listFiles.TabIndex = 1;
			this.listFiles.View = System.Windows.Forms.View.Details;
			this.listFiles.SelectedIndexChanged += new System.EventHandler(this.listFiles_SelectedIndexChanged);
			// 
			// No
			// 
			this.No.Text = "No";
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Type";
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Path Of MSN File";
			this.columnHeader1.Width = 340;
			// 
			// contextMenu1
			// 
			this.contextMenu1.Popup += new System.EventHandler(this.contextMenu1_Popup);
			// 
			// menuItemAdd
			// 
			this.menuItemAdd.Index = 0;
			this.menuItemAdd.Text = "Add";
			this.menuItemAdd.Click += new System.EventHandler(this.menuItemAdd_Click);
			// 
			// menuItemEdit
			// 
			this.menuItemEdit.Index = 1;
			this.menuItemEdit.Text = "Edit";
			// 
			// menuItemDelete
			// 
			this.menuItemDelete.Index = 2;
			this.menuItemDelete.Text = "Delete";
			this.menuItemDelete.Click += new System.EventHandler(this.menuItemDelete_Click);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Arial", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(7, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(413, 22);
			this.label1.TabIndex = 2;
			this.label1.Text = "Step1: List of MSN files to Combine and the save file path";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Arial", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(7, 223);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(200, 21);
			this.label2.TabIndex = 3;
			this.label2.Text = "Step 2:XSL File(MessageLog.xsl£©";
			// 
			// txtXSLPath
			// 
			this.txtXSLPath.Location = new System.Drawing.Point(87, 253);
			this.txtXSLPath.Name = "txtXSLPath";
			this.txtXSLPath.Size = new System.Drawing.Size(206, 20);
			this.txtXSLPath.TabIndex = 4;
			this.txtXSLPath.Text = "";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(27, 253);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(53, 21);
			this.label3.TabIndex = 6;
			this.label3.Text = "XSL File";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Arial", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.Location = new System.Drawing.Point(7, 275);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(140, 21);
			this.label4.TabIndex = 7;
			this.label4.Text = "Step 3: Combine";
			// 
			// linkAdd
			// 
			this.linkAdd.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.linkAdd.Location = new System.Drawing.Point(287, 163);
			this.linkAdd.Name = "linkAdd";
			this.linkAdd.Size = new System.Drawing.Size(166, 22);
			this.linkAdd.TabIndex = 8;
			this.linkAdd.TabStop = true;
			this.linkAdd.Text = "Add MSN Files to Combine";
			this.linkAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAdd_LinkClicked);
			// 
			// linkChooseSavePath
			// 
			this.linkChooseSavePath.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.linkChooseSavePath.Location = new System.Drawing.Point(300, 253);
			this.linkChooseSavePath.Name = "linkChooseSavePath";
			this.linkChooseSavePath.Size = new System.Drawing.Size(83, 21);
			this.linkChooseSavePath.TabIndex = 9;
			this.linkChooseSavePath.TabStop = true;
			this.linkChooseSavePath.Text = "Choose";
			this.linkChooseSavePath.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkChooseSavePath_LinkClicked);
			// 
			// linkCombine
			// 
			this.linkCombine.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.linkCombine.Location = new System.Drawing.Point(120, 290);
			this.linkCombine.Name = "linkCombine";
			this.linkCombine.Size = new System.Drawing.Size(144, 21);
			this.linkCombine.TabIndex = 10;
			this.linkCombine.TabStop = true;
			this.linkCombine.Text = "Click Here to Combine";
			this.linkCombine.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkCombine_LinkClicked);
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.Location = new System.Drawing.Point(7, 186);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(66, 21);
			this.label5.TabIndex = 11;
			this.label5.Text = "Path to Save";
			// 
			// txtSavePath
			// 
			this.txtSavePath.Location = new System.Drawing.Point(80, 186);
			this.txtSavePath.Name = "txtSavePath";
			this.txtSavePath.Size = new System.Drawing.Size(207, 20);
			this.txtSavePath.TabIndex = 12;
			this.txtSavePath.Text = "";
			// 
			// linkLabel1
			// 
			this.linkLabel1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.linkLabel1.Location = new System.Drawing.Point(293, 193);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(134, 21);
			this.linkLabel1.TabIndex = 13;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Choose the Path to Save";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label6.Location = new System.Drawing.Point(13, 30);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(134, 21);
			this.label6.TabIndex = 14;
			this.label6.Text = "List of MSN Chat Files";
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItemAdd,
																					  this.menuItemEdit,
																					  this.menuItemDelete});
			this.menuItem1.Text = "ListFile";
			// 
			// statusBar1
			// 
			this.statusBar1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.statusBar1.Location = new System.Drawing.Point(0, 314);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Size = new System.Drawing.Size(480, 20);
			this.statusBar1.TabIndex = 15;
			// 
			// label7
			// 
			this.label7.ForeColor = System.Drawing.Color.Red;
			this.label7.Location = new System.Drawing.Point(187, 223);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(126, 21);
			this.label7.TabIndex = 17;
			this.label7.Text = "*Required for MSN Only";
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(480, 334);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.statusBar1);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.txtSavePath);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.linkCombine);
			this.Controls.Add(this.linkChooseSavePath);
			this.Controls.Add(this.linkAdd);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtXSLPath);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.listFiles);
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "MSN Chat Histories Combination";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}


		private void linkCombine_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			ShowStatus("Check the XML files number");
			if(listFiles.Items.Count==0)
			{
				MessageBox.Show("Please choose the MSN files to combine","XML Files",
					                           MessageBoxButtons.OK,
											   MessageBoxIcon.Information);
				return;
			}
			if(listFiles.Items.Count==1)
			{
				MessageBox.Show("Only one file,more than one required!","XML Files",
					                          MessageBoxButtons.OK,
											  MessageBoxIcon.Information);
				return;
			}
			ShowStatus("Check XSL file");
			if(m_savedFileFormat==MSNChatHistoryFormat.MSN&& txtXSLPath.Text.Trim().Length==0)
			{
				MessageBox.Show("XSL file is required,or else the MSN message won't be displayed.!",
					                         "XSL Files",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);
				return;
			}
			ShowStatus("Check the saved path");
			if(txtSavePath.Text.Trim().Length==0)
			{
				MessageBox.Show("Please choose a path to save MSN message.","Invalidation",
					                         MessageBoxButtons.OK,
											 MessageBoxIcon.Information);
				return;
			}
			this.ShowControls(false);
			ShowStatus("Check MSN files validation");
			if(!this.CheckMSNFilesValidation())
			{
				this.ShowControls(true);
				return;
			}
			ShowStatus("Check XSL file validation");
			if(m_savedFileFormat==MSNChatHistoryFormat.MSN&&
		    	!this.CheckXslFile())
			{
				this.ShowControls(true);
				return;
			}
            
			ShowStatus("Start combining");
			MSNDocumentCombine chatDoc=new MSNDocumentCombine();
			chatDoc.OnSetProgressText=new MSNMessageLibrary.MSNDocumentCombine.SetProgressText(ShowStatus);

			//chatDoc.FirstDocumentPath=listFiles.Items[0].SubItems[2].Text;
			//chatDoc.SecondDocumentPath=listFiles.Items[1].SubItems[2].Text;
			//chatDoc.SavedDocumentPath=this.txtSavePath.Text;
			
			chatDoc.XSLFilePathSrc=this.txtXSLPath.Text;

			chatDoc.FirstDocument.Path=listFiles.Items[0].SubItems[2].Text;
			chatDoc.FirstDocument.Format=this.GetFileFormat(listFiles.Items[0].SubItems[1].Text);
			chatDoc.SecondDocument.Path=listFiles.Items[1].SubItems[2].Text;
			chatDoc.SecondDocument.Format=this.GetFileFormat(listFiles.Items[1].SubItems[1].Text);
			chatDoc.SavedDocument.Path=this.txtSavePath.Text;
			chatDoc.SavedDocument.Format=this.m_savedFileFormat;

			//chatDoc.SavedFileFormat=m_savedFileFormat;

			ShowStatus("Start combining the first and second file");
			chatDoc.Combine();
			ShowStatus("Finish combining the first and second file");
			for(int index=2;index<listFiles.Items.Count;index++)
			{
				ShowStatus("Start combining "+index+" and "+(index+1)+" files");
				//chatDoc.FirstDocumentPath=this.txtSavePath.Text;
				//chatDoc.SecondDocumentPath=listFiles.Items[index].SubItems[2].Text;
				//chatDoc.SavedDocumentPath=this.txtSavePath.Text;

				chatDoc.FirstDocument.Path=this.txtSavePath.Text;
				chatDoc.FirstDocument.Format=this.m_savedFileFormat;

				chatDoc.SecondDocument.Path=listFiles.Items[index].SubItems[2].Text;
				chatDoc.SecondDocument.Format=this.GetFileFormat(listFiles.Items[index].SubItems[1].Text);

				chatDoc.SavedDocument.Path=this.txtSavePath.Text;
				chatDoc.SavedDocument.Format=this.m_savedFileFormat;

				chatDoc.Combine();
				ShowStatus("Finish  combining "+index+" and "+(index+1)+" files");
			}
			this.ShowControls(true);
			ShowStatus("Finished!");
			MessageBox.Show("Finished!","Finished");
			
		}

		private void linkAdd_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			this.AddXMLFile();
		}

		private void linkChooseSavePath_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			openFileDialog1.InitialDirectory = "c:\\" ;
			openFileDialog1.Filter = "XSL files (*.xsl)|*.xsl|All files (*.*)|*.*" ;
			openFileDialog1.FilterIndex = 1 ;
			openFileDialog1.RestoreDirectory = true ;
			openFileDialog1.Multiselect=true;

			if(this.openFileDialog1.ShowDialog()==DialogResult.OK)
			{
				this.txtXSLPath.Text=openFileDialog1.FileName;
			}
		}

		private MSNChatHistoryFormat m_savedFileFormat;
		private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			frmChooseFileType frmChoose=new frmChooseFileType();
			if(frmChoose.ShowDialog()!=DialogResult.Yes)
				return;
			m_savedFileFormat=frmChoose.ChatHistoryFormat;

			this.saveFileDialog1.InitialDirectory="C:\\";
			
			this.saveFileDialog1.Filter=GetOpenFileDialogFilter(m_savedFileFormat);

			this.saveFileDialog1.FilterIndex=1;
			if(this.saveFileDialog1.ShowDialog()==DialogResult.OK)
			{
				this.txtSavePath.Text=saveFileDialog1.FileName;
			}
		}

		private void contextMenu1_Popup(object sender, System.EventArgs e)
		{
		
		}

		private void menuItemAdd_Click(object sender, System.EventArgs e)
		{
			this.AddXMLFile();
		}
		private void AddXMLFile()
		{
			frmChooseFileType frmChoose=new frmChooseFileType();
			if(frmChoose.ShowDialog()!=DialogResult.Yes)
				return;
		    MSNChatHistoryFormat chooseFormat=frmChoose.ChatHistoryFormat;

			openFileDialog1.InitialDirectory = "c:\\" ;
			openFileDialog1.Filter =this.GetOpenFileDialogFilter(chooseFormat);
			openFileDialog1.FilterIndex = 1 ;
			openFileDialog1.RestoreDirectory = true ;
			openFileDialog1.Multiselect=true;

			if(this.openFileDialog1.ShowDialog()==DialogResult.OK)
			{
				
				for(int index=0;index<openFileDialog1.FileNames.Length;index++)
				{
					if(this.IsAlreadyInList(openFileDialog1.FileNames[index])) continue;
					
					MAXCOUNT++;
					ListViewItem lvi=new ListViewItem();
					lvi.Text=MAXCOUNT.ToString();
					lvi.SubItems.Add(GetFileType(chooseFormat));
					lvi.SubItems.Add(openFileDialog1.FileNames[index]);
					this.listFiles.Items.Add(lvi);	
				}
				
			}
		}
		private string GetFileType(MSNChatHistoryFormat fmt)
		{			
			string rtValue=string.Empty;
			switch (fmt)
			{
				case MSNChatHistoryFormat.MSN:
					rtValue="MSN";
					break;
				case MSNChatHistoryFormat.GaimHTML:
					rtValue="Gaim-HTML";
					break;
				case MSNChatHistoryFormat.GaimPlainText:
					rtValue="Gaim-Text";
					break;
				default:
					rtValue="MSN";
					break;
			}
			return rtValue;
		}

		private bool IsAlreadyInList(string path)
		{
			for(int n=0;n<listFiles.Items.Count;n++)
			{
				if(path.ToLower().Equals(listFiles.Items[n].SubItems[2].Text.ToLower())) 
					return true;
			}
			return false;
		}
		private void menuItemDelete_Click(object sender, System.EventArgs e)
		{
			int index=listFiles.FocusedItem.Index;
			listFiles.Items.RemoveAt(index);
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																											this.menuItemAdd,
																											this.menuItemDelete});
			this.listFiles.ContextMenu=this.contextMenu1;

		}

		private void ShowControls(bool IsEnable)
		{
			if(IsEnable)
			{
				this.menuItemAdd.Enabled=true;
				this.menuItemDelete.Enabled=true;
				this.linkAdd.Enabled=true;
				this.linkChooseSavePath.Enabled=true;
				this.linkLabel1.Enabled=true;
				this.txtSavePath.Enabled=true;
				this.txtXSLPath.Enabled=true;
			}
			else
			{
				this.menuItemAdd.Enabled=false;
				this.menuItemDelete.Enabled=false;
				this.linkAdd.Enabled=false;
				this.linkChooseSavePath.Enabled=false;
				this.linkLabel1.Enabled=false;
				this.txtSavePath.Enabled=false;
				this.txtXSLPath.Enabled=false;
			}
		}

		/// <summary>
		/// Check whether or not the XML chat files are validate.
		/// </summary>
		/// <returns>true if validate, other false</returns>
		private bool CheckMSNFilesValidation()
		{
			int nSize=this.listFiles.Items.Count;
			if(nSize==0)return true;
			XmlDocument xml=new XmlDocument();
			for(int index=0;index<nSize;index++)
			{
			
				try
				{
					if(MSNChatHistoryFormat.MSN==this.GetFileFormat(this.listFiles.Items[index].SubItems[1].Text))
						xml.Load(this.listFiles.Items[index].SubItems[2].Text);
				}
				catch
				{
					MessageBox.Show("Please check"+this.listFiles.Items[index].SubItems[2].Text+" file, it is invalid!",
                                                "Invalid file.",
						                         MessageBoxButtons.OK,
						                         MessageBoxIcon.Information);
					return false;
				}
			}
			return true;
		}


		/// <summary>
		/// Check XSL File.
		/// </summary>
		/// <returns>true if validate, other false</returns>
		private bool CheckXslFile()
		{
			XmlDocument xml=new XmlDocument();
			try
			{
				xml.Load(this.txtXSLPath.Text);
			}
			catch
			{
				MessageBox.Show("Please check"+this.txtXSLPath.Text+" file, it is invalid!",
					"Invalid file.",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);
				return false;
			}
			return true;
		}

		private void ShowStatus(string text)
		{
			this.statusBar1.Text=text;
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
		//	MSNChatDocumentGaimPlainText path=new MSNChatDocumentGaimPlainText(@"E:\Work\MSN\confach@hotmail.com\confach@hotmail.com\leafhhou@hotmail.com\2006-10-18.163649.txt");
			//path.Load();
			//DateForm frm=new DateForm();
		//	frm.ShowDialog();
		}

		private void listFiles_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private MSNChatHistoryFormat GetFileFormat(string fmt)
		{
			if(string.Compare(fmt,"MSN",true)==0) return MSNChatHistoryFormat.MSN;
			if(string.Compare(fmt,"Gaim-HTML",true)==0) return MSNChatHistoryFormat.GaimHTML;
			if(string.Compare(fmt,"Gaim-Text",true)==0) return MSNChatHistoryFormat.GaimPlainText;
			return MSNChatHistoryFormat.MSN;
		}

		private string GetOpenFileDialogFilter(MSNChatHistoryFormat fmt)
		{
			switch (fmt)
			{
				case MSNChatHistoryFormat.MSN:
					return  "XML files (*.xml)|*.xml|All files (*.*)|*.*" ;
				case MSNChatHistoryFormat.GaimHTML:
					return "HTML (*.htm,*.html)|*.htm;*.html|All files (*.*)|*.*" ;
				case MSNChatHistoryFormat.GaimPlainText:
					return "Plain Text (*.txt)|*.txt|All files (*.*)|*.*" ;
				default:
					return "Plain Text (*.txt)|*.txt|All files (*.*)|*.*" ;
			}
		}
	}
}
