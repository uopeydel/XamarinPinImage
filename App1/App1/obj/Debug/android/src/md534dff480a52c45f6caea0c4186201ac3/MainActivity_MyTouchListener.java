package md534dff480a52c45f6caea0c4186201ac3;


public class MainActivity_MyTouchListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.view.View.OnTouchListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onTouch:(Landroid/view/View;Landroid/view/MotionEvent;)Z:GetOnTouch_Landroid_view_View_Landroid_view_MotionEvent_Handler:Android.Views.View/IOnTouchListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("App1.MainActivity+MyTouchListener, App1", MainActivity_MyTouchListener.class, __md_methods);
	}


	public MainActivity_MyTouchListener ()
	{
		super ();
		if (getClass () == MainActivity_MyTouchListener.class)
			mono.android.TypeManager.Activate ("App1.MainActivity+MyTouchListener, App1", "", this, new java.lang.Object[] {  });
	}

	public MainActivity_MyTouchListener (android.widget.ImageView p0, android.widget.RelativeLayout p1)
	{
		super ();
		if (getClass () == MainActivity_MyTouchListener.class)
			mono.android.TypeManager.Activate ("App1.MainActivity+MyTouchListener, App1", "Android.Widget.ImageView, Mono.Android:Android.Widget.RelativeLayout, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public boolean onTouch (android.view.View p0, android.view.MotionEvent p1)
	{
		return n_onTouch (p0, p1);
	}

	private native boolean n_onTouch (android.view.View p0, android.view.MotionEvent p1);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
