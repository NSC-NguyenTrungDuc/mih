//
//  PHRMedicineTitleTableViewCell.h
//  PHR
//
//  Created by DEV-MinhNN on 10/28/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "SWTableViewCell.h"

@interface PHRMedicineTitleTableViewCell : SWTableViewCell {
    UIImageView *imgBG;
}

@property (weak, nonatomic) IBOutlet UILabel *lbDate;
@property (weak, nonatomic) IBOutlet UILabel *lbKcal;
@property (readwrite, assign) BOOL cellEditable;

- (void)setStyleToHeaderTableViewWithTitle:(NSString *)titleBtn andDate:(NSString *)dateTime;

@end
