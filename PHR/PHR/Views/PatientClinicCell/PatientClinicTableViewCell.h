//
//  PatientClinicTableViewCell.h
//  PHR
//
//  Created by Tran Hoang Ha on 10/6/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface PatientClinicTableViewCell : UITableViewCell
+ (CGFloat)cellHeight;
- (void)setViewModelForCell:(id)viewModel;
@end
