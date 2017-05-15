using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Util;
using Android.Support.V7.App;
using Android.Support.V4.View;
using Android.Support.V4.App;
using Android.Support.Design.Widget;

namespace TabbedActivity.Droid
{
	[Activity(Label = "TabbedActivity", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : AppCompatActivity
	{
		private SectionsPagerAdapter sectionsPagerAdapter;
		private ViewPager viewPager;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.Main);

			Android.Support.V7.Widget.Toolbar toolbar = (Android.Support.V7.Widget.Toolbar)FindViewById(Resource.Id.toolbar);
			SetSupportActionBar(toolbar);
			// Create the adapter that will return a fragment for each of the three
			// primary sections of the activity.
			sectionsPagerAdapter = new SectionsPagerAdapter(SupportFragmentManager);

			// Set up the ViewPager with the sections adapter.
			viewPager = (ViewPager)FindViewById(Resource.Id.container);
			viewPager.Adapter = sectionsPagerAdapter;

			FloatingActionButton fab = (FloatingActionButton)FindViewById(Resource.Id.fab);
			fab.Click += ActionButtonClicked;
		}

		void ActionButtonClicked(object sender, EventArgs e)
		{
			View view = (View)sender;
			Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong).SetAction("Action", (View.IOnClickListener)null).Show();
		}


		public override bool OnCreateOptionsMenu(IMenu menu)
		{
			// Inflate the menu; this adds items to the action bar if it is present.
			MenuInflater.Inflate(Resource.Layout.menu_main, menu);
			return true;
		}


		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			// Handle action bar item clicks here. The action bar will
			// automatically handle clicks on the Home/Up button, so long
			// as you specify a parent activity in AndroidManifest.xml.
			int id = item.ItemId;

			//noinspection SimplifiableIfStatement
			if (id == Resource.Id.action_settings)
			{
				return true;
			}

			return base.OnOptionsItemSelected(item);
		}


		public class PlaceholderFragment : Android.Support.V4.App.Fragment
		{
			/**
				 * The fragment argument representing the section number for this
				 * fragment.
				 */
			private static readonly String ARG_SECTION_NUMBER = "section_number";

			public PlaceholderFragment()
			{
			}

			/**
			 * Returns a new instance of this fragment for the given section
			 * number.
			 */
			public static PlaceholderFragment newInstance(int sectionNumber)
			{
				PlaceholderFragment fragment = new PlaceholderFragment();
				Bundle args = new Bundle();
				args.PutInt(ARG_SECTION_NUMBER, sectionNumber);
				fragment.Arguments = args;
				return fragment;
			}


			override public View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
			{
				View rootView = inflater.Inflate(Resource.Layout.fragment_main, container, false);
				TextView textView = (TextView)rootView.FindViewById(Resource.Id.section_label);
				textView.Text = GetString(Resource.String.section_format, Arguments.GetInt(ARG_SECTION_NUMBER));
				return rootView;
			}
		}

		public class SectionsPagerAdapter : FragmentPagerAdapter
		{
			public override int Count
			{
				get
				{
					return 3;
				}
			}

			public SectionsPagerAdapter(Android.Support.V4.App.FragmentManager fm) : base(fm)
			{
			}

			public override Android.Support.V4.App.Fragment GetItem(int position)
			{
				return PlaceholderFragment.newInstance(position + 1);
			}

			public override Java.Lang.ICharSequence GetPageTitleFormatted(int position)
			{
				switch (position)
				{
					case 0:
						return new Java.Lang.String("SECTION 1");
					case 1:
						return new Java.Lang.String("SECTION 2");
					case 2:
						return new Java.Lang.String("SECTION 3");
				}
				return null;
			}
		}
	}
}


