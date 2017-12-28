//
//  PHRBabySleepViewController.h
//  PHR
//
//  Created by Luong Le Hoang on 10/10/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "Base2ViewController.h"
#import "SWTableViewCell.h"

@interface PHRBabySleepViewController : Base2ViewController <UITableViewDelegate, UITableViewDataSource, SWTableViewCellDelegate> {
    BOOL isRunTime;
    NSTimer *myTimer;
    int currentTimeInSeconds;
    NSDate *myCurrentDate;
    int numberPage;
    NSMutableArray *_listBabySleep;
    NSMutableArray *_listDateTime;
}

@property (weak, nonatomic) IBOutlet UIButton *btnRunTime;
@property (weak, nonatomic) IBOutlet UILabel *lbHour;
@property (weak, nonatomic) IBOutlet UILabel *lbMinutes;
@property (weak, nonatomic) IBOutlet UILabel *lbSeconds;

@property (weak, nonatomic) IBOutlet NSLayoutConstraint *constraintTableAndAdd;

@property (weak, nonatomic) IBOutlet UIView *viewDownBabySleep;
@property (weak, nonatomic) IBOutlet UITableView *tableViewSleep;
@property (nonatomic) NSMutableIndexSet *expandedSections;

@property (weak, nonatomic) IBOutlet UILabel *labelTextHours;
@property (weak, nonatomic) IBOutlet UIView *viewSave;
@property (weak, nonatomic) IBOutlet UILabel *labelSave;
@property (weak, nonatomic) IBOutlet UIButton *btnSave;
@property (weak, nonatomic) IBOutlet UILabel *labelTextMinutes;
@property (weak, nonatomic) IBOutlet UILabel *labelTextSeconds;
- (IBAction)onTapBtnSave:(id)sender;

@end
