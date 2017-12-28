//
//  AddNewDrugTableViewCell.h
//  PHR
//
//  Created by BillyMobile on 5/19/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "SWTableViewCell.h"

@interface AddNewDrugTableViewCell : SWTableViewCell<SWTableViewCellDelegate>
@property (weak, nonatomic) IBOutlet UIView *viewContent;
@property (weak, nonatomic) IBOutlet UILabel *lblRemider;
@property (weak, nonatomic) IBOutlet UILabel *lblDrugName;
@property (weak, nonatomic) IBOutlet UIImageView *imgDrugIcon;

@property (copy, nonatomic) void (^deleteCallBack)();

@end
