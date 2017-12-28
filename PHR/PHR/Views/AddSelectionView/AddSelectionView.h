//
//  AddSelectionView.h
//  PHR
//
//  Created by Nguyen Thanh Tung on 5/18/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "AddSelectionTableViewCell.h"

@interface AddSelectionView : UIView <UITableViewDelegate, UITableViewDataSource>

+ (AddSelectionView*)createView: (NSArray*)arrayItem;
@property (weak, nonatomic) IBOutlet UIView *viewMain;
@property (weak, nonatomic) IBOutlet UILabel *lbTitle;
@property (weak, nonatomic) IBOutlet UITableView *tableView;
@property (weak, nonatomic) IBOutlet UIView *viewUnder;

- (void)showInView:(UIView*)parentView;
- (void)hiddenInView;
@end
