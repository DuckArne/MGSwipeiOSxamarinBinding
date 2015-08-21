using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;
using System.Threading.Tasks;

namespace MGSwipeBinding
{
	// @interface MGSwipeSettings : NSObject
	[BaseType (typeof(NSObject))]
	interface MGSwipeSettings
	{

		// @property (assign, nonatomic) MGSwipeTransition transition;
		[Export ("transition", ArgumentSemantic.UnsafeUnretained)]
		MGSwipeTransition Transition { get; set; }

		// @property (assign, nonatomic) CGFloat threshold;
		[Export ("threshold", ArgumentSemantic.UnsafeUnretained)]
		nfloat Threshold { get; set; }

		// @property (assign, nonatomic) CGFloat offset;
		[Export ("offset", ArgumentSemantic.UnsafeUnretained)]
		nfloat Offset { get; set; }

		// @property (assign, nonatomic) CGFloat animationDuration;
		[Export ("animationDuration", ArgumentSemantic.UnsafeUnretained)]
		nfloat AnimationDuration { get; set; }
	}

	// @interface MGSwipeExpansionSettings : NSObject
	[BaseType (typeof(NSObject))]
	interface MGSwipeExpansionSettings
	{

		// @property (assign, nonatomic) NSInteger buttonIndex;
		[Export ("buttonIndex", ArgumentSemantic.UnsafeUnretained)]
		nint ButtonIndex { get; set; }

		// @property (assign, nonatomic) BOOL fillOnTrigger;
		[Export ("fillOnTrigger", ArgumentSemantic.UnsafeUnretained)]
		bool FillOnTrigger { get; set; }

		// @property (assign, nonatomic) CGFloat threshold;
		[Export ("threshold", ArgumentSemantic.UnsafeUnretained)]
		nfloat Threshold { get; set; }

		// @property (nonatomic, strong) UIColor * expansionColor;
		[Export ("expansionColor", ArgumentSemantic.Retain)]
		UIColor ExpansionColor { get; set; }

		// @property (assign, nonatomic) MGSwipeExpansionLayout expansionLayout;
		[Export ("expansionLayout", ArgumentSemantic.UnsafeUnretained)]
		MGSwipeExpansionLayout ExpansionLayout { get; set; }

		// @property (assign, nonatomic) CGFloat animationDuration;
		[Export ("animationDuration", ArgumentSemantic.UnsafeUnretained)]
		nfloat AnimationDuration { get; set; }
	}

	// @protocol MGSwipeTableCellDelegate <NSObject>

	[Protocol,Model]
	[BaseType (typeof(NSObject))]
	interface MGSwipeTableCellDelegate
	{

		// @optional -(BOOL)swipeTableCell:(MGSwipeTableCell *)cell canSwipe:(MGSwipeDirection)direction;
		[Export ("swipeTableCell:canSwipe:")]
		bool CanSwipe (MGSwipeTableCell cell, MGSwipeDirection direction);

		// @optional -(void)swipeTableCell:(MGSwipeTableCell *)cell didChangeSwipeState:(MGSwipeState)state gestureIsActive:(BOOL)gestureIsActive;
		[Export ("swipeTableCell:didChangeSwipeState:gestureIsActive:")]
		void DidChangeSwipeState (MGSwipeTableCell cell, MGSwipeState state, bool gestureIsActive);

		// @optional -(BOOL)swipeTableCell:(MGSwipeTableCell *)cell tappedButtonAtIndex:(NSInteger)index direction:(MGSwipeDirection)direction fromExpansion:(BOOL)fromExpansion;
		[Export ("swipeTableCell:tappedButtonAtIndex:direction:fromExpansion:")]
		bool TappedButtonAtIndex (MGSwipeTableCell cell, nint index, MGSwipeDirection direction, bool fromExpansion);

		// @optional -(NSArray *)swipeTableCell:(MGSwipeTableCell *)cell swipeButtonsForDirection:(MGSwipeDirection)direction swipeSettings:(MGSwipeSettings *)swipeSettings expansionSettings:(MGSwipeExpansionSettings *)expansionSettings;
		[Export ("swipeTableCell:swipeButtonsForDirection:swipeSettings:expansionSettings:")]
		NSObject [] SwipeButtonsForDirection (MGSwipeTableCell cell, MGSwipeDirection direction, MGSwipeSettings swipeSettings, MGSwipeExpansionSettings expansionSettings);
	}

	// @interface MGSwipeTableCell : UITableViewCell
	[BaseType (typeof(UITableViewCell))]
	interface MGSwipeTableCell
	{

		// @property (nonatomic, weak) id<MGSwipeTableCellDelegate> delegate;
		[Export ("delegate", ArgumentSemantic.Weak)]
		[NullAllowed]
		NSObject WeakDelegate { get; set; }

		// @property (nonatomic, weak) id<MGSwipeTableCellDelegate> delegate;
		[Wrap ("WeakDelegate")]
		MGSwipeTableCellDelegate Delegate { get; set; }

