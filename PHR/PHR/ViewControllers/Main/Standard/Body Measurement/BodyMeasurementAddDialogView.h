//
//  BodyMeasurementAddDialogView.h
//  PHR
//
//  Created by NextopHN on 5/21/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "TableItemModel.h"

@class BodyMeasurementAddDialogView;

@protocol BodyMeasurementAddDialogViewDelegate
- (void)selectedIndexMenuItem:(NSInteger)index andList:(BodyMeasurementAddDialogView*)list;
@end

@interface BodyMeasurementAddDialogView : UIView <UITableViewDelegate,UITableViewDataSource>
@property (weak, nonatomic) IBOutlet UITableView *tableMenuItem;
@property (weak, nonatomic) IBOutlet NSLayoutConstraint *constraintTableHeight;
@property (strong, nonatomic) NSArray<TableItemModel*> *arrayMenuItem;
@property (weak, nonatomic) id<BodyMeasurementAddDialogViewDelegate> delegate;
@property (weak, nonatomic) IBOutlet UIView *viewUnderTableMenu;

- (void)setupTableData:(NSArray*)arrayItem;
@end
