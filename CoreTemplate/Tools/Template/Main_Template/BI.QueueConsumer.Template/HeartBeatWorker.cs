using Serilog;
using System.Threading;
using System.Threading.Tasks;

namespace BI.QueueConsumer.Template
{
	internal class HeartBeatWorker
	{
		private bool _shutdownProcess;
		private readonly int _heartbeatIntervalMs;
		private readonly string _heartBeatName;

		private CancellationTokenSource _cancellationTokenSource;

		public HeartBeatWorker(int heartBeatIntervalMs, string heartBeatName)
		{
			_heartbeatIntervalMs = heartBeatIntervalMs < 1000 ? 1000 : heartBeatIntervalMs;
			_heartBeatName = heartBeatName;
		}

		public void Start()
		{
			if (_heartbeatIntervalMs <= 0) return;
			this._shutdownProcess = false;
			this._cancellationTokenSource = new CancellationTokenSource();
			new Task(this.Beat, this._cancellationTokenSource.Token).Start();
		}

		public void Stop()
		{
			this._shutdownProcess = true;
			this._cancellationTokenSource.Cancel();
		}

		private void Beat()
		{
			while (!this._shutdownProcess)
			{
				Log.Information("HeartBeat For: " + this._heartBeatName);
				Thread.Sleep(this._heartbeatIntervalMs);
			}
		}
	}
}