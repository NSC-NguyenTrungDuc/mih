//
//  BodyMeasurementList.h
//  PHR
//
//  Created by NextopHN on 5/19/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "TableItemModel.h"

@class StandardList;
@protocol ListDelegate
- (void)selectedIndexOfList:(NSInteger)index andList:(StandardList*)list;
@end

@interface StandardList : UIView <UITableViewDataSource,UITableViewDelegate>
@property (weak, nonatomic) IBOutlet UITableView *tableViewContent;
@property (strong, nonatomic) NSArray<TableItemModel*> *arrayListItemType;
@property (weak, nonatomic) id<ListDelegate> delegate;

- (void)setupTableData:(NSArray*)arrayItem;
@end
