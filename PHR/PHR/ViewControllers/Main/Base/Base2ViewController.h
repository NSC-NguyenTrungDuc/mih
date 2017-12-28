//
//  Bae2ViewController.h
//  PHR
//
//  Created by Luong Le Hoang on 10/7/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import "BaseViewController.h"
#import "Base2NavigationBar.h"
#import "PHREnums.h"
#import "PHRViewUploadFile.h"

@protocol Base2ViewControllerDelegate <NSObject>
- (void)presentViewControllerOnDashboard:(UIViewController *)viewController;
- (void)openViewControllerAtIndex:(PHRBabyGroupType)type;
- (UIImage *)takeScreenShot;
@end


@class IQActionSheetPickerView;
@interface Base2ViewController : BaseViewController <PHRViewUploadFileDelegate>

@property (nonatomic, strong) UIPanGestureRecognizer *popRecognizer;
@property (strong, nonatomic) UIRefreshControl *refreshControl;
@property (nonatomic, weak) id<Base2ViewControllerDelegate> delegate;

- (void)setupNavigationBarTitle:(NSString *)title titleIcon:(NSString *)titleIcon rightItem:(NSString *)rightItem;
- (void)setupNavigationBarTitle:(NSString *)title iconLeft:(NSString *)iconLeft iconRight:(NSString *)iconRight iconMiddle:(NSString*)iconMiddle isDismissView:(bool) isDismiss colorLeft:(UIColor*)leftColor colorRight:(UIColor*)rightColor;

- (void)actionNavigationBarItemRight;
//- (void)setImageToBackgroundStandard:(UIImageView *)imageBackground;
//- (void)setImageToBackgroundBaby:(UIImageView *)imageBackground;

- (void)showWebView:(NSMutableURLRequest *)request;
- (void)setEnableForRightButton:(BOOL) isEnable;

// Navigation bar item, just show when profile active
- (NSString*)itemRightStandardKey:(NSString*)key;
- (NSString*)itemRightBabyKey:(NSString*)key;
- (void)removeObserve;
- (void)setIsShowDialog:(BOOL)isShow;
- (void)refreshAllView;
@end
