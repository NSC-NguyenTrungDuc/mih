//
//  AppDelegate.m
//  PHR
//
//  Created by Luong Le Hoang on 9/28/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import "AppDelegate.h"
#import "SignInViewController.h"
#import "IQKeyboardManager.h"
#import "MBProgressHUD.h"
#import <Fabric/Fabric.h>
#import <Crashlytics/Crashlytics.h>
#import "ProgressCourseNoteViewController.h"
#import <FBSDKCoreKit/FBSDKCoreKit.h>
#import "HomeViewController.h"
#import "MedicineViewController.h"
#import "MasterDataManager.h"
#import "HealthKitManager.h"
#import "UIWindow+TopMost.h"
#import "AcceptCallingViewController.h"
#import "MainViewController.h"
#import "PHRMovieTalkViewController.h"

@interface AppDelegate (){
  MBProgressHUD *HUD;
}

@property (nonatomic) BOOL firstRun;

@property(strong, nonatomic) PHRReachability * internetReach;
@property (assign, nonatomic) BOOL isFromBackgroundState;
@property (strong, nonatomic) NSDictionary *notificationInfo;



@end

@implementation AppDelegate

- (BOOL)application:(UIApplication *)application didFinishLaunchingWithOptions:(NSDictionary *)launchOptions {
  self.isFromBackgroundState = NO;
  // Reachability
  __block typeof(self) weakSelf = self;
  self.internetReach = [PHRReachability reachabilityWithHostname:@"www.google.com"];
  self.internetReach.reachableBlock = ^(PHRReachability * reachability)
  {
    DLog(@"InternetConnection Block Says Reachable(%@)", reachability.currentReachabilityString);
    weakSelf.networkStatus = [reachability currentReachabilityStatus];
    if (![NSUtils valueForKey:KEY_APNS_REGISTER_ID]) {
      [weakSelf registerForRemoteNotification];
    }
  };
  
  self.internetReach.unreachableBlock = ^(PHRReachability * reachability)
  {
    DLog(@"InternetConnection Block Says Unreachable(%@)", reachability.currentReachabilityString);
    weakSelf.networkStatus = [reachability currentReachabilityStatus];
  };
  [self.internetReach startNotifier];
  
  
  //Add FB
  [[FBSDKApplicationDelegate sharedInstance] application:application didFinishLaunchingWithOptions:launchOptions];
  
  // Add Fabric
  [Fabric with:@[[Crashlytics class]]];
  
  // Keyboard
  [[IQKeyboardManager sharedManager] setEnable:YES];
  [[IQKeyboardManager sharedManager] setEnableAutoToolbar:YES];
  [[IQKeyboardManager sharedManager] setShouldShowTextFieldPlaceholder:YES];
  
  if ([UIApplication instancesRespondToSelector:@selector(registerUserNotificationSettings:)]) {
    [[UIApplication sharedApplication] registerUserNotificationSettings:[UIUserNotificationSettings settingsForTypes:UIUserNotificationTypeAlert|UIUserNotificationTypeSound categories:nil]];
  }
  
  // App data cache
  self.appStatus = [[AppStatus alloc] init];
  // Init Realm for process data to local
  
  
  RLMRealmConfiguration *config = [RLMRealmConfiguration defaultConfiguration];
  config.schemaVersion = 2;
  config.migrationBlock = ^(RLMMigration *migration, uint64_t  oldSchemaVersion) {
    if (oldSchemaVersion < 1){
      [[NSUserDefaults standardUserDefaults] setObject:@"0" forKey:@"kMasterDataManagerSaved"];
      [[NSUserDefaults standardUserDefaults] synchronize];
    }
    [migration enumerateObjects:PHRSample.className
                          block:^(RLMObject *oldObject, RLMObject *newObject) {
                            if (oldSchemaVersion < 1) {
                              // do nothing
                            }
                          }];
  };
  [RLMRealmConfiguration setDefaultConfiguration:config];
  
  [RLMRealm defaultRealm];
  
  self.appStatus.backgroundImageList = [LocalStorageImage allObjects];
  //  self.appStatus.back = [[BackgroundSettingInfo allObjects] lastObject];
  self.appStatus.back = [[BackgroundSettingInfo objectsWhere:[NSString stringWithFormat:@"userID='%@'", PHRAppStatus.masterProfileId]] lastObject];
  
  [MagicalRecord setupAutoMigratingCoreDataStack];
  
  // Main
  HomeViewController *homeViewController = [[HomeViewController alloc] initWithNibName:NSStringFromClass([HomeViewController class]) bundle:nil];
  self.navigationController = [[UINavigationController alloc] initWithRootViewController:homeViewController];
  
  self.window = [[UIWindow alloc] initWithFrame:[[UIScreen mainScreen] bounds]];
  self.window.rootViewController = self.navigationController;
  [self.window makeKeyAndVisible];
  
  // Navigation bar appearance
  //    UINavigationBar *navigationBar = [UINavigationBar appearance];
  //    navigationBar.tintColor = [UIColor clearColor];
  //    navigationBar.barTintColor = [UIColor clearColor];
  //    [navigationBar setTitleTextAttributes:@{[UIColor whiteColor]: NSForegroundColorAttributeName}];
  
  // Process suggest data
  [MasterDataManager processData];
  
  // Request authorized HealthKit
  [[HealthKitManager sharedManager] requestAuthorization];
  
  [self registerForRemoteNotification];
  //  [self registerDeviceToken];
  
  return YES;
}

