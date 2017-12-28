//
//  FitnessListView.h
//  PHR
//
//  Created by Nguyen Thanh Tung on 5/18/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "FitnessListTableViewCell.h"
#import "FitnessListModel.h"
#import "FitnessDetailViewController.h"
#import "StandardFitnessViewController.h"

@interface FitnessListView : UIView <UITableViewDelegate, UITableViewDataSource>

@property (weak, nonatomic) IBOutlet UITableView *tableView;
@property(strong,nonatomic) UINavigationController *navControl;
@end
