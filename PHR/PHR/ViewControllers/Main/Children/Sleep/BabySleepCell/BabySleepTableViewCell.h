//
//  BabySleepTableViewCell.h
//  PHR
//
//  Created by DEV-MinhNN on 11/4/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "SWTableViewCell.h"

@interface BabySleepTableViewCell : SWTableViewCell

@property (weak, nonatomic) IBOutlet UILabel *lbMorningSleep;
@property (weak, nonatomic) IBOutlet UILabel *lbAfternoonSleep;
@property (weak, nonatomic) IBOutlet UILabel *lbNightSleep;

@property (weak, nonatomic) IBOutlet UILabel *lbMorning;
@property (weak, nonatomic) IBOutlet UILabel *lbAfternoon;
@property (weak, nonatomic) IBOutlet UILabel *lbNight;
@end
