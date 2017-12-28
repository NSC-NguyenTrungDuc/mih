//
//  BabyMilkTableViewCell.h
//  PHR
//
//  Created by DEV-MinhNN on 11/6/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface BabyMilkTableViewCell : UITableViewCell

@property (weak, nonatomic) IBOutlet UITextField *txtVolumeOrTime;
@property (weak, nonatomic) IBOutlet UITextField *txtMilkType;
@property (weak, nonatomic) IBOutlet UITextField *txtKcal;

@property (weak, nonatomic) IBOutlet UIView *viewContain;
@property (weak, nonatomic) IBOutlet UILabel *lbTime;
@property (weak, nonatomic) IBOutlet UILabel *lbAmOrPm;

@property (weak, nonatomic) IBOutlet UIImageView *imgNoteClock;
@property (weak, nonatomic) IBOutlet UIButton *btnAddNewBabyMilk;

- (void)setUpViewCell;

@end
