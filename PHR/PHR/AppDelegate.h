//
//  AppDelegate.h
//  PHR
//
//  Created by Luong Le Hoang on 9/28/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "AppStatus.h"
#import "PHRReachability.h"


@interface AppDelegate : UIResponder <UIApplicationDelegate>

@property (strong, nonatomic) UIWindow *window;
@property (strong, nonatomic) AppStatus *appStatus;
@property (assign, nonatomic) NetworkStatus networkStatus;
@property (nonatomic, strong) UINavigationController *navigationController;
@property (assign, nonatomic) BOOL isReadingHealthKit;


- (void)showLoading;
- (void)hideLoading;
- (MBProgressHUD *)showLoadingInView:(UIView*)view;
- (MBProgressHUD *)showLoadingInView:(UIView*)view loadingColor:(UIColor*)loadingColor;
- (void)hideLoading:(MBProgressHUD*)hud;
- (void)hideLoadingInView:(UIView*)view;
- (void)switchRootViewControllerWithAnimated:(BOOL)animated;

@end