- (void)applicationWillResignActive:(UIApplication *)application {
  // Sent when the application is about to move from active to inactive state. This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) or when the user quits the application and it begins the transition to the background state.
  // Use this method to pause ongoing tasks, disable timers, and throttle down OpenGL ES frame rates. Games should use this method to pause the game.
  [self deleteExpiredLocalNotification];
}

- (void)applicationDidEnterBackground:(UIApplication *)application {
  // Use this method to release shared resources, save user data, invalidate timers, and store enough application state information to restore your application to its current state in case it is terminated later.
  // If your application supports background execution, this method is called instead of applicationWillTerminate: when the user quits.
  self.isFromBackgroundState = YES;
}

- (void)applicationWillEnterForeground:(UIApplication *)application {
  // Called as part of the transition from the background to the inactive state; here you can undo many of the changes made on entering the background.
  self.isFromBackgroundState = YES;
  
  [[NSNotificationCenter defaultCenter]postNotificationName:@"setUpTime" object:nil];
  
}

- (void)applicationDidBecomeActive:(UIApplication *)application {
  // Restart any tasks that were paused (or not yet started) while the application was inactive. If the application was previously in the background, optionally refresh the user interface.
  [FBSDKAppEvents activateApp];
  //Delete local notification
  [self deleteExpiredLocalNotification];
  self.isFromBackgroundState = NO;
}

- (void)applicationWillTerminate:(UIApplication *)application {
  [NSUtils removeObjectForKey:kNotifyLongTimeComeBackApp];
  NSString *saveSleepTime = [UIUtils stringDate:[NSDate date] withFormat:@"hh:mm:ss a yyyy/MM/dd"];
  [NSUtils setValue:saveSleepTime forKey:kNotifyLongTimeComeBackApp];
  [self deleteExpiredLocalNotification];
  // Called when the application is about to terminate. Save data if appropriate. See also applicationDidEnterBackground:.
}


- (BOOL)application:(UIApplication *)application openURL:(NSURL *)url sourceApplication:(NSString *)sourceApplication annotation:(id)annotation {
  BOOL handled = [[FBSDKApplicationDelegate sharedInstance] application:application
                                                                openURL:url
                                                      sourceApplication:sourceApplication
                                                             annotation:annotation
                  ];
  // Add any custom logic here.
  return handled;
}


- (void)application:(UIApplication *)application didReceiveLocalNotification:(UILocalNotification *)notification{
  UIApplicationState state = [application applicationState];
  if (state == UIApplicationStateActive) {
    NSDictionary *dict = notification.userInfo;
    NSDate *date = [dict objectForKey:PHR_REMIND_END_DATE];
    NSDate *now = [NSDate date];
    if (date && [now compare:date] == NSOrderedDescending) {
      [[UIApplication sharedApplication] cancelLocalNotification:notification];
    } else {
      UIAlertView *alert = [[UIAlertView alloc] initWithTitle:kLocalizedString(kRemider)
                                                      message:notification.alertBody
                                                     delegate:self cancelButtonTitle:@"OK"
                                            otherButtonTitles:nil];
      [alert show];
    }
    
    
  }
  
  application.applicationIconBadgeNumber = 0;
}


