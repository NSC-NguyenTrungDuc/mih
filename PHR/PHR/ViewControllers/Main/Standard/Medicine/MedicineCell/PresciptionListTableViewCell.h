//
//  PresciptionListTableViewCell.h
//  PHR
//
//  Created by BillyMobile on 5/18/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "SWTableViewCell.h"

@interface PresciptionListTableViewCell : SWTableViewCell<SWTableViewCellDelegate>

@property (weak, nonatomic) IBOutlet UIView *viewContent;
@property (weak, nonatomic) IBOutlet UIView *viewSeparator;
@property (weak, nonatomic) IBOutlet UILabel *lblDateTime;
@property (weak, nonatomic) IBOutlet UILabel *lblPresciption;
@property (weak, nonatomic) IBOutlet UIView *viewRight;
@property (weak, nonatomic) IBOutlet UILabel *lblComplete;
@property (nonatomic)  BOOL isActive;

@property (copy, nonatomic) void (^deleteCallBack)();


@end
