using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MapApp.Core;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace MapApp.GUI
{
	public partial class Form1 : Form
	{
		private GMapsHelper mapHelper = new GMapsHelper();

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			// Set GMap Object
			gMapControl1.CanDragMap = true;
			gMapControl1.MarkersEnabled = true;
			gMapControl1.PolygonsEnabled = true;
			gMapControl1.RoutesEnabled = true;
			gMapControl1.MinZoom = 1;
			gMapControl1.MaxZoom = 25;
			gMapControl1.Zoom = 6;
			gMapControl1.Bearing = 0;
			gMapControl1.BorderStyle = BorderStyle.FixedSingle;
			gMapControl1.ShowTileGridLines = false;
			gMapControl1.ShowCenter = false;
			// Set GMap mode to server only
			GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
			// Set Map Providers combo
			cboMapProviders.DropDownStyle = ComboBoxStyle.DropDownList;
			cboMapProviders.Items.AddRange(mapHelper.GetProvidersNames());
		}

		private void btnLoadMap_Click(object sender, EventArgs e)
		{
			if (cboMapProviders.Text == string.Empty)
			{
				MessageBox.Show("Please, Select Map Provider first!");
				cboMapProviders.Focus();
				return;
			}
			GMapProvider provider = mapHelper.GetProvider(cboMapProviders.Text);
			if (provider == null)
			{
				MessageBox.Show("This is not defined Map provider, please try to select different one from the list");
				cboMapProviders.Focus();
				return;
			}
			gMapControl1.MapProvider = provider;
			gMapControl1.SetPositionByKeywords("Paris, France");
			gMapControl1.ReloadMap();
		}

		private void trackBar1_Scroll(object sender, EventArgs e)
		{
			gMapControl1.Zoom = trackBar1.Value;
			gMapControl1.Refresh();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			GMapOverlay markers = new GMapOverlay("markers");
			PointLatLng markerPoint = new PointLatLng(48.86, 2.34);
			GMapMarker marker = new GMarkerGoogle(markerPoint,
												 GMarkerGoogleType.blue_pushpin);
			marker.ToolTipText = "Test Text";
			markers.Markers.Add(marker);
			gMapControl1.Overlays.Add(markers);
			ReloadMap();
			UpdateLabel();
		}

		private void ReloadMap()
		{
			gMapControl1.ReloadMap();
			gMapControl1.Zoom++;
			gMapControl1.Zoom--;
		}

		private void UpdateLabel()
		{
			label1.Text = gMapControl1.Overlays.Count.ToString();
		}

		private void gMapControl1_OnPositionChanged(PointLatLng point)
		{
			label2.Text = point.Lat.ToString();
			label3.Text = point.Lng.ToString();
		}

		private void gMapControl1_OnExceptionThrown(Exception exception)
		{
		}

		private void gMapControl1_OnMapDrag()
		{
		}

		private void gMapControl1_MouseClick(object sender, MouseEventArgs e)
		{
		}

		private void gMapControl1_OnMarkerClick(GMapMarker item, MouseEventArgs e)
		{
			MessageBox.Show(item.ToolTipText);
		}
	}
}