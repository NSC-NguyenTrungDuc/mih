//
//  OldDeviceTableViewCell.h
//  PHR
//
//  Created by BillyMobile on 6/10/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "SWTableViewCell.h"

@interface OldDeviceTableViewCell : SWTableViewCell<SWTableViewCellDelegate>

@property (weak, nonatomic) IBOutlet UILabel *lblDeviceName;
@property (weak, nonatomic) IBOutlet UILabel *lblUserName;
@property (weak, nonatomic) IBOutlet UILabel *lblStatus;

@property (copy, nonatomic) void (^deleteCallBack)();
@end
