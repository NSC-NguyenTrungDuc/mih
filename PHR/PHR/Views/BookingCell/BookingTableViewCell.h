//
//  BookingTableViewCell.h
//  PHR
//
//  Created by Tran Hoang Ha on 9/8/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface BookingTableViewCell : UITableViewCell
+ (CGFloat)cellHeight;
- (void)bindViewModel:(id)viewModel;
@end
