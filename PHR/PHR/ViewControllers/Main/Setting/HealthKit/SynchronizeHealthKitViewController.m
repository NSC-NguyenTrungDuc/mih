//
//  SynchronizeHealthKitViewController.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 6/10/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "SynchronizeHealthKitViewController.h"
#import "HealthKitManager.h"
#import "PHRSample.h"

@interface SynchronizeHealthKitViewController ()

@end

@implementation SynchronizeHealthKitViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    [self getReadWriteValueFromLocal];
    [self setupUI];
   
}

- (void)setupUI {
    self.view.backgroundColor = [UIColor whiteColor];
    [self setupNavigationBarTitle:kLocalizedString(kTitleSyncHealthKit) titleIcon:@"Icon_Sync" rightItem:nil];
    self.lbAllowReadData.text = kLocalizedString(kAllowReadData);
    self.lbAllowWriteData.text = kLocalizedString(kAllowWriteData);
    self.lbAllowSync3G.text = kLocalizedString(kAllowSync3G);
    self.lbHeaderSyncSetting.text = kLocalizedString(kSyncSetting);
    self.lbHeaderAllowSyncData.text = kLocalizedString(kAllowAccessData);

}

//- (void)initData {
//    if ([self.switchAllowWriteData isOn]) {
//        
//    }
//    if ([self.switchAllowReadData isOn]) {
//        //Read Data
//        //Test
//        NSString *str =@"3/15/2016 9:15 PM";
//        NSDateFormatter *formatter = [[NSDateFormatter alloc]init];
//        [formatter setDateFormat:@"MM/dd/yyyy HH:mm a"];
//        NSDate *date = [formatter dateFromString:str];
//        [[HealthKitManager sharedManager] readDataFromHealthKit:date endDate:[NSDate date]];
//    }
//}

- (void)getReadWriteValueFromLocal {
    BOOL read = [NSUtils boolForKey:PHRJNKeyChainAllowSynchronizeHealthKitRead defaultValue:true];
    BOOL write = [NSUtils boolForKey:PHRJNKeyChainAllowSynchronizeHealthKitWrite defaultValue:true];
    BOOL allowSync3G = [NSUtils boolForKey:PHRJNKeyChainAllowSynchronizeHealthKitBy3G defaultValue:false];
    
    [self.switchAllowReadData setOn:read animated:true];
    [self.switchAllowWriteData setOn:write animated:true];
    [self.switchSyncDataBy3G setOn:allowSync3G animated:true];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (void)viewWillAppear:(BOOL)animated {
    [super viewWillAppear:animated];
    [self setImageToBackgroundStandard:self.imgBackground];
}

- (IBAction)onSwitchReadValueChanged:(id)sender {
    [NetworkManager saveSettingSynchronizeHealthKit:[sender isOn] withKey:PHRJNKeyChainAllowSynchronizeHealthKitRead];
}

- (IBAction)onSwitchWriteValueChanged:(id)sender {
    [NetworkManager saveSettingSynchronizeHealthKit:[sender isOn] withKey:PHRJNKeyChainAllowSynchronizeHealthKitWrite];
}

- (IBAction)onSwitchAllowSyncValueChanged:(id)sender {
    [NetworkManager saveSettingSynchronizeHealthKit:[sender isOn] withKey:PHRJNKeyChainAllowSynchronizeHealthKitBy3G];
}


/*
#pragma mark - Navigation

// In a storyboard-based application, you will often want to do a little preparation before navigation
- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender {
    // Get the new view controller using [segue destinationViewController].
    // Pass the selected object to the new view controller.
}
*/


@end
