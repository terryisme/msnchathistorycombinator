using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using MSN.Core;
using MSN.Core.Message;
namespace MSNChatCombinator
{
	/// <summary>
	/// Summary description for frmChooseFileType.
	/// </summary>
	public class frmChooseFileType : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RadioButton rbMSN;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.RadioButton rbHTML;
		private System.Windows.Forms.RadioButton rbGaimPlain;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.RadioButton rbDir;
		private System.Windows.Forms.RadioButton rbFile;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmChooseFileType(MSNSourceType srcType):this()
		{
			if(srcType==MSNSourceType.Directory)
			  this.rbDir.Checked=true;
			if(srcType==MSNSourceType.File)
				this.rbFile.Checked=true;

		}

		public frmChooseFileType(MSNSourceType srcType, bool isForSave):this(srcType)
		{		
				this.rbFile.Enabled=!isForSave;
				this.rbDir.Enabled=!isForSave;
		}

		public frmChooseFileType()
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
				if(components != null)
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
			this.label1 = new System.Windows.Forms.Label();
			this.rbMSN = new System.Windows.Forms.RadioButton();
			this.rbGaimPlain = new System.Windows.Forms.RadioButton();
			this.btnNext = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.rbHTML = new System.Windows.Forms.RadioButton();
			this.label2 = new System.Windows.Forms.Label();
			this.rbDir = new System.Windows.Forms.RadioButton();
			this.rbFile = new System.Windows.Forms.RadioButton();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(13, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(195, 21);
			this.label1.TabIndex = 0;
			this.label1.Text = "Step1: Please choose the file type ";
			// 
			// rbMSN
			// 
			this.rbMSN.Checked = true;
			this.rbMSN.Location = new System.Drawing.Point(16, 0);
			this.rbMSN.Name = "rbMSN";
			this.rbMSN.Size = new System.Drawing.Size(87, 22);
			this.rbMSN.TabIndex = 1;
			this.rbMSN.TabStop = true;
			this.rbMSN.Text = "MSN";
			// 
			// rbGaimPlain
			// 
			this.rbGaimPlain.Location = new System.Drawing.Point(16, 24);
			this.rbGaimPlain.Name = "rbGaimPlain";
			this.rbGaimPlain.Size = new System.Drawing.Size(115, 23);
			this.rbGaimPlain.TabIndex = 2;
			this.rbGaimPlain.Text = "Gaim-Plain Text";
			// 
			// btnNext
			// 
			this.btnNext.Location = new System.Drawing.Point(24, 200);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(62, 21);
			this.btnNext.TabIndex = 3;
			this.btnNext.Text = "Next";
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(112, 200);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(62, 21);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// rbHTML
			// 
			this.rbHTML.Enabled = false;
			this.rbHTML.Location = new System.Drawing.Point(16, 48);
			this.rbHTML.Name = "rbHTML";
			this.rbHTML.Size = new System.Drawing.Size(87, 22);
			this.rbHTML.TabIndex = 5;
			this.rbHTML.Text = "Gaim-HTML";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 104);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(128, 23);
			this.label2.TabIndex = 6;
			this.label2.Text = "Step2: Source Type";
			// 
			// rbDir
			// 
			this.rbDir.Checked = true;
			this.rbDir.Location = new System.Drawing.Point(16, 8);
			this.rbDir.Name = "rbDir";
			this.rbDir.TabIndex = 7;
			this.rbDir.TabStop = true;
			this.rbDir.Text = "Directory";
			// 
			// rbFile
			// 
			this.rbFile.Location = new System.Drawing.Point(16, 32);
			this.rbFile.Name = "rbFile";
			this.rbFile.TabIndex = 8;
			this.rbFile.Text = "File";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.rbMSN);
			this.panel1.Controls.Add(this.rbGaimPlain);
			this.panel1.Controls.Add(this.rbHTML);
			this.panel1.Location = new System.Drawing.Point(24, 32);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(184, 72);
			this.panel1.TabIndex = 9;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.rbFile);
			this.panel2.Controls.Add(this.rbDir);
			this.panel2.Location = new System.Drawing.Point(24, 120);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(184, 64);
			this.panel2.TabIndex = 10;
			// 
			// frmChooseFileType
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(248, 238);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnNext);
			this.Controls.Add(this.label1);
			this.Name = "frmChooseFileType";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Choose File Type";
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnNext_Click(object sender, System.EventArgs e)
		{
			if(!rbMSN.Checked&&!rbGaimPlain.Checked&&!rbHTML.Checked)
			{
				MessageBox.Show("Please choose a type!");
				return;
			}        
			if(!rbDir.Checked&&!rbFile.Checked)
			{
				MessageBox.Show("Please choose a source type!");
				return;
			}  

			if(rbMSN.Checked) 
			   m_format=MSNChatHistoryFormat.MSN;
		   else if(rbGaimPlain.Checked)
			   m_format=MSNChatHistoryFormat.GaimPlainText;
		   else if(rbHTML.Checked)
				m_format=MSNChatHistoryFormat.GaimHTML;

           if(rbFile.Checked)
			   m_sourceType=MSNSourceType.File;
			else if(rbDir.Checked)
			   m_sourceType=MSNSourceType.Directory;
           
			this.DialogResult=DialogResult.Yes;
		}
		
		private MSNChatHistoryFormat m_format=MSNChatHistoryFormat.MSN;
		private MSNSourceType m_sourceType=MSNSourceType.File;

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
			this.DialogResult=DialogResult.No;
		}
		/// <summary>
		/// MSN chat history format.
		/// </summary>
		public MSNChatHistoryFormat ChatHistoryFormat
		{
			get
			{

				return m_format;
			}
			set
			{

				m_format=value;
			}
		}


		/// <summary>
		/// Source type.
		/// </summary>
		public MSNSourceType SourceType
		{

			get
			{

				return m_sourceType;
			}
			set
			{
				m_sourceType=value;
			}
		}
	}
}
