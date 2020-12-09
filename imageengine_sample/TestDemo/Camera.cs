namespace TestDemo
{
	using System;
	using System.Drawing;
	using System.Threading;

    using AForge.Video;

	public class Camera
	{
        //�����ڱ���
		private IVideoSource	videoSource = null;
		private Bitmap			lastFrame = null;
        private string          lastVideoSourceError = null;

		// ͼ����Ϣ
		private int width = -1;
        private int height = -1;

		// �����¼����
		public event EventHandler NewFrame;
        public event EventHandler VideoSourceError;

        // �����Ƶ֡
		public Bitmap LastFrame
		{
			get { return lastFrame; }
		}

        // Last video source error
        public string LastVideoSourceError
        {
            get { return lastVideoSourceError; }
        }

		// ��Ƶ֡�������
		public int Width
		{
			get { return width; }
		}

		//��Ƶ֡�߶�����
		public int Height
		{
			get { return height; }
		}

		// Frames received from the last access to the property
		public int FramesReceived
		{
			get { return ( videoSource == null ) ? 0 : videoSource.FramesReceived; }
		}

        // Bytes received from the last access to the property
		public int BytesReceived
		{
			get { return ( videoSource == null ) ? 0 : videoSource.BytesReceived; }
		}

		// Running property
		public bool IsRunning
		{
			get { return ( videoSource == null ) ? false : videoSource.IsRunning; }
		}

		// Constructor
        public Camera( IVideoSource source )
		{
			this.videoSource = source;
			videoSource.NewFrame += new NewFrameEventHandler( video_NewFrame );
            videoSource.VideoSourceError += new VideoSourceErrorEventHandler( video_VideoSourceError );

           
		}

		// ����Ƶ
		public void Start( )
		{
			if ( videoSource != null )
			{
                
				videoSource.Start( );
			}
		}

		// ����ֹͣ�ź�
		public void SignalToStop( )
		{
			if ( videoSource != null )
			{
				videoSource.SignalToStop( );
            }
		}

		// �ȴ���Ƶֹͣ
		public void WaitForStop( )
		{
			// lock
			Monitor.Enter( this );

			if ( videoSource != null )
			{
				videoSource.WaitForStop( );
			}
			// unlock
			Monitor.Exit( this );
		}

		// ����ֹͣ
		public void Stop( )
		{
			// lock
			Monitor.Enter( this );

			if ( videoSource != null )
			{
				videoSource.Stop( );
			}

			// unlock
			Monitor.Exit( this );
		}

		// ����
		public void Lock( )
		{
			Monitor.Enter( this );
		}

		// �������
		public void Unlock( )
		{
			Monitor.Exit( this );
		}

		// ��ͼ��֡
		private void video_NewFrame( object sender, NewFrameEventArgs e )
		{
			try
			{
				// lock
				Monitor.Enter( this );

				// �ͷž�ͼ��֡
				if ( lastFrame != null )
				{
					lastFrame.Dispose( );
				}

                // ��λ
                lastVideoSourceError = null;
                // �õ���ͼ��
				lastFrame = (Bitmap) e.Frame.Clone( );
                // ͼ����Ϣ
				width = lastFrame.Width;
				height = lastFrame.Height;
            }
			catch ( Exception )
			{
			}
			finally
			{
				// unlock
				Monitor.Exit( this );
			}

			// notify client
			if ( NewFrame != null )
				NewFrame( this, new EventArgs( ) );
		}

        // On video source error
        private void video_VideoSourceError( object sender, VideoSourceErrorEventArgs e )
        {
            // save video source error's description
            lastVideoSourceError = e.Description;

            // notify clients about the error
            if ( VideoSourceError != null )
            {
                VideoSourceError( this, new EventArgs( ) );
            }
        }

      
	}
}
