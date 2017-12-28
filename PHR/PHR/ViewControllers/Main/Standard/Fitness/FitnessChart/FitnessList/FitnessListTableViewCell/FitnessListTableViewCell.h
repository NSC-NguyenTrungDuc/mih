//
//  FitnessListTableViewCell.h
//  PHR
//
//  Created by Nguyen Thanh Tung on 5/18/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface FitnessListTableViewCell : UITableViewCell
@property (weak, nonatomic) IBOutlet UIView *viewSeparatorTop;
@property (weak, nonatomic) IBOutlet UIImageView *imgvThumbnail;
@property (weak, nonatomic) IBOutlet UILabel *lbTitle;

@end
