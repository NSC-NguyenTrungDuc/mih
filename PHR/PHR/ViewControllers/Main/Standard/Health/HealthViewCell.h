//
//  HealthViewCell.h
//  PHR
//
//  Created by NextopHN on 2/3/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface HealthViewCell : UITableViewCell
@property (weak, nonatomic) IBOutlet UIView *viewBigBound;
@property (weak, nonatomic) IBOutlet UILabel *labelDate;

@property (weak, nonatomic) IBOutlet UIImageView *imageViewWeight;
@property (weak, nonatomic) IBOutlet UIImageView *imageViewHeight;
@property (weak, nonatomic) IBOutlet UIImageView *imageViewBlood;
@property (weak, nonatomic) IBOutlet UIView *viewWeight;
@property (weak, nonatomic) IBOutlet UIView *viewHeight;
@property (weak, nonatomic) IBOutlet UIView *viewBlood;

@property (weak, nonatomic) IBOutlet UILabel *labelTitleWeight;
@property (weak, nonatomic) IBOutlet UILabel *labelTitleHeight;
@property (weak, nonatomic) IBOutlet UILabel *labelHighLowBloodPressure;

@property (weak, nonatomic) IBOutlet UILabel *labelValueWeight;
@property (weak, nonatomic) IBOutlet UILabel *labelValueHeight;
@property (weak, nonatomic) IBOutlet UILabel *labelValueBloodPressure;
- (void)setDataTotableViewCell:(HealthItem *)standardHealth;
@end
