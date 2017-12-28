//
//  ListDiapersViewController.h
//  PHR
//
//  Created by DEV-MinhNN on 10/9/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "Base2ViewController.h"
#import "DiaperChartData.h"
#import "SWTableViewCell.h"

@interface ListDiapersViewController : Base2ViewController <SWTableViewCellDelegate>

@property (weak, nonatomic) IBOutlet UIView *viewDownListDiapers;

@property (weak, nonatomic) IBOutlet UITableView *tableViewListDiapers;
@property (weak, nonatomic) IBOutlet PHRChart *chartView;

@property (nonatomic, strong) NSMutableArray *listDiapers;
@property (nonatomic, strong) NSMutableArray *listDiapersChart;
@property (weak, nonatomic) IBOutlet NSLayoutConstraint *constraintTableAndAdd;
@property (weak, nonatomic) IBOutlet UIView *viewAdd;
@property (weak, nonatomic) IBOutlet UILabel *lblAddData;
@property (weak, nonatomic) IBOutlet UIActivityIndicatorView *viewIndicatorTable;

- (IBAction)actionAddData:(id)sender;
@end
