//
//  StandardFitnessTableViewCell.h
//  PHR
//
//  Created by Nguyen Thanh Tung on 7/14/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "SWTableViewCell.h"


@interface StandardFitnessTableViewCell : SWTableViewCell
@property (weak, nonatomic) IBOutlet UIView *viewValue;
@property (weak, nonatomic) IBOutlet UILabel *labelValue;
@property (weak, nonatomic) IBOutlet UILabel *labelDateTime;
@property (weak, nonatomic) IBOutlet UILabel *labelRanking;
- (void) setupUI:(FitnessModel*)model type:(ChartFitnessType)type color:(UIColor*)color;
@end
