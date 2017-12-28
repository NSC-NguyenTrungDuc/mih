//
//  AddRemiderTableViewCell.h
//  PHR
//
//  Created by BillyMobile on 5/19/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "SWTableViewCell.h"

@interface AddRemiderTableViewCell : SWTableViewCell<SWTableViewCellDelegate>
@property (weak, nonatomic) IBOutlet UILabel *lblTime;

@property (nonatomic, copy) void (^onRemoveRemider)();

@end