		// @property (readonly, nonatomic, strong) UIView * swipeContentView;
		[Export ("swipeContentView", ArgumentSemantic.Retain)]
		UIView SwipeContentView { get; }

		// @property (copy, nonatomic) NSArray * leftButtons;
		[Export ("leftButtons", ArgumentSemantic.Copy)]
		NSObject [] LeftButtons { get; set; }

		// @property (copy, nonatomic) NSArray * rightButtons;
		[Export ("rightButtons", ArgumentSemantic.Copy)]
		NSObject [] RightButtons { get; set; }

		// @property (nonatomic, strong) MGSwipeSettings * leftSwipeSettings;
		[Export ("leftSwipeSettings", ArgumentSemantic.Retain)]
		MGSwipeSettings LeftSwipeSettings { get; set; }

		// @property (nonatomic, strong) MGSwipeSettings * rightSwipeSettings;
		[Export ("rightSwipeSettings", ArgumentSemantic.Retain)]
		MGSwipeSettings RightSwipeSettings { get; set; }

		// @property (nonatomic, strong) MGSwipeExpansionSettings * leftExpansion;
		[Export ("leftExpansion", ArgumentSemantic.Retain)]
		MGSwipeExpansionSettings LeftExpansion { get; set; }

		// @property (nonatomic, strong) MGSwipeExpansionSettings * rightExpansion;
		[Export ("rightExpansion", ArgumentSemantic.Retain)]
		MGSwipeExpansionSettings RightExpansion { get; set; }

		// @property (readonly, nonatomic) MGSwipeState swipeState;
		[Export ("swipeState")]
		MGSwipeState SwipeState { get; }

		// @property (readonly, nonatomic) BOOL isSwipeGestureActive;
		[Export ("isSwipeGestureActive")]
		bool IsSwipeGestureActive { get; }

		// @property (nonatomic) BOOL allowsMultipleSwipe;
		[Export ("allowsMultipleSwipe")]
		bool AllowsMultipleSwipe { get; set; }

		// @property (nonatomic) BOOL allowsButtonsWithDifferentWidth;
		[Export ("allowsButtonsWithDifferentWidth")]
		bool AllowsButtonsWithDifferentWidth { get; set; }

		// @property (nonatomic) BOOL allowsSwipeWhenTappingButtons;
		[Export ("allowsSwipeWhenTappingButtons")]
		bool AllowsSwipeWhenTappingButtons { get; set; }

		// @property (nonatomic, strong) UIColor * swipeBackgroundColor;
		[Export ("swipeBackgroundColor", ArgumentSemantic.Retain)]
		UIColor SwipeBackgroundColor { get; set; }

		// @property (assign, nonatomic) CGFloat swipeOffset;
		[Export ("swipeOffset", ArgumentSemantic.UnsafeUnretained)]
		nfloat SwipeOffset { get; set; }

		// -(void)hideSwipeAnimated:(BOOL)animated;
		[Export ("hideSwipeAnimated:")]
		void HideSwipeAnimated (bool animated);

		// -(void)hideSwipeAnimated:(BOOL)animated completion:(void (^)())completion;
		[Export ("hideSwipeAnimated:completion:")]
		void HideSwipeAnimated (bool animated, Action completion);

		// -(void)showSwipe:(MGSwipeDirection)direction animated:(BOOL)animated;
		[Export ("showSwipe:animated:")]
		void ShowSwipe (MGSwipeDirection direction, bool animated);

		// -(void)showSwipe:(MGSwipeDirection)direction animated:(BOOL)animated completion:(void (^)())completion;
		[Export ("showSwipe:animated:completion:")]
		void ShowSwipe (MGSwipeDirection direction, bool animated, Action completion);

		// -(void)setSwipeOffset:(CGFloat)offset animated:(BOOL)animated completion:(void (^)())completion;
		[Export ("setSwipeOffset:animated:completion:")]
		void SetSwipeOffset (nfloat offset, bool animated, Action completion);

		// -(void)expandSwipe:(MGSwipeDirection)direction animated:(BOOL)animated;
		[Export ("expandSwipe:animated:")]
		void ExpandSwipe (MGSwipeDirection direction, bool animated);

		// -(void)refreshContentView;
		[Export ("refreshContentView")]
		void RefreshContentView ();

		// -(void)refreshButtons:(BOOL)usingDelegate;
		[Export ("refreshButtons:")]
		void RefreshButtons (bool usingDelegate);
	}
	// @interface MGSwipeButton : UIButton
	[BaseType (typeof(UIButton))]
	interface MGSwipeButton
	{

		// @property (nonatomic, strong) MGSwipeButtonCallback callback;
		[Export ("callback", ArgumentSemantic.Retain)]
		Func<MGSwipeTableCell, sbyte> Callback { get; set; }

		// @property (assign, nonatomic) CGFloat buttonWidth;
		[Export ("buttonWidth", ArgumentSemantic.UnsafeUnretained)]
		nfloat ButtonWidth { get; set; }

