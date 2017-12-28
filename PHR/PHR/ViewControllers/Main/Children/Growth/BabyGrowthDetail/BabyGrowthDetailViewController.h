//
//  StandardFoodDetailViewController.h
//  PHR
//
//  Created by Nguyen Thanh Tung on 7/14/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "Base2ViewController.h"
#import "BabyGrowthAddViewController.h"
#import "StandardDetailTableViewCell.h"
#import "StorageManager.h"
#import "TopMenuScrollView.h"

@interface BabyGrowthDetailViewController : Base2ViewController <MDTabBarDelegate,UITableViewDelegate, UITableViewDataSource, SWTableViewCellDelegate,TopMenuDelegate, UIScrollViewDelegate, UIGestureRecognizerDelegate>
@property (weak, nonatomic) IBOutlet UIImageView *imageBackground;
@property (weak, nonatomic) IBOutlet TabbarFourButton *tabbarDuration;
@property (weak, nonatomic) IBOutlet UITableView *tableView;
@property (weak, nonatomic) IBOutlet TopMenuScrollView *tabbarType;
@property (weak, nonatomic) IBOutlet UIView *viewTriangle;
@property (weak, nonatomic) IBOutlet UILabel *labelSummary;

@property (weak, nonatomic) IBOutlet UILabel *labelAverage;
@property (weak, nonatomic) IBOutlet PHRChart *chartView;
@property (assign, nonatomic) BabyGrowthType typeIndex;
@property (weak, nonatomic) IBOutlet UIView *viewAdd;
@property (weak, nonatomic) IBOutlet UILabel *labelAdd;
@property (weak, nonatomic) IBOutlet NSLayoutConstraint *constraintTblAndSave;
@property (weak, nonatomic) IBOutlet UIActivityIndicatorView *viewIndicatorChart;
@property (weak, nonatomic) IBOutlet UIActivityIndicatorView *viewIndicatorTable;


- (IBAction)onBtnAddClicked:(id)sender;
@property (strong, nonatomic) NSMutableArray<PHRSample*> *arrayChartData;
@property (strong, nonatomic) NSMutableArray<BabyGrowth*> *arrayTableViewData;
@end
