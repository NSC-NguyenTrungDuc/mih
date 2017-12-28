//
//  PHRLifeStyleNoteViewController.h
//  PHR
//
//  Created by DEV-MinhNN on 2/5/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "Base2ViewController.h"
#import "MDTabBar.h"
#import "PHRChart.h"
#import "PHRChartUtils.h"
#import "PHRChart.h"
#import "SWTableViewCell.h"

@interface PHRLifeStyleNoteViewController : Base2ViewController <SWTableViewCellDelegate,MDTabBarDelegate>

@property (weak, nonatomic) IBOutlet UITableView *tableViewLifeStyleNote;
@property (weak, nonatomic) IBOutlet PHRChart *chartLifeStyleDetail;
@property (weak, nonatomic) IBOutlet UIImageView *backgroundImage;
@property (weak, nonatomic) IBOutlet TabbarFourButton *tabbarFourButton;
@property (weak, nonatomic) IBOutlet UILabel *lblAddData;
@property (weak, nonatomic) IBOutlet UIButton *btnAddData;
@property (weak, nonatomic) IBOutlet UIView *viewAdd;
@property (weak, nonatomic) IBOutlet NSLayoutConstraint *constraintTableAndAdd;
@property (weak, nonatomic) IBOutlet UIActivityIndicatorView *viewIndicatorTable;
@property (weak, nonatomic) IBOutlet UIActivityIndicatorView *viewIndicatorChart;
- (IBAction)actionAddData:(id)sender;



@end
