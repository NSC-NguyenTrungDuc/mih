//
//  HealthListViewController.h
//  PHR
//
//  Created by NextopHN on 2/3/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "Base2ViewController.h"

@interface HealthListViewController : Base2ViewController <UITableViewDataSource,UITableViewDelegate>

@property (weak, nonatomic) IBOutlet UIImageView *imageBackground;
@property (weak, nonatomic) IBOutlet UIView *viewSeparateHealthList;
@property (weak, nonatomic) IBOutlet UIView *viewUpperHealthList;
@property (weak, nonatomic) IBOutlet UIView *viewBottomHealthList;

@property (weak, nonatomic) IBOutlet UILabel *labelHealth;
@property (weak, nonatomic) IBOutlet UILabel *labelAverage;
@property (weak, nonatomic) IBOutlet UIView *viewChart;

@property (weak, nonatomic) IBOutlet UIView *viewBMIStage;
@property (weak, nonatomic) IBOutlet UIImageView* imageBackgroundBottom;
@property (weak, nonatomic) IBOutlet UILabel *labelUnderWeight;
@property (weak, nonatomic) IBOutlet UILabel *labelNormal;
@property (weak, nonatomic) IBOutlet UILabel *labelOverWeight;
@property (weak, nonatomic) IBOutlet UILabel *labelObesity;
@property (weak, nonatomic) IBOutlet UILabel *labelExtremeObesity;

@property (weak, nonatomic) IBOutlet UIView *viewColorUnderWeight;
@property (weak, nonatomic) IBOutlet UIView *viewColorNormal;
@property (weak, nonatomic) IBOutlet UIView *viewColorOverWeight;
@property (weak, nonatomic) IBOutlet UIView *viewColorObesity;
@property (weak, nonatomic) IBOutlet UIView *viewColorExtremeObesity;

@property (weak, nonatomic) IBOutlet UITableView *tableViewHealthList;
//@property (weak, nonatomic) IBOutlet UIImageView *imageTimeLine;
@property (weak, nonatomic) IBOutlet UILabel *labelTimeLine;
@property (weak, nonatomic) IBOutlet UIView *viewTimeLine;


@end

