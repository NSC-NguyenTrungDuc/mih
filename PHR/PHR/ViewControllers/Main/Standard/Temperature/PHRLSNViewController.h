//
//  PHRLSNViewController.h
//  PHR
//
//  Created by DEV-MinhNN on 1/29/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "Base2ViewController.h"

@interface PHRLSNViewController : Base2ViewController

@property (weak, nonatomic) IBOutlet UIView *viewSeparator;
@property (weak, nonatomic) IBOutlet UIView *viewUpList;

@property (weak, nonatomic) IBOutlet UILabel *lbtextDailyAverageLD;
@property (weak, nonatomic) IBOutlet UILabel *lbTextAlert;
@property (weak, nonatomic) IBOutlet UIImageView *backgroundStandard;

@property (weak, nonatomic) IBOutlet UITableView *tableViewList;
@property (weak, nonatomic) IBOutlet UIImageView *backgroundImg;
@property (weak, nonatomic) IBOutlet UIView *viewWhite;
@property (weak, nonatomic) IBOutlet UIView *viewChart;

@property (strong, nonatomic) UIRefreshControl *refreshControl;

@end
