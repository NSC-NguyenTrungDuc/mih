//
//  TagTableViewCell.h
//  PHR
//
//  Created by NextopHN on 4/14/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "EMRPlan.h"

@interface TagTableViewCell : UITableViewCell{
}

@property (nonatomic, copy) void(^actionOpenTagUrl)(EMRPlan *emr);

@property (weak, nonatomic) IBOutlet UILabel *labelKey;
@property (weak, nonatomic) IBOutlet UILabel *labelValue;
@property (weak, nonatomic) IBOutlet UIView *viewKey;
//@property (weak, nonatomic) IBOutlet UIView *viewValue;
@property (weak, nonatomic) IBOutlet UIButton *btnShow;

- (IBAction)actionShow:(id)sender;
- (void)setupCellWithData:(EMRPlan*)emr;
@end
