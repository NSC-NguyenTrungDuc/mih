//
//  MenuLeftViewController.m
//  PHR
//
//  Created by Luong Le Hoang on 9/29/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import "MenuLeftViewController.h"
#import "AboutViewController.h"
#import "SignInViewController.h"
#import "ChangePasswordViewController.h"
#import "PolicyViewController.h"
#import "HelpViewController.h"
#import "DisplaySettingViewController.h"
#import "BluetoothDeviceConnectViewController.h"
#import "HealthKitManager.h"
#import "SynchronizeHealthKitViewController.h"
#import "StorageManager.h"
#import "BluetoothManager.h"

@interface MenuLeftViewController () {
    NSArray *_arrayMenu;
    NSArray *_arrayMenuImageUnSelect;
    NSArray *_arrayMenuImageSelect;
}


@end

@implementation MenuLeftViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    [self.btnBackToDashboard setTitle:kLocalizedString(kBackToDashboard) forState:UIControlStateNormal];
    self.labelSetting.text = kLocalizedString(kSettingTitle);
    [self.labelSetting setFont:[FontUtils aileronRegularWithSize:18.0]];
    _arrayMenu = [NSArray arrayWithObjects:kLocalizedString(kDisplaySettingTitle), kLocalizedString(kChangePasswordTitle),kLocalizedString(kTitleSyncHealthKit),kLocalizedString(kTitleSyncBluetooth), kLocalizedString(kHelpCenterTitle), kLocalizedString(kTermPoliciesTitle), kLocalizedString(kAboutTitle), kLocalizedString(kLogoutTitle), nil];
    
    _arrayMenuImageUnSelect = @[@"Icon_File_Image",@"Icon_lock", @"Icon_Sync_HealtKit",@"Icon_Bluetooth", @"Icon_Help", @"Icon_Info@x", @"Icon_Square", @"Icon_Logout"];
    _arrayMenuImageSelect = @[@"Icon_File_Image_white",@"icon_lock_white", @"Icon_Sync_HealthKit_White",@"Icon_Bluetooth_White", @"Icon_Help_White", @"Icon_Info_White",@"Icon_Square_White", @"Icon_Logout_White"];
    
    [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(requestAuthorizationStatus:) name:PHRNotificationRequestAuthorization object:nil];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (UIStatusBarStyle)preferredStatusBarStyle {
    return UIStatusBarStyleLightContent;
}

- (void) viewDidAppear:(BOOL)animated {
    [super viewDidAppear:animated];
}

