//
//  ChildrenFoodTableViewCell.h
//  PHR
//
//  Created by Nguyen Thanh Tung on 6/7/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "ChildrenFoodModel.h"
#import "SWTableViewCell.h"

@interface ChildrenFoodTableViewCell : SWTableViewCell
@property (weak, nonatomic) IBOutlet UIImageView *imageViewCalendar;
@property (weak, nonatomic) IBOutlet UILabel *labelDate;
@property (weak, nonatomic) IBOutlet UILabel *labelValue;

- (void) setupUI:(ChildrenFoodModel*)model;
@end
