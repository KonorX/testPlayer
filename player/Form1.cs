using System.Windows.Media;
using System.IO;

namespace player
{
    public partial class Form1 : Form
    {

        bool isPicked = false;
        MediaPlayer player = new MediaPlayer();
        bool isPaused=false;
        Dictionary<string,string> playlist= new Dictionary<string,string>();
        List<string> songNames= new List<string>();
        bool isPlaylist=false;


        public Form1()
        {

            InitializeComponent();
            button6.Visible=false;
            button7.Visible=false;
            button4.Image = images.menu;
            button5.Image = images.killPlay;
            label1.Text = "";
            listBox1.SelectedIndexChanged += ListBox1_SelectedIndexChanged;
        }

        private void ListBox1_SelectedIndexChanged(object? sender, EventArgs e)
        {
            playlistChecking();
            
                label1.Text = listBox1.SelectedItem.ToString();
                isPlaylist = true;


                player.Open(new Uri(playlist[label1.Text.ToString()]));
                player.Play();
                if (player.Position==player.NaturalDuration)
                {
                    if (listBox1.SelectedIndex < listBox1.Items.Count)
                    {
                    listBox1.SelectedIndex += 1;
                    }
                    else
                    {
                    listBox1.SelectedIndex = 0;
                    }
                }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect=true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                isPicked = true;
                
                player.Open(new Uri(openFileDialog.FileName));
                player.Stop();
                FileInfo file = new FileInfo(openFileDialog.FileName);
                label1.Text=file.Name;
                isPaused = true;
            }
            
        }
        
        void playlistChecking()
        {
            if (isPlaylist)
            {
                button6.Visible = true;
                button7.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isPicked)
            {
                player.Play();
            }
            else
            {
                button2_Click(sender, e);
                
                player.Play();
            }
            
            isPaused = false;
            button3.Image = images.pause11;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (isPaused)
            {
                player.Stop();
                button3.Image = images.pause11;
            }
            else
            {
                player.Pause();
                isPaused = true;
                button3.Image = images.newstop;
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int playlistCounts = 0;
            FolderBrowserDialog fld=new FolderBrowserDialog();
            if (fld.ShowDialog()==DialogResult.OK)
            {
                DirectoryInfo info = new DirectoryInfo(fld.SelectedPath);

                FileInfo[] files = info.GetFiles("*.mp3");

                foreach (var music in files)
                {
                    playlist.Add(music.Name, music.FullName);
                    songNames.Add(music.Name);
                    listBox1.Items.Insert(playlistCounts,songNames[playlistCounts]);
                    
                    playlistCounts++;
                }
                isPlaylist = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            isPlaylist = false;
            listBox1.Items.Clear();
            listBox1.Refresh();
            button6.Visible = false;
            button7.Visible = false;   
            //listBox1.Update();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex<listBox1.Items.Count-1)
            {
                listBox1.SelectedIndex += 1;
            }
            else
            {
                listBox1.SelectedIndex = 0;
            }
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > 0)
            {
                listBox1.SelectedIndex -= 1;
            }
            else
            {
                listBox1.SelectedIndex =listBox1.Items.Count-1;
            }
        }
    }
}