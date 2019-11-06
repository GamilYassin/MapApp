using GMap.NET.MapProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MapApp.Core
{
	public class GMapsHelper
	{
		private Dictionary<String, GMapProvider> mapProviders;

		public GMapsHelper()
		{
			// Initialize Map Providers
			this.mapProviders = new Dictionary<string, GMapProvider>();
			//this.mapProviders.Add("Cloud Maps", CloudMadeMapProvider.Instance);
			this.mapProviders.Add("Google Maps", GoogleMapProvider.Instance);
			this.mapProviders.Add("Google Satellite Maps", GoogleSatelliteMapProvider.Instance);
			this.mapProviders.Add("Google Hybrid Maps", GoogleHybridMapProvider.Instance);
			this.mapProviders.Add("OpenCycle Maps", OpenCycleMapProvider.Instance);
			this.mapProviders.Add("OpenCycle Landscape Maps", OpenCycleLandscapeMapProvider.Instance);
			this.mapProviders.Add("OpenCycle Transport Maps", OpenCycleTransportMapProvider.Instance);
			this.mapProviders.Add("Open Street Maps", OpenStreetMapProvider.Instance);
			this.mapProviders.Add("Wikimapia Maps", WikiMapiaMapProvider.Instance);
			//this.mapProviders.Add("Yahoo Maps", YahooMapProvider.Instance);
			this.mapProviders.Add("Bing Maps", BingMapProvider.Instance);
			this.mapProviders.Add("Bing Satellite Maps", BingSatelliteMapProvider.Instance);
			this.mapProviders.Add("Bing Hybrid Maps", BingHybridMapProvider.Instance);
		}

		public GMapProvider GetProvider(string key)
		{
			try
			{
				GMapProvider provider = null;
				_ = this.mapProviders.TryGetValue(key, out provider);
				return provider;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return null;
			}
		}

		public string[] GetProvidersNames()
		{
			return this.mapProviders.Keys.ToArray();
		}
	}
}