//
//  BabyHomeMilkCell.h
//  PHR
//
//  Created by Luong Le Hoang on 10/7/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "BabyHomeItem.h"

@class BabyHomeCell;
typedef void(^BabyHomeCellAction)(BabyHomeCell *babyCell);

@interface BabyHomeCell : UITableViewCell <UITableViewDelegate, UITableViewDataSource>

// Time
@property (weak, nonatomic) IBOutlet UIView *viewTime;
@property (weak, nonatomic) IBOutlet UILabel *labelHour;
@property (weak, nonatomic) IBOutlet UILabel *labelAMPM;

// Content
@property (weak, nonatomic) IBOutlet UIView *viewContent;
@property (weak, nonatomic) IBOutlet UITableView *tableContent;
@property (weak, nonatomic) IBOutlet UIImageView *imageMenutype;
@property (weak, nonatomic) IBOutlet UILabel *lblDateTimeRecord;

@property (nonatomic, assign) PHRBabyGroupType type;
@property (nonatomic, weak) BabyHomeItem *model;
@property (nonatomic, copy) BabyHomeCellAction actionQuickFilter;
@property (nonatomic, strong) id babyModel;

- (void)setupViewContentWithType:(PHRBabyGroupType)type andModel:(id)model andShowSymbol:(BOOL)isShow;
- (IBAction)actionClickIcon:(id)sender;

@end
