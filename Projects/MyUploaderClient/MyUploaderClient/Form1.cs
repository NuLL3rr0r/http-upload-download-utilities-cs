using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Web.Services.Protocols;

namespace MyUploaderClient
{
    public partial class Form1 : Form
    {
        #region Global Variables & Properties

        private uploader.Upload up = new uploader.Upload();

        string login = "HiLouis!";
        long offset = -1;
        int chunk = -1;
        string serverPath = string.Empty;

        string[] files = { };
        string filePath = string.Empty;
        string fileName = string.Empty;
        int fileIndex = -1;
        long fileSize = -1;

        private bool inProgress = false;
        private bool currentFileDone = false;
        bool cancel = false;
        bool paused = false;
        bool useForce = false;

        #endregion

        public Form1()
        {
            InitializeComponent();

            up.UploadChunkCompleted += new uploader.UploadChunkCompletedEventHandler(UploadChunkCompleted);
        }

        #region Form Operations

        private void SetFormStatus(bool status)
        {
            btnBrowse.Enabled = !status;

            txtServerPath.Enabled = status;
            numChunkSize.Enabled = status;

            btnUpload.Enabled = status;

            if (status)
            {
                btnPause.Enabled = false;
                btnCancel.Enabled = true;
            }
            else
            {
                pbrUpload.Value = 0;

                btnPause.Enabled = false;
                btnCancel.Enabled = false;

                txtLog.Text = string.Empty;
                inProgress = false;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            DialogResult res = ofd.ShowDialog();

            if (res == DialogResult.OK)
            {
                SetFormStatus(true);
                txtLog.Text = string.Format("Found {0} Files", ofd.FileNames.Length);
                btnUpload.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (!paused)
                cancel = true;
            else
                SetFormStatus(false);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetFormStatus(false);
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            btnUpload.Enabled = false;
            txtServerPath.Enabled = false;
            numChunkSize.Enabled = false;
            btnPause.Enabled = true;

            inProgress = true;
            serverPath = txtServerPath.Text;
            chunk = Convert.ToInt32(numChunkSize.Value) * 1024;

            files = ofd.FileNames;

            offset = -1;
            fileIndex = -1;

            cancel = false;
            paused = false;
            useForce = false;

            SendRequest("UploadChunk");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (inProgress)
            {
                DialogResult res = MessageBox.Show("Do you want to exit adn cancel the upload operation? Are you sure?", "Uploader!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (res != DialogResult.OK)
                {
                    e.Cancel = true;
                }
                else
                    e.Cancel = true;
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            paused = !paused;

            if (paused)
            {
                btnPause.Text = "Resume";
            }
            else
            {
                numChunkSize.Enabled = false;
                chunk = Convert.ToInt32(numChunkSize.Value) * 1024;
                pbrUpload.Value = (int)(offset / chunk);
                pbrUpload.Maximum = (int)(fileSize / chunk);
                btnPause.Text = "Pause";
                SendRequest("UploadChunk");
            }
        }

        #endregion

        #region AsyncCalls

        private void TryRequest(string req, string err)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(err);
            DialogResult result = MessageBox.Show(sb.ToString(), "Server Error!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            switch (result)
            {
                case DialogResult.Retry:
                    SendRequest(req);
                    break;
                case DialogResult.Cancel:
                    SetFormStatus(false);
                    break;
                default:
                    break;
            }
        }

        private void SendRequest(string req)
        {
            try
            {
                switch (req)
                {
                    case "UploadChunk":
                        if (!SendRequestUploadChunk())
                            return;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Uploader!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetFormStatus(false);
            }
            finally
            {
            }
        }

        private bool SendRequestUploadChunk()
        {
            if (!cancel && !paused)
            {
                try
                {
                    if (offset == -1)
                    {
                        offset = 0;
                        currentFileDone = false;
                        filePath = files[++fileIndex];
                        FileInfo fi = new FileInfo(filePath);
                        fileSize = fi.Length;
                        fileName = fi.Name;
                        pbrUpload.Maximum = (int)(fileSize / chunk);

                        txtLog.Text = string.Format("{0} ({1}/{2})", fileName, fileIndex + 1, files.Length);
                    }

                    byte[] buffer = { };

                    using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 8))
                    {
                        fs.Seek(offset, SeekOrigin.Begin);

                        if (offset + chunk < fileSize)
                        {
                            buffer = new byte[chunk];
                            fs.Read(buffer, 0, chunk);
                        }
                        else
                        {
                            int lastChunk = (int)(fileSize - offset);
                            buffer = new byte[lastChunk];
                            fs.Read(buffer, 0, lastChunk);
                            currentFileDone = true;
                        }

                        fs.Close();
                    }

                    up.UploadChunkAsync(fileName, serverPath, buffer, offset, useForce, login);

                    if (useForce)
                        useForce = false;

                    return true;
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message, "Uploader!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SetFormStatus(false);
                    return false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Uploader!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SetFormStatus(false);
                    return false;
                }
                finally
                {
                }
            }
            else if (paused)
            {
                numChunkSize.Enabled = true;
                return true;
            }
            else
            {
                SetFormStatus(false);
                return false;
            }
        }

        #endregion

        #region AsyncCalls Response

        private void UploadChunkCompleted(Object sender, uploader.UploadChunkCompletedEventArgs Completed)
        {
            try
            {
                string result = Completed.Result;

                if (result.Contains("{offset:"))
                {
                    offset = Convert.ToInt64(result.Replace("{offset:", string.Empty).Replace("}", string.Empty));
                    if (offset < fileSize)
                    {
                        DialogResult res = MessageBox.Show(String.Format("{0} already exist on server. Maybe it's broken.\n\nPress Yes to resume...\nPress No to overwrite...\nPress Cancel to abort the operation...", fileName), "Uploader!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

                        switch (res)
                        {
                            case DialogResult.Yes:
                                offset -= chunk;
                                break;
                            case DialogResult.No:
                                offset = -1;
                                fileIndex--;
                                useForce = true;
                                SendRequest("UploadChunk");
                                return;
                                break;
                            case DialogResult.Cancel:
                                SetFormStatus(false);
                                return;
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        DialogResult res = MessageBox.Show(String.Format("{0} already exist on server.\n\nPress Yes to overwirte...\nPress No to skip...\nPress Cancel to stop the operation...", fileName), "Uploader!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

                        switch (res)
                        {
                            case DialogResult.Yes:
                                offset = -1;
                                fileIndex--;
                                useForce = true;
                                SendRequest("UploadChunk");
                                return;
                                break;
                            case DialogResult.No:
                                currentFileDone = true;
                                break;
                            case DialogResult.Cancel:
                                SetFormStatus(false);
                                return;
                                break;
                            default:
                                break;
                        }
                    }

                    result = "OK!";
                }

                switch (result)
                {
                    case "OK!":
                        pbrUpload.Value = (int)(offset / chunk);
                        if (currentFileDone)
                        {
                            if (fileIndex + 1 == files.Length)
                            {
                                SetFormStatus(false);
                                MessageBox.Show("Done!", "Uploader!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                return;
                            }

                            offset = -1;
                        }
                        else
                        {
                            offset += chunk;
                        }

                        SendRequest("UploadChunk");
                        break;
                    case "Illegal Access...":
                        MessageBox.Show("Illegal Access...", "Uploader!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SetFormStatus(false);
                        break;
                    default:
                        TryRequest("UploadFile", result);
                        break;
                }
            }
            catch (SoapException ex)
            {
                TryRequest("UploadChunk", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("UploadChunk", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        #endregion
    }
}
