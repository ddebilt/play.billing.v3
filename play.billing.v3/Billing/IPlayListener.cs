namespace play.billing.v3
{
	public interface IPlayListener
	{
		/// <summary>
		/// Invoked when the InAppService is connected.
		/// </summary>
		void Connected();

		/// <summary>
		/// Invoked when the InAppService is disconnected.
		/// </summary>
		void Disconnected();
	}
}