//
//  ProgressCourseHeaderTableViewCell.h
//  PHR
//
//  Created by NextopHN on 4/14/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface ProgressCourseHeaderTableViewCell : UITableViewCell
@property (weak, nonatomic) IBOutlet UIImageView *imageViewCalendar;
@property (weak, nonatomic) IBOutlet UILabel *labelType;
@property (weak, nonatomic) IBOutlet UIImageView *imageArrowDown;
@property (weak, nonatomic) IBOutlet UIImageView *imageType;
@property (weak, nonatomic) IBOutlet UILabel *labelDateTime;
@end
