using System;
using Android.App;
using Android.Runtime;

namespace SuperOfertas.Droid
{
	[Application]
	[MetaData("com.google.android.maps.v2.API_KEY",
			  Value = "AIzaSyCs9IYB15mKft7hVE6HrlkR1K8K48IIIiU")]
	public class SuperOfertas : Application
	{
		public SuperOfertas(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
}