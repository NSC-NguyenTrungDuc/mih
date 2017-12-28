//
//  BabyHomeDiaperCell.h
//  PHR
//
//  Created by Luong Le Hoang on 10/9/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface BabyHomeDiaperCell : UITableViewCell{
    
}
@property (weak, nonatomic) IBOutlet UIImageView *imagePooPee;
@property (weak, nonatomic) IBOutlet UIImageView *imageDiaperColor;
@property (weak, nonatomic) IBOutlet UILabel *labelTime;
@property (weak, nonatomic) IBOutlet UILabel *labelDiaperState;

@end
