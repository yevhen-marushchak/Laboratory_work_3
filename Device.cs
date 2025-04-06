namespace Laboratory_work_1
{
    public abstract class Device
    {
        public string Name { get; set; }
        public bool IsPoweredOn { get; private set; }
        public bool IsSoftwareInstalled { get; private set; }
        public bool IsInternetConnected { get; private set; }
        public bool AreSpeakersConnected { get; private set; }

        public event Action OnStateChange;

        protected Device(string name)
        {
            Name = name;
        }

        public void TogglePower()
        {
            IsPoweredOn = !IsPoweredOn;
            OnStateChange?.Invoke();
        }

        public void InstallSoftware()
        {
            IsSoftwareInstalled = true;
            OnStateChange?.Invoke();
        }

        public void UninstallSoftware()
        {
            IsSoftwareInstalled = false;
            OnStateChange?.Invoke();
        }

        public void ConnectInternet()
        {
            IsInternetConnected = true;
            OnStateChange?.Invoke();
        }

        public void DisconnectInternet()
        {
            IsInternetConnected = false;
            OnStateChange?.Invoke();
        }

        public void ConnectSpeakers()
        {
            AreSpeakersConnected = true;
            OnStateChange?.Invoke();
        }

        public void DisconnectSpeakers()
        {
            AreSpeakersConnected = false;
            OnStateChange?.Invoke();
        }

        public abstract void Work();
        public abstract void PlayGames();
        public abstract void WatchVideos();
    }
}