- (void)deleteExpiredLocalNotification {
  
  NSMutableArray *allNotifications = [NSMutableArray arrayWithArray:[[UIApplication sharedApplication] scheduledLocalNotifications]];
  NSDate *now = [NSDate date];
  NSTimeInterval time = floor([now timeIntervalSinceReferenceDate] / 60.0) * 60.0;
  NSDate *dateWithoutSecond = [NSDate dateWithTimeIntervalSinceReferenceDate:time];
  for (UILocalNotification *notification in allNotifications) {
    
    NSDictionary *dict = notification.userInfo;
    if (dict) {
      
      NSDate *date = [dict objectForKey:PHR_REMIND_END_DATE];
      if (date && [dateWithoutSecond compare:date] == NSOrderedDescending) {
        [[UIApplication sharedApplication] cancelLocalNotification:notification];
      }
    }
  }
}

#pragma mark - Loading

- (void)showLoading{
  if (!HUD) {
    HUD = [[MBProgressHUD alloc] initWithView:self.window];
    [self.window addSubview:HUD];
    [HUD show:YES];
  }
}

- (void)hideLoading{
  if (HUD) {
    [HUD hide:YES];
    [HUD removeFromSuperview];
    HUD = nil;
  }
}

- (MBProgressHUD *)showLoadingInView:(UIView*)view{
  if (view) {
    MBProgressHUD *hud = [[MBProgressHUD alloc] initWithView:view];
    [view addSubview:hud];
    [hud show:YES];
    return hud;
  }
  return nil;
}

- (MBProgressHUD *)showLoadingInView:(UIView*)view loadingColor:(UIColor*)loadingColor {
  if (view) {
    MBProgressHUD *hud = [[MBProgressHUD alloc] initWithView:view];
    hud.tintColor = loadingColor;
    [view addSubview:hud];
    [hud show:YES];
    return hud;
  }
  return nil;
}

- (void)hideLoading:(MBProgressHUD*)hud{
  if (hud) {
    [hud hide:YES];
    [hud removeFromSuperview];
    hud = nil;
  }
}

- (void)hideLoadingInView:(UIView*)view{
  if (view) {
    for (id child in view.subviews) {
      if ([child isMemberOfClass:[MBProgressHUD class]]) {
        [(MBProgressHUD*)child removeFromSuperview];
      }
    }
  }
}

- (void)switchRootViewControllerWithAnimated:(BOOL)animated {
  NSArray *arrayViewController = self.navigationController.viewControllers;
  for (int i = (int)arrayViewController.count - 1 ; i >= 0; i--) {
    UIViewController* viewController = arrayViewController[i];
    if ([viewController isKindOfClass:[SignInViewController class]] ) {
      [UIView beginAnimations:nil context:nil];
      [UIView setAnimationDuration:0.5];
      [UIView setAnimationTransition:UIViewAnimationTransitionFlipFromLeft forView:viewController.view cache:YES];
      [self.navigationController popToViewController:viewController  animated:YES];
      [UIView commitAnimations];
      break;
    }
    if(i == 0){
      [self switchHomeViewControllerWithAnimated:animated];
    }
  }
}

- (void)switchHomeViewControllerWithAnimated:(BOOL)animated {
  HomeViewController *rootViewController;
  rootViewController = [[HomeViewController alloc] initWithNibName:@"HomeViewController" bundle:nil];
  [rootViewController.view layoutSubviews];
  
  self.navigationController = [[UINavigationController alloc] initWithRootViewController:rootViewController];
  
  if (animated) {
    [UIView beginAnimations:@"Switch View Controller" context:nil];
    [UIView setAnimationDuration:0.5];
    [UIView setAnimationTransition:UIViewAnimationTransitionFlipFromLeft forView:self.window cache:YES];
    
    self.window.rootViewController = self.navigationController;
    [self.window makeKeyAndVisible];
    
    [UIView commitAnimations];
  } else {
    self.window.rootViewController = self.navigationController;
    [self.window makeKeyAndVisible];
  }
  
}


//#pragma mark - Call Api Register Device Token
//- (void)registerDeviceToken {
//  if ([NSUtils valueForKey:KEY_APNS_REGISTER_ID]) {
//    //    [[TMTCLient instance] registerDeviceToken:[NSUtils valueForKey:KEY_APNS_REGISTER_ID] completion:^(NSURLSessionDataTask *task, id responseObject) {
//    //
//    //    } error:^(NSURLSessionDataTask *task, NSError *error) {
//    //
//    //    }];
//  }
//}

