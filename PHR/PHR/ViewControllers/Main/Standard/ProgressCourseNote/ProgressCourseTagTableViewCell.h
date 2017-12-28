//
//  ProgressCourseTagTableViewCell.h
//  PHR
//
//  Created by NextopHN on 4/14/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface ProgressCourseTagTableViewCell : UITableViewCell <UITableViewDataSource,UITableViewDelegate>
//@property (weak, nonatomic) IBOutlet UITableView *tableViewTag;
@property (nonatomic,strong) NSMutableArray *arrayEMRPlanNotes;
-(void)fillData:(NSMutableArray*)arrayData;
@end