#pragma mark - Tableview delegate

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {
    return _arrayMenu.count;
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath {
    static NSString *CellMenuIndentifier = @"cell";
    UITableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:CellMenuIndentifier];
    
    if (!cell) {
        cell = [[UITableViewCell alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:CellMenuIndentifier];
        UIView *view = [[UIView alloc] initWithFrame:cell.frame];
        [view setBackgroundColor:PHR_COLOR_SELECTED_SELL];
        cell.selectedBackgroundView = view;
    }
    
    [cell.textLabel setStyleRegularToLabelWithColor:PHR_COLOR_TEXT_MENU andSize:14.0];
    [cell.textLabel setText:[_arrayMenu objectAtIndex:indexPath.row]];
    
    NSString *nameImg = [_arrayMenuImageUnSelect objectAtIndex:indexPath.row];
    [cell.imageView setImage:[UIImage imageNamed:nameImg]];
    
    return cell;
}

- (CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath {
    return 44;
}

-(void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath {
    UITableViewCell *cell = [tableView cellForRowAtIndexPath:indexPath];
    NSString *nameImg = [_arrayMenuImageSelect objectAtIndex:indexPath.row];
    [cell.imageView setImage:[UIImage imageNamed:nameImg]];
    [cell.textLabel setTextColor:[UIColor whiteColor]];
    [self switchMenu:(int)indexPath.row];
}

- (void)tableView:(UITableView *)tableView didDeselectRowAtIndexPath:(NSIndexPath *)indexPath {
    UITableViewCell *cell = [tableView cellForRowAtIndexPath:indexPath];
    
    NSString *nameImg = [_arrayMenuImageUnSelect objectAtIndex:indexPath.row];
    [cell.imageView setImage:[UIImage imageNamed:nameImg]];
    [cell.textLabel setTextColor:PHR_COLOR_TEXT_MENU];
}

- (void)tableView:(UITableView *)tableView willDisplayCell:(UITableViewCell *)cell forRowAtIndexPath:(NSIndexPath *)indexPath {
    
    if ([tableView respondsToSelector:@selector(setSeparatorInset:)]) {
        [tableView setSeparatorInset:UIEdgeInsetsZero];
    }
    
    if ([tableView respondsToSelector:@selector(setLayoutMargins:)]) {
        [tableView setLayoutMargins:UIEdgeInsetsZero];
    }
    
    if ([cell respondsToSelector:@selector(setLayoutMargins:)]) {
        [cell setLayoutMargins:UIEdgeInsetsZero];
    }
    
}

- (void) switchMenu:(int)index {
    switch (index) {
        case MENU_DISPLAY_SETTING:{
             DisplaySettingViewController *displaySettingViewControllerl = [[DisplaySettingViewController alloc] initWithNibName:NSStringFromClass([DisplaySettingViewController class]) bundle:nil];
            [self.navigationController pushViewController:displaySettingViewControllerl animated:YES];
        }
            break;
        case MENU_HELP_CENTER:
//        {
//            HelpViewController *helpViewController = [[HelpViewController alloc] initWithNibName:NSStringFromClass([HelpViewController class]) bundle:nil];
//            [self.navigationController pushViewController:helpViewController animated:YES];
//        }

            [[UIApplication sharedApplication] openURL:[NSURL URLWithString:PHR_URL_HELP_CENTRE]];
            
            break;
        case MENU_ABOUT: {
            AboutViewController *aboutViewController = [[AboutViewController alloc] initWithNibName:NSStringFromClass([AboutViewController class]) bundle:nil];
            [self.navigationController pushViewController:aboutViewController animated:YES];
        }
            break;
        case MENU_TERM_POLICIES:
//        {
//            PolicyViewController *policyViewController = [[PolicyViewController alloc] initWithNibName:NSStringFromClass([PolicyViewController class]) bundle:nil];
//            [self.navigationController pushViewController:policyViewController animated:YES];
//        }
            [[UIApplication sharedApplication] openURL:[NSURL URLWithString:PHR_URL_TERM_POLICY]];
            break;
        case MENU_CHANGE_PASSWORD: {
            ChangePasswordViewController *changePasswordViewController = [[ChangePasswordViewController alloc] initWithNibName:NSStringFromClass([ChangePasswordViewController class]) bundle:nil];
            [self.navigationController pushViewController:changePasswordViewController animated:YES];
        }
            break;
        case MENU_LOGOUT:
            if (self.delegate && [self.delegate respondsToSelector:@selector(menuLeftLogout)]) {
              self.viewIndicator.hidden = NO;
                [[PHRClient instance] requestLogoutwithCompleted:^(id completion) {
                  self.viewIndicator.hidden = YES;
                  // Stop all sync timer
                  [[StorageManager instance] stopSyncBluetoothAndPHRData];
                  [[StorageManager instance] stopSyncDataToServer];
                  [[BluetoothManager instance] stopScanDevice];
                  [self.delegate menuLeftLogout];
                  
                } error:^(NSString *error) {
                  self.viewIndicator.hidden = YES;
                }];
              
            }
            break;
            
        case MENU_BLUETOOTH:{
            BluetoothDeviceConnectViewController *bluetoothViewController = [[BluetoothDeviceConnectViewController alloc] initWithNibName:NSStringFromClass([BluetoothDeviceConnectViewController class]) bundle:nil];
            [self.navigationController pushViewController:bluetoothViewController animated:YES];
        }
            break;
            
        case MENU_SYNCHRONIZE_HEATHKIT:{
            [[HealthKitManager sharedManager] setOnAuthorizedSuccess:^(){
                dispatch_async(dispatch_get_main_queue(), ^(){
                   
                });
            }];
            SynchronizeHealthKitViewController *synchronizeHealthKitViewController = [[SynchronizeHealthKitViewController alloc] initWithNibName:NSStringFromClass([SynchronizeHealthKitViewController class]) bundle:nil];
            [self.navigationController pushViewController:synchronizeHealthKitViewController animated:YES];
        }
            break;
            
        default:
            break;
    }
}

- (void)requestAuthorizationStatus:(NSNotification *)notification {
    NSString *status = (NSString*)notification.object;
    if([status isEqualToString:@"success"]){
        BluetoothDeviceConnectViewController *synchronizeHealthKitViewController = [[BluetoothDeviceConnectViewController alloc] initWithNibName:NSStringFromClass([BluetoothDeviceConnectViewController class]) bundle:nil];
        [self.navigationController pushViewController:synchronizeHealthKitViewController animated:YES];
    }
}

- (IBAction)actionBackToDashbroad:(id)sender {
    [[NSNotificationCenter defaultCenter] postNotificationName:kNotifyBackToDashbroad object:nil];
}
@end
