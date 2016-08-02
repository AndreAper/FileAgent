using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace FileAgent
{
    public partial class frmMain : Form
    {
        //Target path collection variable
        public StringCollection scTargetPathCollection;

        //Source path varaible
        public DirectoryInfo srcDir;

        //Time variable to set the time point of copy history function
        TimeSpan tsHistory;

        //Async method to copy the history folder asynchronous.
        //Caution: the caller must be async
        public async Task CopyHistoryAsync(DirectoryInfo srcDirectory, string destDir) 
        {
            try
            {
                //Enumerate subdirectorys e.g. Bespannungsanlage, Laserschweissanlage
                foreach (DirectoryInfo di in srcDirectory.EnumerateDirectories())
                {
                    //Create path to the destination directory
                    string dest = Path.Combine(destDir, di.Name, "_History");
                    string destStoppages = Path.Combine(destDir, di.Name, "_StoppagesHistory");
                    string srcHistoryFile = Path.Combine(di.FullName, di.Name + "_History.js");
                    string destHistoryFile = Path.Combine(destDir, di.Name, di.Name + "_History.js");
                    string srcStoppagesHistoryFile = Path.Combine(di.FullName, di.Name + "_Stoppages_History.js");
                    string desStoppagestHistoryFile = Path.Combine(destDir, di.Name, di.Name + "_Stoppages_History.js");
                    
                    lblCurrentTask.Text = di.Name;

                    if (!Directory.Exists(dest))
                        Directory.CreateDirectory(dest);

                    if (!Directory.Exists(destStoppages))
                        Directory.CreateDirectory(destStoppages);

                    //First copy the history.js file
                    if (File.Exists(Path.Combine(srcDirectory.FullName, di.Name, "access.lock")) == false)
                    {
                        using (StreamReader SourceReader = File.OpenText(srcHistoryFile))
                        {
                            using (StreamWriter DestinationWriter = File.CreateText(destHistoryFile))
                            {
                                lblCurrentTask.Text = "Copy " + di.Name + " Main History";
                                await WriteStreamAsync(SourceReader, DestinationWriter);
                            }
                        } 
                    }


                    //Copy the stoppages history.js file
                    if (File.Exists(Path.Combine(srcDirectory.FullName, di.Name, "access.lock")) == false)
                    {
                        using (StreamReader SourceReader = File.OpenText(srcStoppagesHistoryFile))
                        {
                            using (StreamWriter DestinationWriter = File.CreateText(desStoppagestHistoryFile))
                            {
                                lblCurrentTask.Text = "Copy " + di.Name + " Main Stoppages History";
                                await WriteStreamAsync(SourceReader, DestinationWriter);
                            }
                        }
                    }

                    //Do this for each file in the _History folder in the source folder
                    IEnumerable<string> ieSrcFiles = Directory.EnumerateFiles(Path.Combine(di.FullName, "_History"), "*.js");
                    progressBarHistory.Maximum = ieSrcFiles.Count();
                    foreach (string filename in ieSrcFiles)
                    {
                        if (File.Exists(Path.Combine(srcDirectory.FullName, di.Name, "access.lock")) == false)
                        {
                            using (StreamReader SourceReader = File.OpenText(filename))
                            {
                                using (StreamWriter DestinationWriter = File.CreateText(dest + filename.Substring(filename.LastIndexOf('\\'))))
                                {
                                    lblCurrentTask.Text = "Copy " + di.Name + " Main History Directory";
                                    await WriteStreamAsync(SourceReader, DestinationWriter);
                                }
                            } 
                        }

                        progressBarHistory.PerformStep();
                    }

                    //Do this for each file in the _StoppagesHistory folder in the source folder
                    IEnumerable<string> ieStoppagesSrcFiles = Directory.EnumerateFiles(Path.Combine(di.FullName, "_StoppagesHistory"), "*.js");
                    progressBarHistory.Maximum = ieSrcFiles.Count();
                    foreach (string filename in ieStoppagesSrcFiles)
                    {
                        if (File.Exists(Path.Combine(srcDirectory.FullName, di.Name, "access.lock")) == false)
                        {
                            using (StreamReader SourceReader = File.OpenText(filename))
                            {
                                using (StreamWriter DestinationWriter = File.CreateText(destStoppages + filename.Substring(filename.LastIndexOf('\\'))))
                                {
                                    lblCurrentTask.Text = "Copy " + di.Name + " Stoppages History Directory";
                                    await WriteStreamAsync(SourceReader, DestinationWriter);
                                }
                            }
                        }

                        progressBarHistory.PerformStep();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally 
            {
                progressBarHistory.Value = 0;
                lblCurrentTask.Text = "";
            }
        }

        //Async method to copy the live file asynchronous.
        //Caution: the caller must be async
        public async Task CopyLiveAsync(DirectoryInfo srcDirectory, string destDir) 
        {
            try
            {
                //Enumerate subdirectorys e.g. Bespannungsanlage, Laserschweissanlage
                foreach (DirectoryInfo di in srcDirectory.EnumerateDirectories())
                {
                    //Get the current name of subdirectory
                    string subDirName = di.Name;

                    //Create path to the destination directory
                    string dest = Path.Combine(destDir, subDirName);

                    if (!Directory.Exists(dest))
                        Directory.CreateDirectory(dest);

                    //Do this for each file in the _History folder in the source folder
                    IEnumerable<string> ieSrcFiles = Directory.EnumerateFiles(di.FullName, "*_Live.js");
                    progressBarLive.Maximum = ieSrcFiles.Count();
                    foreach (string filename in ieSrcFiles)
                    {
                        //Open the file an read
                        if (File.Exists(Path.Combine(srcDirectory.FullName, di.Name, "access.lock")) == false)
                        {
                            using (StreamReader SourceReader = File.OpenText(filename))
                            {
                                using (StreamWriter DestinationWriter = File.CreateText(dest + filename.Substring(filename.LastIndexOf('\\'))))
                                {
                                    await WriteStreamAsync(SourceReader, DestinationWriter);
                                }
                            } 
                        }

                        progressBarHistory.PerformStep();
                    }
                }
            }
            catch (Exception e)
            {
                if (e is UnauthorizedAccessException)
                {

                }
                else
                {
                    throw;
                }
            }
            finally 
            {
                progressBarHistory.Value = 0;
           
            }
        }

        //Async method to write the stream to the target location
        //Caution: the caller must be async
        public async Task WriteStreamAsync(StreamReader Source, StreamWriter Destination)
        {
            char[] buffer = new char[0x1000];
            int numRead;
            while ((numRead = await Source.ReadAsync(buffer, 0, buffer.Length)) != 0)
            {
                await Destination.WriteAsync(buffer, 0, numRead);
            }
        }

        //Do this at the start
        public frmMain()
        {
            //Initialize the windows forms components
            InitializeComponent();

            //Set the value of datetimepicker control with the value from the settings
            dtpHistoryTime.Value = Properties.Settings.Default.HistoryTime;

            //Set the value of numericupdown control with the value from the settings
            nudTimerIntervall.Value = (decimal)Properties.Settings.Default.TimerIntervall;


            //Check if SourcePath variable in the settings has value saved.
            if (Properties.Settings.Default.SourcePath != "")
            {
                //Create a new DirectoryInfo instance with the source path from the settings
                srcDir = new DirectoryInfo(Properties.Settings.Default.SourcePath);

                //Show this in the Textbox
                tbxSelectedSourcePath.Text = srcDir.FullName;
            }

            //Check if any target path has saved in the settings
            if (Properties.Settings.Default.TargetPathCollection == null)
            {
                //If no path in the collection
                //Create a new StringCollection instance and save this to the settings.
                scTargetPathCollection = new StringCollection();
                Properties.Settings.Default.TargetPathCollection = scTargetPathCollection;
                Properties.Settings.Default.Save();
            }
            else
            {
                //Target path collection at least one element
                //Show all elements from the collection to the listbox
                lstBxTargetPathList.Items.Clear();
                scTargetPathCollection = Properties.Settings.Default.TargetPathCollection;
                foreach (string s in scTargetPathCollection)
                {
                    lstBxTargetPathList.Items.Add(s);
                }
            }
        }

        //Button to start the automatic mode
        private void chkWatcherEnabled_CheckedChanged(object sender, EventArgs e)
        {
            //Disable or enable all other controls
            btnAddTargetPath.Enabled = !chkWatcherEnabled.Checked;
            btnClearTargetPathList.Enabled = !chkWatcherEnabled.Checked;
            btnRemoveTargetPath.Enabled = !chkWatcherEnabled.Checked;
            btnSetSourcePath.Enabled = !chkWatcherEnabled.Checked;
            nudTimerIntervall.Enabled = !chkWatcherEnabled.Checked;
            btnCopyHistory.Enabled = !chkWatcherEnabled.Checked;
            dtpHistoryTime.Enabled = !chkWatcherEnabled.Checked;
            lstBxTargetPathList.Enabled = !chkWatcherEnabled.Checked;

            //Check wich state of the checkbox
            if (chkWatcherEnabled.Checked)
            {
                //Check if srcDir variable is null or not
                if (srcDir != null)
                {
                    //If srcDir variable not null, check if scTargetPathCollection has any elements
                    if (scTargetPathCollection.Count != 0)
                    {
                        //Target path collection has at least one element
                        //Now the timer will start
                        timer.Interval = (int)nudTimerIntervall.Value;
                        timer.Enabled = chkWatcherEnabled.Checked;

                        //The timer intervall value to the settings
                        Properties.Settings.Default.TimerIntervall = this.timer.Interval;
                        Properties.Settings.Default.Save();

                        //Change the text of the checkbox to "Enabled"
                        chkWatcherEnabled.Text = "Enabled";
                    }
                    else
                    {
                        //Show a message box if scTargetPathCollection has no elements
                        MessageBox.Show("Process does not work without target folders\r\nPlease add target path to the list!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        
                        //Set the checkbox state to uncheckd
                        chkWatcherEnabled.Checked = false;
                    }
                }
                else
                {
                    //Show a message box if srcDir is null
                    MessageBox.Show("Process does not work without source folders\r\nPlease select source path!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    //Set the checkbox state to uncheckd
                    chkWatcherEnabled.Checked = false;
                }
            }
            else
            {
                //Change the text of the checkbox to "Disabled"
                chkWatcherEnabled.Text = "Disabled";
            }
        }

        //This event open an folderbrowse dialog to set the source path, renew the srcDir instance and save this to the settings
        private void btnSetSourcePath_Click(object sender, EventArgs e)
        {
            //Create a FolderBrowsDialog instance.
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Select source folder!";

            //Show the dialog
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                //If user has clicked ok,  create a new directoryinfo instance with the new üath to the source directory
                srcDir = new DirectoryInfo(fbd.SelectedPath);
                tbxSelectedSourcePath.Text = srcDir.FullName;

                //Store the new path in the settings
                Properties.Settings.Default.SourcePath = srcDir.FullName;
                Properties.Settings.Default.Save();
            }
        }

        //This event open an folderbrowse dialog to append a path to the scTargetPathCollection instance and save this to the settings
        private void btnAddTargetPath_Click(object sender, EventArgs e)
        {
            //Create a FolderBrowsDialog instance.
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Select target folder!";

            //Show the dialog
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                //Add the selected path to the scTargetPathCollection instance
                scTargetPathCollection.Add(fbd.SelectedPath);

                //Save the updated scTargetPathCollection instance to the settings
                Properties.Settings.Default.TargetPathCollection = scTargetPathCollection;
                Properties.Settings.Default.Save();

                //Update the listbox
                lstBxTargetPathList.Items.Clear();
                foreach (string s in scTargetPathCollection)
                {
                    lstBxTargetPathList.Items.Add(s);
                }
            }
        }

        //This event remove the selected row from the listbox and from the scTargetPathCollection instance and save this to the settings
        private void btnRemoveTargetPath_Click(object sender, EventArgs e)
        {
            //Check if user has selected a row in the listbox
            if (lstBxTargetPathList.SelectedIndex <= scTargetPathCollection.Count)
            {
                //Remove the selected row from the scTargetPathCollection instance
                scTargetPathCollection.RemoveAt(lstBxTargetPathList.SelectedIndex);

                //Save the updated scTargetPathCollection instance to the settings
                Properties.Settings.Default.TargetPathCollection = scTargetPathCollection;
                Properties.Settings.Default.Save();

                //Update the listbox
                lstBxTargetPathList.Items.Clear();
                foreach (string s in scTargetPathCollection)
                {
                    lstBxTargetPathList.Items.Add(s);
                } 
            }
        }

        //This remove all elmenet in the listbox and scTargetPathCollection instance and save this to the settings
        private void btnClearTargetPathList_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to remove all target paths?", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Remove all rows in the listbox
                lstBxTargetPathList.Items.Clear();

                //Remove all elements in the scTargetPathCollection instance
                scTargetPathCollection.Clear();

                //Save the updated scTargetPathCollection instance to the settings
                Properties.Settings.Default.TargetPathCollection = scTargetPathCollection;
                Properties.Settings.Default.Save();
            }
        }

        //CAUTION the caller is async.
        //This event check all required informations are saved in the settings and call the asynchronous method
        //to copy the live.js file for each target path in the collection
        private async void btnCopy_Click(object sender, EventArgs e)
        {
            //Check if srcDir variable is null or not
            if (srcDir != null)
            {
                //If srcDir variable not null, check if scTargetPathCollection has any elements
                if (scTargetPathCollection.Count != 0)
                {
                    //Call the asynchronous method to copy the live file for each target path
                    for (int i = 0; i < scTargetPathCollection.Count; i++)
                    {
                        await CopyLiveAsync(srcDir, scTargetPathCollection[i]);
                    }
                }
                else
                {
                    //Show a message box if scTargetPathCollection has no elements
                    MessageBox.Show("Process does not work without target folders\r\nPlease add target path to the list!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    chkWatcherEnabled.Checked = false;
                }
            }
            else
            {
                //Show a message box if srcDir is null
                MessageBox.Show("Process does not work without source folders\r\nPlease select source path!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                chkWatcherEnabled.Checked = false;
            }
        }

        //CAUTION the caller is async.
        //This event call the asynchronous method timed to copy the live.js file for each target path in the collection
        private async void timer_Tick(object sender, EventArgs e)
        {
            //Call the asynchronous method to copy the live file for each target path
            for (int i = 0; i < scTargetPathCollection.Count; i++)
            {
               await CopyLiveAsync(srcDir, scTargetPathCollection[i]);
            }
        }

        //This event will raised when the user change the value in the numeric up down control to set the intervall for the timer
        private void nudTimerIntervall_ValueChanged(object sender, EventArgs e)
        {
            //Set the interval
            this.timer.Interval = (int)nudTimerIntervall.Value;
        }

        //This event will raised when the user change the value in the datetimepicker control to set the time point to copy the history.
        private void dtpHistoryTime_ValueChanged(object sender, EventArgs e)
        {
            //Create a new Timespan instance with the new time value
            tsHistory = new TimeSpan(dtpHistoryTime.Value.Hour, dtpHistoryTime.Value.Minute, dtpHistoryTime.Value.Second);

            //Save the new time point to the settings
            Properties.Settings.Default.HistoryTime = dtpHistoryTime.Value;
            Properties.Settings.Default.Save();
        }

        //CAUTION the caller is async.
        //In this event compare the saved time point with current system time every second.
        //If time point and current system time are equal, then call the asynchronous method to copy the history for each target path in the collection.
        private async void historyTimer_Tick(object sender, EventArgs e)
        {
            //Create a new timespan instance with current system time
            TimeSpan tsNow = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

            //Compare the time
            if (tsHistory.Equals(tsNow))
            {
                //Call the asynchronous method to copy the history for each target path
                foreach (string s in scTargetPathCollection)
                {
                    await CopyHistoryAsync(srcDir, s);
                }
            }
        }

        //CAUTION the caller is async.
        //This event check all required informations are saved in the settings and call the asynchronous method
        //to copy the history for each target path in the collection
        private async void btnCopyHistory_Click(object sender, EventArgs e)
        {
            //Check if srcDir variable is null or not
            if (srcDir != null)
            {
                //If srcDir variable not null, check if scTargetPathCollection has any elements
                if (scTargetPathCollection.Count != 0)
                {
                    //Call the asynchronous method to copy the live file for each target path
                    foreach (string s in scTargetPathCollection)
                    {
                        await CopyHistoryAsync(srcDir, s);
                    }
                }
                else
                {
                    //Show a message box if scTargetPathCollection has no elements
                    MessageBox.Show("Process does not work without target folders\r\nPlease add target path to the list!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    chkWatcherEnabled.Checked = false;
                }
            }
            else
            {
                //Show a message box if srcDir is null
                MessageBox.Show("Process does not work without source folders\r\nPlease select source path!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                chkWatcherEnabled.Checked = false;
            }
        }
    }
}
