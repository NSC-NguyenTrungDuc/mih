//
//  FoodList.h
//  PHR
//
//  Created by Nguyen Thanh Tung on 5/30/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>
@class FoodList;
@protocol FoodListDelegate
- (void)selectedIndexOfList:(NSInteger)index andList:(FoodList*)list;
@end

@interface FoodList : UIView <UITableViewDataSource,UITableViewDelegate>

@property (weak, nonatomic) IBOutlet UITableView *tableViewContent;
@property (strong, nonatomic) id<FoodListDelegate> delegate;

@end
