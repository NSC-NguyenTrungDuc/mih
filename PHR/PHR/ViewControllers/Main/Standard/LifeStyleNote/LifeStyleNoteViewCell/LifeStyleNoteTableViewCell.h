//
//  LifeStyleNoteTableViewCell.h
//  PHR
//
//  Created by DEV-MinhNN on 1/29/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "LifeStyleNoteModel.h"
#import "SWTableViewCell.h"


@interface LifeStyleNoteTableViewCell : SWTableViewCell

@property (weak, nonatomic) IBOutlet UILabel *lbTime;
@property (weak, nonatomic) IBOutlet UILabel *lbAmOrPm;
@property (weak, nonatomic) IBOutlet UITextField *lbTimeLifeStyleNote;
@property (weak, nonatomic) IBOutlet UIView *viewContaint;
@property (weak, nonatomic) IBOutlet UIImageView *imgTimeNote;

@property (weak, nonatomic) IBOutlet UIImageView *imgStart1;
@property (weak, nonatomic) IBOutlet UIImageView *imgStart2;
@property (weak, nonatomic) IBOutlet UIImageView *imgStart3;
@property (weak, nonatomic) IBOutlet UIImageView *imgStart4;
@property (weak, nonatomic) IBOutlet UIImageView *imgStart5;

- (void)fillDataCellAndSetStyle:(LifeStyleNoteModel *)model;

@end
