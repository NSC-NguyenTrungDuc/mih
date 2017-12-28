//
//  MainViewController.m
//  PHR
//
//  Created by Luong Le Hoang on 9/29/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import "MainViewController.h"
#import "HealthKitManager.h"
#import "StorageManager.h"
#import "MenuLeftViewController.h"
#import "DashboardViewController.h"
#import "BluetoothManager.h"

@interface MainViewController () <MenuLeftViewControllerDelegate>

@end

@implementation MainViewController{
    
}

- (instancetype)initMainController{
  
    // Menu left
    MenuLeftViewController *menuController = [[MenuLeftViewController alloc] initWithNibName:NSStringFromClass([MenuLeftViewController class]) bundle:nil];
    menuController.delegate = self;
    // Standard
    DashboardViewController *dashboard = [[DashboardViewController alloc] init];
    // Init
    self = [self initWithCenterViewController:dashboard leftDrawerViewController:menuController];
    self.maximumLeftDrawerWidth =  [[UIScreen mainScreen] bounds].size.width;
    self.showsShadow = NO;
    return self;
}

- (void)viewDidLoad {
    [super viewDidLoad];
    [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(closeMenuLeft:) name:kNotifyCloseMenuLeft object:nil];
    [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(closeMenuLeft:) name:kNotifyBackToDashbroad object:nil];
    
    
    // Start sync timer
    [[HealthKitManager sharedManager] startSyncHealthkit];

    // scan all bluetooth device around if device conneted before auto get data and store
    [[BluetoothManager instance] beginScanDevice];
    [[StorageManager instance] startSyncBluetoothAndPHRData];
    [[StorageManager instance] startSyncDataToServer];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (void) closeMenuLeft:(NSNotification*)notify {
    [self closeDrawerAnimated:YES completion:^(BOOL finished) {
    }];
}


#pragma mark - Menu left delegate
- (void)menuLeftLogout {
    [PHRAppStatus clearAllData];
    [NetworkManager clearSavedPassword];
    [NetworkManager clearSavedFacebookAccessToken];
    [NetworkManager clearSettingSynchronizeHealthKit];
    [PHRAppDelegate switchRootViewControllerWithAnimated:YES];
}

@end
