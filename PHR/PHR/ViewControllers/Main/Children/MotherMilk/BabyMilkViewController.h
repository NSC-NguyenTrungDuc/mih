//
//  BabyMilkViewController.h
//  PHR
//
//  Created by Nguyen Thanh Tung on 7/14/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "Base2ViewController.h"
#import "TopMenuScrollView.h"
#import "StandardDetailTableViewCell.h"

@interface BabyMilkViewController : Base2ViewController <MDTabBarDelegate,UITableViewDelegate, UITableViewDataSource, SWTableViewCellDelegate,TopMenuDelegate, UIScrollViewDelegate, UIGestureRecognizerDelegate>
@property (weak, nonatomic) IBOutlet TabbarFourButton *tabbarDuration;
@property (weak, nonatomic) IBOutlet UITableView *tableView;
@property (weak, nonatomic) IBOutlet TopMenuScrollView *tabbarType;
@property (weak, nonatomic) IBOutlet UIView *viewTriangle;
@property (weak, nonatomic) IBOutlet UILabel *labelTitleSummary;

@property (weak, nonatomic) IBOutlet UILabel *labelAverage;
@property (weak, nonatomic) IBOutlet PHRChart *chartView;

@property (weak, nonatomic) IBOutlet UIView *viewAdd;
@property (weak, nonatomic) IBOutlet UILabel *labelAdd;
@property (weak, nonatomic) IBOutlet NSLayoutConstraint *constraintTblAndSave;


- (IBAction)onBtnAddClicked:(id)sender;
@property (strong, nonatomic) NSMutableArray<PHRSample *> *arrayChartMotherData;
@property (strong, nonatomic) NSMutableArray<PHRSample *> *arrayChartBottleData;
@property (assign, nonatomic) ChartContentType milkTypeIndex;
@property (nonatomic) PHRGroupTypeMilk pHRGroupTypeMilk;
@property (strong, nonatomic) NSMutableArray<BabyMilkModel*> *arrayMotherData;
@property (strong, nonatomic) NSMutableArray<BabyMilkModel*> *arrayBottleData;
@property (weak, nonatomic) IBOutlet UIActivityIndicatorView *viewIndicatorChart;
@property (weak, nonatomic) IBOutlet UIActivityIndicatorView *viewIndicatorTable;

@end
