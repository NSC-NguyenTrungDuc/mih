//
//  BodyMeasurementDetailViewController.h
//  PHR
//
//  Created by Nguyen Thanh Tung on 7/15/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "Base2ViewController.h"
#import "StorageManager.h"
#import "TopMenuScrollView.h"
#import "SWTableViewCell.h"
#import "TriangleView.h"
#import "StandardDetailTableViewCell.h"
#import "StandardBodyMeasurementAddViewController.h"
#import "MasterDataModel.h"

@interface BodyMeasurementDetailViewController : Base2ViewController <MDTabBarDelegate,UITableViewDelegate, UITableViewDataSource, SWTableViewCellDelegate,TopMenuDelegate, UIScrollViewDelegate, UIGestureRecognizerDelegate>

@property (weak, nonatomic) IBOutlet UIButton *btnAddData;
@property (weak, nonatomic) IBOutlet UIImageView *imageBackground;
@property (weak, nonatomic) IBOutlet TabbarFourButton *tabbarDuration;
@property (weak, nonatomic) IBOutlet PHRChart *chartView;
@property (weak, nonatomic) IBOutlet UIView *viewTriangle;
@property (weak, nonatomic) IBOutlet TopMenuScrollView *tabbarType;
@property (weak, nonatomic) IBOutlet UILabel *labelSummary;

@property (weak, nonatomic) IBOutlet UILabel *labelAverage;
@property (weak, nonatomic) IBOutlet UITableView *tableView;
@property (weak, nonatomic) IBOutlet UIView *viewAdd;
@property (weak, nonatomic) IBOutlet UILabel *labelAdd;
@property (weak, nonatomic) IBOutlet NSLayoutConstraint *constraintTableAndAdd;
@property (weak, nonatomic) IBOutlet UIActivityIndicatorView *viewIndicatorTable;
@property (weak, nonatomic) IBOutlet UIActivityIndicatorView *viewIndicatorChart;

@property (assign, nonatomic) BodyMeasurementType typeIndex;

- (IBAction)onBtnAddClicked:(id)sender;
@property (strong, nonatomic) NSMutableArray<PHRSample*> *arrayChartData;
@property (strong, nonatomic) NSMutableArray<BodyMeasurementModel*> *arrayTableViewData;

@end
