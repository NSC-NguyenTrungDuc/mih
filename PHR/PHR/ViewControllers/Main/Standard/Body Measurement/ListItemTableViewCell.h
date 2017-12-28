//
//  ListItemTableViewCell.h
//  PHR
//
//  Created by NextopHN on 5/19/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "TableItemModel.h"

@interface ListItemTableViewCell : UITableViewCell
@property (weak, nonatomic) IBOutlet UIImageView *imageViewIcon;
@property (weak, nonatomic) IBOutlet UILabel *labelContent;
@property (weak, nonatomic) IBOutlet NSLayoutConstraint *constraintLeaderLabelContent;
@property (assign, nonatomic) TableItemModel *type;
- (void)setupContentWithType:(TableItemModel*)type;
@end
