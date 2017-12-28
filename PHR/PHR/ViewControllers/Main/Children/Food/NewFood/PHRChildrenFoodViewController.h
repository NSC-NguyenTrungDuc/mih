//
//  PHRChildrenFoodViewController.h
//  PHR
//
//  Created by Nguyen Thanh Tung on 6/7/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "Base2ViewController.h"
#import "ChildrenFoodModel.h"
#import "ChildrenFoodTableViewCell.h"
#import "FoodChildrenViewController.h"
#import "SWTableViewCell.h"
#import "PHRChart.h"


@interface PHRChildrenFoodViewController : Base2ViewController <MDTabBarDelegate,UITableViewDelegate,UITableViewDataSource, SWTableViewCellDelegate>

@property (weak, nonatomic) IBOutlet PHRChart *chartFoodDetail;
@property (weak, nonatomic) IBOutlet UIImageView *backgroundImage;
@property (weak, nonatomic) IBOutlet TabbarFourButton *tabbarDuration;
@property (weak, nonatomic) IBOutlet UILabel *labelTableHeader;
@property (weak, nonatomic) IBOutlet UITableView *tableViewContent;

@property (strong, nonatomic) NSMutableArray<PHRSample*> *arrayChartData;
@property (strong, nonatomic) NSMutableArray<ChildrenFoodModel*> *arrayTableViewData;
@end
