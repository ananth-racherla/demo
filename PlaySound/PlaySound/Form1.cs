using System;
using System.Media;
using System.Windows.Forms;

namespace PlaySound
{
	public partial class Form1 : Form
	{
		public SoundPlayer SoundPlayer { get; } = new SoundPlayer("alarm.wav");
		public Form1()
		{
			InitializeComponent();
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			SoundPlayer.PlayLooping();
		}

		private void btnStop_Click(object sender, EventArgs e)
		{
			SoundPlayer.Stop();
		}
	}
}
