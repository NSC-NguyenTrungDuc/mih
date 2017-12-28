//
//  BodyMeasurementList.h
//  PHR
//
//  Created by NextopHN on 5/19/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "TableItemModel.h"

@class BodyMeasurementList;
@protocol BodyMeasurementListDelegate
- (void)selectedIndexOfList:(NSInteger)index andList:(BodyMeasurementList*)list;
@end

@interface BodyMeasurementList : UIView <UITableViewDataSource,UITableViewDelegate>
@property (weak, nonatomic) IBOutlet UITableView *tableViewContent;
@property (strong, nonatomic) NSArray<TableItemModel*> *arrayListItemType;
@property (weak, nonatomic) id<BodyMeasurementListDelegate> delegate;

- (void)setupTableData:(NSArray*)arrayItem;
@end
