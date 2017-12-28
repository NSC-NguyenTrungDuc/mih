//
//  StandardHomeCell.h
//  PHR
//
//  Created by Luong Le Hoang on 10/2/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "MRCircularProgressView.h"
#import "StandardHomeItem.h"

@interface StandardHomeCell : UICollectionViewCell{
    
}
@property (weak, nonatomic) IBOutlet MRCircularProgressView *circularView;
@property (weak, nonatomic) IBOutlet UIImageView *imageIcon;
@property (weak, nonatomic) IBOutlet UILabel *labelProgress;
@property (weak, nonatomic) IBOutlet UILabel *labelTitle;

@property (weak, nonatomic) IBOutlet NSLayoutConstraint *constraintLabelPercentCenter;
@property (weak, nonatomic) IBOutlet NSLayoutConstraint *constraintIconPercentHeight;
@property (weak, nonatomic) IBOutlet UILabel *labelUnit;
@property (weak, nonatomic) IBOutlet UILabel *labelIconPercent;

//- (void)fillData:(StandardHomeItem*)item;
- (void)fillHomeItem:(StandardHomeItem *)item;

@end
