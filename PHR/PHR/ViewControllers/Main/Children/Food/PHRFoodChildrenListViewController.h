//
//  PHRFoodChildrenListViewController.h
//  PHR
//
//  Created by NextopHN on 3/23/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "Base2ViewController.h"

@interface PHRFoodChildrenListViewController : Base2ViewController
@property (weak, nonatomic) IBOutlet UIView *viewTop;
@property (weak, nonatomic) IBOutlet UIView *viewBottom;
@property (weak, nonatomic) IBOutlet UIImageView *imageViewBottomBackground;
@property (weak, nonatomic) IBOutlet UILabel *lbtextDailyAverage;
@property (weak, nonatomic) IBOutlet UILabel *lbTextTitle;
@property (weak, nonatomic) IBOutlet UITableView *tableViewListFood;
@property (weak, nonatomic) IBOutlet UIView *viewChart;
@property (strong, nonatomic) UIRefreshControl *refreshControl;
@end