		// +(instancetype)buttonWithTitle:(NSString *)title backgroundColor:(UIColor *)color;
		[Static, Export ("buttonWithTitle:backgroundColor:")]
		MGSwipeButton ButtonWithTitle (string title, UIColor color);

		// +(instancetype)buttonWithTitle:(NSString *)title backgroundColor:(UIColor *)color padding:(NSInteger)padding;
		[Static, Export ("buttonWithTitle:backgroundColor:padding:")]
		MGSwipeButton ButtonWithTitle (string title, UIColor color, nint padding);

		// +(instancetype)buttonWithTitle:(NSString *)title backgroundColor:(UIColor *)color insets:(UIEdgeInsets)insets;
		[Static, Export ("buttonWithTitle:backgroundColor:insets:")]
		MGSwipeButton ButtonWithTitle (string title, UIColor color, UIEdgeInsets insets);

		// +(instancetype)buttonWithTitle:(NSString *)title backgroundColor:(UIColor *)color callback:(MGSwipeButtonCallback)callback;
		[Static, Export ("buttonWithTitle:backgroundColor:callback:")]
		MGSwipeButton ButtonWithTitle (string title, UIColor color, Func<MGSwipeTableCell, sbyte> callback);

		// +(instancetype)buttonWithTitle:(NSString *)title backgroundColor:(UIColor *)color padding:(NSInteger)padding callback:(MGSwipeButtonCallback)callback;
		[Static, Export ("buttonWithTitle:backgroundColor:padding:callback:")]
		MGSwipeButton ButtonWithTitle (string title, UIColor color, nint padding, Func<MGSwipeTableCell, sbyte> callback);

		// +(instancetype)buttonWithTitle:(NSString *)title backgroundColor:(UIColor *)color insets:(UIEdgeInsets)insets callback:(MGSwipeButtonCallback)callback;
		[Static, Export ("buttonWithTitle:backgroundColor:insets:callback:")]
		MGSwipeButton ButtonWithTitle (string title, UIColor color, UIEdgeInsets insets, Func<MGSwipeTableCell, sbyte> callback);

		// +(instancetype)buttonWithTitle:(NSString *)title icon:(UIImage *)icon backgroundColor:(UIColor *)color;
		[Static, Export ("buttonWithTitle:icon:backgroundColor:")]
		MGSwipeButton ButtonWithTitle (string title, UIImage icon, UIColor color);

		// +(instancetype)buttonWithTitle:(NSString *)title icon:(UIImage *)icon backgroundColor:(UIColor *)color padding:(NSInteger)padding;
		[Static, Export ("buttonWithTitle:icon:backgroundColor:padding:")]
		MGSwipeButton ButtonWithTitle (string title, UIImage icon, UIColor color, nint padding);

		// +(instancetype)buttonWithTitle:(NSString *)title icon:(UIImage *)icon backgroundColor:(UIColor *)color insets:(UIEdgeInsets)insets;
		[Static, Export ("buttonWithTitle:icon:backgroundColor:insets:")]
		MGSwipeButton ButtonWithTitle (string title, UIImage icon, UIColor color, UIEdgeInsets insets);

		// +(instancetype)buttonWithTitle:(NSString *)title icon:(UIImage *)icon backgroundColor:(UIColor *)color callback:(MGSwipeButtonCallback)callback;
		[Static, Export ("buttonWithTitle:icon:backgroundColor:callback:")]
		MGSwipeButton ButtonWithTitle (string title, UIImage icon, UIColor color, Func<MGSwipeTableCell, sbyte> callback);

		// +(instancetype)buttonWithTitle:(NSString *)title icon:(UIImage *)icon backgroundColor:(UIColor *)color padding:(NSInteger)padding callback:(MGSwipeButtonCallback)callback;
		[Static, Export ("buttonWithTitle:icon:backgroundColor:padding:callback:")]
		MGSwipeButton ButtonWithTitle (string title, UIImage icon, UIColor color, nint padding, Func<MGSwipeTableCell, sbyte> callback);

		// +(instancetype)buttonWithTitle:(NSString *)title icon:(UIImage *)icon backgroundColor:(UIColor *)color insets:(UIEdgeInsets)insets callback:(MGSwipeButtonCallback)callback;
		[Static, Export ("buttonWithTitle:icon:backgroundColor:insets:callback:")]
		MGSwipeButton ButtonWithTitle (string title, UIImage icon, UIColor color, UIEdgeInsets insets, Func<MGSwipeTableCell, sbyte> callback);

		// -(void)setPadding:(CGFloat)padding;
		[Export ("setPadding:")]
		void SetPadding (nfloat padding);

		// -(void)setEdgeInsets:(UIEdgeInsets)insets;
		[Export ("setEdgeInsets:")]
		void SetEdgeInsets (UIEdgeInsets insets);

		// -(void)centerIconOverText;
		[Export ("centerIconOverText")]
		void CenterIconOverText ();
	}
}

