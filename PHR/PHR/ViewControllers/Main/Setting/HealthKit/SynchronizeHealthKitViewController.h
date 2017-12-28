//
//  SynchronizeHealthKitViewController.h
//  PHR
//
//  Created by Nguyen Thanh Tung on 6/10/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "Base2ViewController.h"

@interface SynchronizeHealthKitViewController : Base2ViewController

@property (weak, nonatomic) IBOutlet UILabel *lbAllowReadData;
@property (weak, nonatomic) IBOutlet UISwitch *switchAllowReadData;
@property (weak, nonatomic) IBOutlet UILabel *lbAllowWriteData;
@property (weak, nonatomic) IBOutlet UISwitch *switchAllowWriteData;
@property (weak, nonatomic) IBOutlet UISwitch *switchSyncDataBy3G;
@property (weak, nonatomic) IBOutlet UIImageView *imgBackground;
@property (weak, nonatomic) IBOutlet UILabel *lbHeaderAllowSyncData;
@property (weak, nonatomic) IBOutlet UILabel *lbHeaderSyncSetting;
@property (weak, nonatomic) IBOutlet UILabel *lbAllowSync3G;

- (IBAction)onSwitchReadValueChanged:(id)sender;
- (IBAction)onSwitchWriteValueChanged:(id)sender;
- (IBAction)onSwitchAllowSyncValueChanged:(id)sender;
@end
