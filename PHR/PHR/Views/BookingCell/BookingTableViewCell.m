//
//  BookingTableViewCell.m
//  PHR
//
//  Created by Tran Hoang Ha on 9/8/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "BookingTableViewCell.h"
#import "PHRBookingModel.h"

static CGFloat const defaultBookingCellHeight = 80.0;

@interface BookingTableViewCell()
@property (nonatomic, weak) IBOutlet UILabel *lbDepartmentName;
@property (nonatomic, weak) IBOutlet UILabel *lbTime;
@property (nonatomic, weak) IBOutlet UILabel *lbDoctorName;
@property (nonatomic, weak) IBOutlet UILabel *lbStatus;
@property (nonatomic, weak) IBOutlet UIView *rightStatusView;
@end

@implementation BookingTableViewCell
- (void)awakeFromNib {
    [super awakeFromNib];
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated {
    [super setSelected:selected animated:animated];
}

+ (CGFloat)cellHeight {
    return defaultBookingCellHeight;
}

- (void)bindViewModel:(id)viewModel {
    PHRBookingModel *model = (PHRBookingModel *)viewModel;
    _lbDepartmentName.text = model.departmentName;
    _lbTime.text = [NSUtils timeSeparateWith:model.examinationTime];
    _lbDoctorName.text = model.doctorName;
    _lbStatus.text = model.displayText;
    _lbStatus.textColor = model.displayColor;
    _rightStatusView.backgroundColor = model.displayColor;
}
@end