#pragma push notification
- (void)registerForRemoteNotification {
  UIUserNotificationType types = UIUserNotificationTypeSound | UIUserNotificationTypeBadge | UIUserNotificationTypeAlert;
  UIUserNotificationSettings *notificationSettings = [UIUserNotificationSettings settingsForTypes:types categories:nil];
  [[UIApplication sharedApplication] registerUserNotificationSettings:notificationSettings];
}

- (void)application:(UIApplication *)application didRegisterUserNotificationSettings:(UIUserNotificationSettings *)notificationSettings {
  [application registerForRemoteNotifications];
}

- (void)application:(UIApplication *)application didRegisterForRemoteNotificationsWithDeviceToken:(NSData *)deviceToken {
  NSString *deviceTokenString = [[deviceToken description] stringByTrimmingCharactersInSet:[NSCharacterSet characterSetWithCharactersInString:@"<>"]];
  deviceTokenString = [deviceTokenString stringByReplacingOccurrencesOfString:@" " withString:@""];
  NSLog(@"didRegisterForRemoteNotificationsWithDeviceToken: %@", deviceTokenString);
  [NSUtils setValue:[Validator getSafeString:deviceTokenString] forKey:KEY_APNS_REGISTER_ID];
  
//  UIAlertView *alert = [[UIAlertView alloc] initWithTitle:@""
//                                                  message:deviceTokenString
//                                                 delegate:nil cancelButtonTitle:@"OK"
//                                        otherButtonTitles:nil];
//  [alert show];
}

- (void)application:(UIApplication *)application didFailToRegisterForRemoteNotificationsWithError:(NSError *)error {
  NSLog(@"Did Fail to Register for Remote Notifications");
  NSLog(@"%@, %@", error, error.localizedDescription);
}

- (BOOL)checkNotificationType:(UIUserNotificationType)type{
  UIUserNotificationSettings *currentSettings = [[UIApplication sharedApplication] currentUserNotificationSettings];
  return (currentSettings.types & type);
}

- (void)application:(UIApplication *)application didReceiveRemoteNotification:(NSDictionary *)userInfo {
  
  application.applicationIconBadgeNumber = 0;
  // Show alert for push notifications recevied while the
  // app is running
  if([[self.window visibleViewController] isKindOfClass:[AcceptCallingViewController class]]) {
    return;
  }
  
  BOOL isLogin = NO;
  for (UIViewController *viewController in self.navigationController.viewControllers) {
    if ([viewController isKindOfClass:[MainViewController class]]) {
      isLogin = YES;
    }
  }
  if (!isLogin) {
    return;
  }
  [self handleNotification:userInfo];
  
  self.notificationInfo = userInfo;
  //  [[NSNotificationCenter defaultCenter] postNotificationName:NOTIFICATION_REFRESH_LIST_NOTIFI object:nil];
}

- (void)handleNotification:(NSDictionary *)userInfo {
  
  if (self.isFromBackgroundState == YES) {
    self.isFromBackgroundState = NO;
  }
  [self openAnswerCallingScreen:userInfo];
}

- (void)openAnswerCallingScreen:(NSDictionary*)userInfo {
  if (!userInfo) {
    return;
  }
  NSString *strJson = [userInfo valueForKeyPath:@"aps.alert.body"];
  NSLog(@"%@",strJson);
  if (!strJson || strJson == (id)[NSNull null] || strJson.isEmpty) {
    return;
  }
  NSData * jsonData = [strJson dataUsingEncoding:NSUTF8StringEncoding];
  NSError *jsonError;
  NSDictionary *parsedData = [NSJSONSerialization JSONObjectWithData:jsonData options:NSJSONReadingAllowFragments error:&jsonError];
  
  if ([[self.window visibleViewController] isKindOfClass:[PHRMovieTalkViewController class]]) {
    PHRMovieTalkViewController *movieTalkViewController = (PHRMovieTalkViewController *)[self.window visibleViewController];
    [movieTalkViewController callToDoctor];
  } else {
    for (UIViewController *viewController in self.navigationController.viewControllers) {
      
      if ([viewController isKindOfClass:[MainViewController class]]) {
        AcceptCallingViewController *acceptCallingViewController = [[AcceptCallingViewController alloc] initWithNibName:@"AcceptCallingViewController" bundle:nil];
        acceptCallingViewController.dictUserInfo = parsedData;
        [self.navigationController pushViewController:acceptCallingViewController animated:YES];
      }
    }
  }
}
@end
