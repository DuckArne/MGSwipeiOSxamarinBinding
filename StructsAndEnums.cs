using System;
using ObjCRuntime;

namespace MGSwipeBinding{
	[Native]
	public enum MGSwipeTransition :long{
		Border = 0,
		Static,
		Drag,
		ClipCenter,
		Rotate3D
	}

	[Native]
	public enum MGSwipeDirection : long{
		LeftToRight = 0,
		RightToLeft
	}

	[Native]
	public enum MGSwipeState :long{
		None = 0,
		SwippingLeftToRight,
		SwippingRightToLeft,
		ExpandingLeftToRight,
		ExpandingRightToLeft
	}

	[Native]
	public enum MGSwipeExpansionLayout : long{
		Border = 0,
		Center
	}
}

